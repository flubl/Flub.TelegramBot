using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a photo to be sent.
    /// </summary>
    public class InputMediaPhoto : InputMedia
    {
        /// <summary>
        /// Optional. Caption of the media to be sent, 0-1024 characters after entities parsing.
        /// </summary>
        [JsonPropertyName("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// Optional. Mode for parsing entities in the media caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("parse_mode")]
        public ParseMode? ParseMode { get; set; }
        /// <summary>
        /// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode.
        /// </summary>
        [JsonPropertyName("caption_entities")]
        public MessageEntity[] CaptionEntities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaPhoto"/> class with a specified type.
        /// </summary>
        /// <param name="type">The type of the media.</param>
        protected InputMediaPhoto(InputMediaType type)
            : base(type)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaPhoto"/> class.
        /// </summary>
        public InputMediaPhoto()
            : this(InputMediaType.Photo)
        {

        }
    }
}
