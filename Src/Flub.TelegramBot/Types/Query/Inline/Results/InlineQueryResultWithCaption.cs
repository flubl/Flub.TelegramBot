using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one result of an inline query with a caption.
    /// </summary>
    public abstract class InlineQueryResultWithCaption : InlineQueryResult
    {
        /// <summary>
        /// Optional. Caption of the photo to be sent, 0-1024 characters after entities parsing.
        /// </summary>
        [JsonPropertyName("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// Optional. Mode for parsing entities in the photo caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("parse_mode")]
        public ParseMode? ParseMode { get; set; }
        /// <summary>
        /// Optional. List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode"/>.
        /// </summary>
        [JsonPropertyName("caption_entities")]
        public IEnumerable<MessageEntity> CaptionEntities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultWithCaption"/> class with a specified type.
        /// </summary>
        /// <param name="type">Type of the result.</param>
        protected InlineQueryResultWithCaption(InlineQueryResultType type) : base(type) { }
    }
}
