using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents the content of a service message, sent whenever a user in the chat triggers a proximity alert set by another user.
    /// </summary>
    public class ProximityAlertTriggered
    {
        /// <summary>
        /// User that triggered the alert.
        /// </summary>
        [JsonPropertyName("traveler")]
        public User Traveler { get; set; }
        /// <summary>
        /// User that set the alert.
        /// </summary>
        [JsonPropertyName("watcher")]
        public User Watcher { get; set; }
        /// <summary>
        /// The distance between the users.
        /// </summary>
        [JsonPropertyName("distance")]
        public int? Distance { get; set; }
    }
}
