using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to an animated GIF file stored on the Telegram servers.
    /// By default, this animated GIF file will be sent by the user with an optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with specified content instead of the animation.
    /// </summary>
    public class InlineQueryResultCachedGif : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid file identifier for the GIF file.
        /// </summary>
        [JsonPropertyName("gif_file_id")]
        public string GifFileId { get; set; }
        /// <summary>
        /// Optional. Title for the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the GIF animation.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedGif"/> class.
        /// </summary>
        public InlineQueryResultCachedGif() : base(InlineQueryResultType.Gif) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedGif)}[{Id}, {GifFileId}]";
    }
}
