using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a unique message identifier.
    /// </summary>
    public class MessageId : IMessage
    {
        /// <summary>
        /// Unique message identifier.
        /// </summary>
        [JsonPropertyName("message_id")]
        public int? Id { get; set; }
    }
}
