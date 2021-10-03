using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Base class of a request method.
    /// </summary>
    public abstract class Method
    {
        /// <summary>
        /// The name of the request method.
        /// </summary>
        [JsonIgnore]
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class with a specified request method.
        /// </summary>
        /// <param name="name">The name of the request method.</param>
        protected Method(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        /// <summary>
        /// Returns all properties with it's name and value to be uploaded.
        /// </summary>
        /// <returns>Returns a <see cref="IImmutableDictionary{string, object}"/> with all values to be uploaded.</returns>
        public IImmutableDictionary<string, object> GetProperties() => GetType().GetProperties()
            .Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() is null)
            .ToImmutableDictionary(
                p => p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? p.Name,
                p => p.GetValue(this));
    }

    /// <summary>
    /// Base class of a request method with the specified <see cref="Response{TResult}.Result"/> type.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class Method<TResult> : Method where TResult : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Method{TResult}"/> class with a specified request method.
        /// </summary>
        /// <param name="name">The name of the request method.</param>
        protected Method(string name)
            : base(name)
        {

        }
    }

    /// <summary>
    /// Base class of a request method with files to be uploaded.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class MethodUpload<TResult> : Method<TResult>, IFileContainer where TResult : class
    {
        /// <summary>
        /// The Files to be uploaded.
        /// </summary>
        protected abstract IEnumerable<InputFile> Files { get; }

        bool IFileContainer.HasFiles => Files?.Any(f => f?.IsFile ?? false) ?? false;
        IEnumerable<InputFile> IFileContainer.Files => Files;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodUpload{TResult}"/> class with a specified request method.
        /// </summary>
        /// <param name="name">The name of the request method.</param>
        protected MethodUpload(string name)
            : base(name)
        {

        }
    }
}
