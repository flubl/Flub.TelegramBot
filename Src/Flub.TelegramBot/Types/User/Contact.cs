using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a phone contact.
    /// </summary>
    public class Contact : IChat
    {
        /// <summary>
        /// Contact's phone number.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Contact's first name.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Optional. Contact's last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Optional. Contact's user identifier in Telegram.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// Optional. Additional data about the contact in the form of a <see href="https://en.wikipedia.org/wiki/VCard">vCard</see>.
        /// </summary>
        [JsonPropertyName("vcard")]
        public string VCard { get; set; }

        long? IChat.Id => UserId;

        public override string ToString() => $"{nameof(Contact)}[{FirstName}, {PhoneNumber}]";
    }
}
