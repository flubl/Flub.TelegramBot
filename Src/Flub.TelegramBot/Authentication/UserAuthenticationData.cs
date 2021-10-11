using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Authentication
{
    /// <summary>
    /// Contains data about a user. The integrity can be verified with the <see cref="TelegramBot.Validate"/> method.
    /// See <see href="https://core.telegram.org/widgets/login">Telegram Login Widget</see> for more informations.
    /// </summary>
    public class UserAuthenticationData : AuthenticationData, IUser
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
        public override DateTime? AuthenticationDate
        {
            get => AuthenticationDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(AuthenticationDateValue.Value).DateTime : null;
            set => AuthenticationDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
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
        public override string AuthenticationHash { get; set; }
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

        long? IChat.Id => UserId;
    }
}
