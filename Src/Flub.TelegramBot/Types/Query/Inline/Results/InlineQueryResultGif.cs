using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to an animated GIF file.
    /// By default, this animated GIF file will be sent by the user with optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the animation.
    /// </summary>
    public class InlineQueryResultGif : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid URL for the GIF file. File size must not exceed 1MB.
        /// </summary>
        [JsonPropertyName("gif_url")]
        public Uri GifUrl { get; set; }
        /// <summary>
        /// Optional. Width of the GIF.
        /// </summary>
        [JsonPropertyName("gif_width")]
        public int? GifWidth { get; set; }
        /// <summary>
        /// Optional. Height of the GIF.
        /// </summary>
        [JsonPropertyName("gif_height")]
        public int? GfiHeight { get; set; }
        /// <summary>
        /// Optional. Duration of the GIF in seconds.
        /// </summary>
        [JsonPropertyName("gif_duration")]
        public int? GifDurationValue { get; set; }
        /// <summary>
        /// Optional. Duration of the GIF.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? GifDuration
        {
            get => GifDurationValue.HasValue ? TimeSpan.FromSeconds(GifDurationValue.Value) : null;
            set => GifDurationValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
        }
        /// <summary>
        /// URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public Uri ThumbUrl { get; set; }
        /// <summary>
        /// Optional. MIME type of the thumbnail, must be one of "image/jpeg", "image/gif", or "video/mp4". Defaults to "image/jpeg".
        /// </summary>
        [JsonPropertyName("thumb_mime_type")]
        public string ThumbMimeType { get; set; }
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
        /// Initializes a new instance of the <see cref="InlineQueryResultGif"/> class.
        /// </summary>
        public InlineQueryResultGif() : base(InlineQueryResultType.Gif) { }

        public override string ToString() => $"{nameof(InlineQueryResultGif)}[{Id}, {GifUrl}]";
    }
}
