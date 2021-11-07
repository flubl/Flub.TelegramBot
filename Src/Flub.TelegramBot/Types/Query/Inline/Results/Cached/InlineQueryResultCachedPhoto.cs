using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a photo stored on the Telegram servers.
    /// By default, this photo will be sent by the user with an optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the photo.
    /// </summary>
    public class InlineQueryResultCachedPhoto : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid file identifier of the photo.
        /// </summary>
        [JsonPropertyName("photo_file_id")]
        public string PhotoFileId { get; set; }
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
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedPhoto"/> class.
        /// </summary>
        public InlineQueryResultCachedPhoto() : base(InlineQueryResultType.Photo) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedPhoto)}[{Id}, {Title}, {PhotoFileId}]";
    }
}
