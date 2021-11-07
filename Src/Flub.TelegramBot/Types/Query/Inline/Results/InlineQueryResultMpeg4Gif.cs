using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound).
    /// By default, this animated MPEG-4 file will be sent by the user with optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the animation.
    /// </summary>
    public class InlineQueryResultMpeg4Gif : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid URL for the MP4 file. File size must not exceed 1MB.
        /// </summary>
        [JsonPropertyName("mpeg4_url")]
        public Uri Mpeg4Url { get; set; }
        /// <summary>
        /// Optional. Video width.
        /// </summary>
        [JsonPropertyName("mpeg4_width")]
        public int? Mpeg4Width { get; set; }
        /// <summary>
        /// Optional. Video height.
        /// </summary>
        [JsonPropertyName("mpeg4_height")]
        public int? Mpeg4Height { get; set; }
        /// <summary>
        /// Optional. Video duration in seconds.
        /// </summary>
        [JsonPropertyName("mpeg4_duration")]
        public int? Mpeg4DurationValue { get; set; }
        /// <summary>
        /// Optional. Video duration.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? Mpeg4Duration
        {
            get => Mpeg4DurationValue.HasValue ? TimeSpan.FromSeconds(Mpeg4DurationValue.Value) : null;
            set => Mpeg4DurationValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
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
        /// Optional. Content of the message to be sent instead of the video animation.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultMpeg4Gif"/> class.
        /// </summary>
        public InlineQueryResultMpeg4Gif() : base(InlineQueryResultType.Mpeg4Gif) { }

        public override string ToString() => $"{nameof(InlineQueryResultMpeg4Gif)}[{Id}, {Mpeg4Url}]";
    }
}
