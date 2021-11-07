using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a photo.
    /// By default, this photo will be sent by the user with optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the photo.
    /// </summary>
    public class InlineQueryResultPhoto : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid URL of the photo. Photo must be in JPEG format. Photo size must not exceed 5MB.
        /// </summary>
        [JsonPropertyName("photo_url")]
        public Uri PhotoUrl { get; set; }
        /// <summary>
        /// URL of the thumbnail for the photo.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public Uri ThumbUrl { get; set; }
        /// <summary>
        /// Optional. Width of the photo.
        /// </summary>
        [JsonPropertyName("photo_width")]
        public int? PhotoWidth { get; set; }
        /// <summary>
        /// Optional. Height of the photo.
        /// </summary>
        [JsonPropertyName("photo_height")]
        public int? PhotoHeight { get; set; }
        /// <summary>
        /// Optional. Title for the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Short description of the result.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the photo.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultPhoto"/> class.
        /// </summary>
        public InlineQueryResultPhoto() : base(InlineQueryResultType.Photo) { }

        public override string ToString() => $"{nameof(InlineQueryResultPhoto)}[{Id}, {PhotoUrl}, {ThumbUrl}]";
    }
}
