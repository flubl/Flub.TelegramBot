using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a video file stored on the Telegram servers.
    /// By default, this video file will be sent by the user with an optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the video.
    /// </summary>
    public class InlineQueryResultCachedVideo : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid file identifier for the video file.
        /// </summary>
        [JsonPropertyName("video_file_id")]
        public string VideoFileId { get; set; }
        /// <summary>
        /// Title for the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Short description of the result.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the video.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedVideo"/> class.
        /// </summary>
        public InlineQueryResultCachedVideo() : base(InlineQueryResultType.Video) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedVideo)}[{Id}, {Title}, {VideoFileId}]";
    }
}
