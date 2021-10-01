using System;
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
        /// <returns>Returns a <see cref="IImmutableDictionary{TKey, TValue}"/> with all values to be uploaded.</returns>
        public IImmutableDictionary<string, object> GetProperties() => GetType().GetProperties()
            .Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() is null)
            .ToImmutableDictionary(
                p => p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? p.Name,
                p => p.GetValue(this));

        /// <summary>
        /// Indicates whenever there is a file to be uploaded.
        /// </summary>
        /// <returns>True, if the method contains a file to be uploaded.</returns>
        public bool HasFiles() => GetType().GetProperties()
            .Any(p => p.PropertyType == typeof(InputFile)
                && p.GetCustomAttribute<JsonIgnoreAttribute>() is null
                && p.GetValue(this) is InputFile file
                && file.IsFile);
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
}
