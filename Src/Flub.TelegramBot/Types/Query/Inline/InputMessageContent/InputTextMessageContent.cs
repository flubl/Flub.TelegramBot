﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the content of a text message to be sent as the result of an inline query.
    /// </summary>
    public class InputTextMessageContent : InputMessageContent
    {
        /// <summary>
        /// Text of the message to be sent, 1-4096 characters.
        /// </summary>
        [JsonPropertyName("message_text")]
        public string MessageText { get; set; }
        /// <summary>
        /// Optional. Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("parse_mode")]
        public ParseMode? ParseMode { get; set; }
        /// <summary>
        /// Optional. List of special entities that appear in message text, which can be specified instead of <see cref="ParseMode"/>.
        /// </summary>
        [JsonPropertyName("entities")]
        public IEnumerable<MessageEntity> Entities { get; set; }
        /// <summary>
        /// Optional. Disables link previews for links in the sent message.
        /// </summary>
        [JsonPropertyName("disable_web_page_preview")]
        public bool? DisableWebPagePreview { get; set; }

        public override string ToString() => $"{nameof(InputTextMessageContent)}[{MessageText}]";
    }
}
