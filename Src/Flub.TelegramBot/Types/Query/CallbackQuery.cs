using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an incoming callback query from a callback button in an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see>. If the button that originated the query was attached to a message sent by the bot, the field message will be present. If the button was attached to a message sent via the bot (in <see href="https://core.telegram.org/bots/api#inline-mode">inline mode</see>), the field inline_message_id will be present. Exactly one of the fields data or game_short_name will be present.
    /// </summary>
    public class CallbackQuery : IInlineMessage
    {
        /// <summary>
        /// Unique identifier for this query.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Sender.
        /// </summary>
        [JsonPropertyName("from")]
        public User From { get; set; }
        /// <summary>
        /// Optional. Message with the callback button that originated the query. Note that message content and message date will not be available if the message is too old.
        /// </summary>
        [JsonPropertyName("message")]
        public Message Message { get; set; }
        /// <summary>
        /// Optional. Identifier of the message sent via the bot in inline mode, that originated the query.
        /// </summary>
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
        /// <summary>
        /// Global identifier, uniquely corresponding to the chat to which the message with the callback button was sent. Useful for high scores in <see href="https://core.telegram.org/bots/api#games">games</see>.
        /// </summary>
        [JsonPropertyName("chat_instance")]
        public string ChatInstance { get; set; }
        /// <summary>
        /// Optional. Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }
        /// <summary>
        /// Optional. Short name of a <see href="https://core.telegram.org/bots/api#games">Game</see> to be returned, serves as the unique identifier for the game.
        /// </summary>
        [JsonPropertyName("game_short_name")]
        public string GameShortName { get; set; }
    }
}
