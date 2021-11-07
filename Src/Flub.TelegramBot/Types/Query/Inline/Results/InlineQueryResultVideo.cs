using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a page containing an embedded video player or a video file.
    /// By default, this video file will be sent by the user with an optional caption.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the video.
    /// If an <see cref="InlineQueryResultVideo"/> message contains an embedded video (e.g., YouTube), you must replace its content using <see cref="InputMessageContent"/>.
    /// </summary>
    public class InlineQueryResultVideo : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid URL for the embedded video player or video file.
        /// </summary>
        [JsonPropertyName("video_url")]
        public Uri VideoUrl { get; set; }
        /// <summary>
        /// Mime type of the content of video url, "text/html" or "video/mp4".
        /// </summary>
        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }
        /// <summary>
        /// URL of the thumbnail (JPEG only) for the video.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public Uri ThumbUrl { get; set; }
        /// <summary>
        /// Title for the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Video width.
        /// </summary>
        [JsonPropertyName("video_width")]
        public int? VideoWidth { get; set; }
        /// <summary>
        /// Optional. Video height.
        /// </summary>
        [JsonPropertyName("video_height")]
        public int? VideoHeight { get; set; }
        /// <summary>
        /// Optional. Video duration in seconds.
        /// </summary>
        [JsonPropertyName("video_duration")]
        public int? VideoDurationValue { get; set; }
        /// <summary>
        /// Optional. Video duration.
        /// </summary>
        [JsonPropertyName("video_duration")]
        public TimeSpan? VideoDuration
        {
            get => VideoDurationValue.HasValue ? TimeSpan.FromSeconds(VideoDurationValue.Value) : null;
            set => VideoDurationValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
        }
        /// <summary>
        /// Optional. Short description of the result.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the video.
        /// This field is required if <see cref="InlineQueryResultVideo"/> is used to send an HTML-page as a result (e.g., a YouTube video).
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultVideo"/> class.
        /// </summary>
        public InlineQueryResultVideo() : base(InlineQueryResultType.Video) { }

        public override string ToString() => $"{nameof(InlineQueryResultVideo)}[{Id}. {Title}, {VideoUrl}]";
    }
}
