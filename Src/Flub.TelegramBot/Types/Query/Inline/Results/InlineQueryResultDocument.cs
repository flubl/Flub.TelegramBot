using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a file.
    /// By default, this file will be sent by the user with an optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the file.
    /// Currently, only .PDF and .ZIP files can be sent using this method.
    /// </summary>
    public class InlineQueryResultDocument : InlineQueryResultWithCaption
    {
        /// <summary>
        /// Title for the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// A valid URL for the file.
        /// </summary>
        [JsonPropertyName("document_url")]
        public Uri DocumentUrl { get; set; }
        /// <summary>
        /// Mime type of the content of the file, either "application/pdf" or "application/zip".
        /// </summary>
        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }
        /// <summary>
        /// Optional. Short description of the result.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the file.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }
        /// <summary>
        /// Optional. URL of the thumbnail (JPEG only) for the file.
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
        /// Initializes a new instance of the <see cref="InlineQueryResultDocument"/> class.
        /// </summary>
        public InlineQueryResultDocument() : base(InlineQueryResultType.Document) { }

        public override string ToString() => $"{nameof(InlineQueryResultDocument)}[{Id}, {Title}, {DocumentUrl}]";
    }
}
