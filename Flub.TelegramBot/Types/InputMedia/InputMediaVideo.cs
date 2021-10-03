using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a video to be sent.
    /// </summary>
    public class InputMediaVideo : InputMediaAnimation
    {
        /// <summary>
        /// Optional. Pass True, if the uploaded video is suitable for streaming.
        /// </summary>
        [JsonPropertyName("supports_streaming")]
        public bool? SupportsStreaming { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaVideo"/> class.
        /// </summary>
        public InputMediaVideo()
            : base(InputMediaType.Video)
        {

        }
    }
}
