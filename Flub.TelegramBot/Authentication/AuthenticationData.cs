using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Authentication
{
    /// <summary>
    /// Base class for a container of fields to be validated.
    /// The integrity of the fields can be verified with the <see cref="TelegramBot.Validate(IAuthenticationData, TimeSpan?, bool)"/> method.
    /// </summary>
    public abstract class AuthenticationData : IAuthenticationData
    {
        private const string SEPERATOR_FIELD = "\n";
        private const string SEPERATOR_KEY_VALUE = "=";

        /// <summary>
        /// Seperator used between each field while concatenating the fields.
        /// </summary>
        protected string fieldSeparator = SEPERATOR_FIELD;
        /// <summary>
        /// Seperator used between the key and value of a field.
        /// </summary>
        protected string keyValueSeperator = SEPERATOR_KEY_VALUE;
        /// <summary>
        /// Json serializer options used to serialize the value of the fields used in the <see cref="DataCheckString"/>.
        /// </summary>
        protected JsonSerializerOptions jsonSerializerOptions = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };

        /// <summary>
        /// Date of the authentication data was created.
        /// </summary>
        public abstract DateTime? AuthenticationDate { get; set; }
        /// <summary>
        /// The hash to be compared.
        /// </summary>
        public abstract string AuthenticationHash { get; set; }
        /// <summary>
        /// Concatenation of all received fields.
        /// </summary>
        [JsonIgnore]
        public virtual string AuthenticationFields => string.Join(fieldSeparator, GetType().GetProperties()
            .Where(p => p.GetCustomAttributes<AuthenticationFieldAttribute>().Any())
            .Select(p => new KeyValuePair<PropertyInfo, object>(p, p.GetValue(this)))
            .Where(i => (i.Key.GetCustomAttribute<JsonIgnoreAttribute>()?.Condition ?? jsonSerializerOptions?.DefaultIgnoreCondition ?? JsonIgnoreCondition.Never)
                is JsonIgnoreCondition c && (c == JsonIgnoreCondition.Never
                    || (c == JsonIgnoreCondition.WhenWritingDefault && !Equals(i.Value, default))
                    || (c == JsonIgnoreCondition.WhenWritingNull && !Equals(i.Value, null))))
            .Select(i => new KeyValuePair<string, object>(i.Key.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? i.Key.Name, i.Value))
            .OrderBy(i => i.Key)
            .Select(i => i.Key + keyValueSeperator + JsonSerializer.Serialize(i.Value, jsonSerializerOptions).Trim('"')));

        /// <summary>
        /// Marks the property to be included in the hash.
        /// </summary>
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        protected sealed class AuthenticationFieldAttribute : Attribute
        {

        }
    }
}
