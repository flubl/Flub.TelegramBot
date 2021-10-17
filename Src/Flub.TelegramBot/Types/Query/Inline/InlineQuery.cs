using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an incoming inline query. When the user sends an empty query, your bot could return some default or trending results.
    /// </summary>
    public class InlineQuery
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
        /// Text of the query (up to 256 characters).
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }
        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot.
        /// </summary>
        [JsonPropertyName("offset")]
        public string Offset { get; set; }
        /// <summary>
        /// Optional. Type of the chat, from which the inline query was sent.
        /// The chat type should be always known for requests sent from official clients and most third-party clients, unless the request was sent from a secret chat.
        /// </summary>
        [JsonPropertyName("chat_type")]
        public ChatType? ChatType { get; set; }
        /// <summary>
        /// Optional. Sender location, only for bots that request user location.
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }
}
