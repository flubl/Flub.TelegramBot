using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a file stored on the Telegram servers.
    /// By default, this file will be sent by the user with an optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the file.
    /// </summary>
    public class InlineQueryResultCachedDocument : InlineQueryResultWithCaption
    {
        /// <summary>
        /// Title for the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// A valid file identifier for the file.
        /// </summary>
        [JsonPropertyName("document_file_id")]
        public string DocumentFileId { get; set; }
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
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedDocument"/> class.
        /// </summary>
        public InlineQueryResultCachedDocument() : base(InlineQueryResultType.Document) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedDocument)}[{Id}, {Title}, {DocumentFileId}]";
    }
}
