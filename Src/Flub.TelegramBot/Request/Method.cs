using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Base class of a request method with the specified <see cref="Response{TResult}.Result"/> type.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class Method<TResult> : IMethod<TResult>
    {
        /// <summary>
        /// The name of the request method.
        /// </summary>
        [JsonPropertyName("method")]
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method{TResult}"/> class with a specified request method.
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
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/> to check if a property should be ignored.</param>
        /// <returns>Returns a <see cref="IImmutableDictionary{string, object}"/> with all values to be uploaded.</returns>
        public IImmutableDictionary<string, object> GetProperties(JsonSerializerOptions options = null) => GetType().GetProperties()
            .Where(p => p.SouldNotBeIgnored(p.GetValue(this), options))
            .ToImmutableDictionary(p => p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? p.Name, p => p.GetValue(this));

        public override string ToString() => base.ToString();
    }

    /// <summary>
    /// Base class of a request method with files to be uploaded.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class MethodUpload<TResult> : Method<TResult>, IFileContainer
    {
        /// <summary>
        /// The Files to be uploaded.
        /// </summary>
        protected abstract IEnumerable<InputFile> Files { get; }

        bool IFileContainer.HasFiles => ((IFileContainer)this).Files?.Any() ?? false;
        IEnumerable<InputFile> IFileContainer.Files => Files?.Where(f => f?.IsFile ?? false);

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
