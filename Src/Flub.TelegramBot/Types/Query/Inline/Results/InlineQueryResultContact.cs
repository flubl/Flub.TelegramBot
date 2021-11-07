using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a contact with a phone number.
    /// By default, this contact will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the contact.
    /// </summary>
    public class InlineQueryResultContact : InlineQueryResult
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
        /// Optional. Additional data about the contact in the form of a vCard, 0-2048 bytes.
        /// </summary>
        [JsonPropertyName("vcard")]
        public string VCard { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the contact.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }
        /// <summary>
        /// Optional. Url of the thumbnail for the result.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public Uri ThumbUrl { get; set; }
        /// <summary>
        /// Optional. Thumbnail width.
        /// </summary>
        [JsonPropertyName("thumb_width")]
        public int? ThumbWidth { get; set; }
        /// <summary>
        /// Optional. Thumbnail height.
        /// </summary>
        [JsonPropertyName("thumb_height")]
        public int? ThumbHeight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultContact"/> class.
        /// </summary>
        public InlineQueryResultContact() : base(InlineQueryResultType.Contact) { }

        public override string ToString() => $"{nameof(InlineQueryResultContact)}[{Id}, {FirstName}, {PhoneNumber}]";
    }
}
