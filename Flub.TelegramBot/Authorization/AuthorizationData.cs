using System;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Authorization
{
    /// <summary>
    /// Contains data about a user. The integrity can be verified with the <see cref="TelegramBot.ValidateAuthorizationData"/> method.
    /// See <see href="https://core.telegram.org/widgets/login">Telegram Login Widget</see> for more informations.
    /// </summary>
    public class AuthorizationData : IUser
    {
        /// <summary>
        /// Date of the authentication data was created in unix time format.
        /// </summary>
        [AuthenticationField]
        [JsonPropertyName("auth_date")]
        public long? AuthenticationDateValue { get; set; }
        /// <summary>
        /// Date of the authentication data was created.
        /// </summary>
        [JsonIgnore]
        public DateTime? AuthenticationDate => AuthenticationDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(AuthenticationDateValue.Value).DateTime : null;
        /// <summary>
        /// First name of the user.
        /// </summary>
        [AuthenticationField]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// The hash to be compared.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
        /// <summary>
        /// Id of the user.
        /// </summary>
        [AuthenticationField]
        [JsonPropertyName("id")]
        public long? UserId { get; set; }
        /// <summary>
        /// Last name of the user.
        /// </summary>
        [AuthenticationField]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Url to the profile picture of the user.
        /// </summary>
        [AuthenticationField]
        [JsonPropertyName("photo_url")]
        public Uri PhotoUrl { get; set; }
        /// <summary>
        /// Username of the user.
        /// </summary>
        [AuthenticationField]
        [JsonPropertyName("username")]
        public string Username { get; set; }
        /// <summary>
        /// Concatenation of all received fields.
        /// </summary>
        [JsonIgnore]
        public string DataCheckString => string.Join('\n', typeof(AuthorizationData).GetProperties()
            .Where(p => p.GetCustomAttributes<AuthenticationFieldAttribute>().Any())
            .Select(p => p.GetCustomAttribute<JsonPropertyNameAttribute>() is JsonPropertyNameAttribute a && p.GetValue(this) is object value ? $"{a.Name}={value}" : null)
            .Where(s => s is not null));

        long? IChat.Id => UserId;


        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        private sealed class AuthenticationFieldAttribute : Attribute
        {

        }
    }
}
