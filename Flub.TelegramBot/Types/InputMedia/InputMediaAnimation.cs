using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound) to be sent.
    /// </summary>
    public class InputMediaAnimation : InputMediaWithThumb
    {
        /// <summary>
        /// Optional. Media width.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        /// <summary>
        /// Optional. Media height.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        /// <summary>
        /// Optional. Media duration.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaAnimation"/> class with a specified type.
        /// </summary>
        /// <param name="type">The type of the media.</param>
        protected InputMediaAnimation(InputMediaType type)
            : base(type)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaAnimation"/> class.
        /// </summary>
        public InputMediaAnimation()
            : this(InputMediaType.Animation)
        {

        }
    }
}
