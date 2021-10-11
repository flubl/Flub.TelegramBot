using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a service message about a change in auto-delete timer settings.
    /// </summary>
    public class MessageAutoDeleteTimerChanged
    {
        /// <summary>
        /// New auto-delete time for messages in the chat.
        /// </summary>
        [JsonPropertyName("message_auto_delete_time")]
        public int? MessageAutoDeleteTime { get; set; }
    }
}
