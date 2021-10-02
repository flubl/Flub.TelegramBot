using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a service message about a voice chat ended in the chat.
    /// </summary>
    public class VoiceChatEnded
    {
        /// <summary>
        /// Voice chat duration; in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
    }
}
