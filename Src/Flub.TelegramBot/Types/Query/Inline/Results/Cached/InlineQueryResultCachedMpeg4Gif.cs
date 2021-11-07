using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound) stored on the Telegram servers.
    /// By default, this animated MPEG-4 file will be sent by the user with an optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the animation.
    /// </summary>
    public class InlineQueryResultCachedMpeg4Gif : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid file identifier for the MP4 file.
        /// </summary>
        [JsonPropertyName("mpeg4_file_id")]
        public string Mpeg4FileId { get; set; }
        /// <summary>
        /// Optional. Title for the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the video animation.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedMpeg4Gif"/> class.
        /// </summary>
        public InlineQueryResultCachedMpeg4Gif() : base(InlineQueryResultType.Mpeg4Gif) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedMpeg4Gif)}[{Id}, {Mpeg4FileId}]";
    }
}
