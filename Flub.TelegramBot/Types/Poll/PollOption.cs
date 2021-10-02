using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object contains information about one answer option in a poll.
    /// </summary>
    public class PollOption
    {
        /// <summary>
        /// Option text, 1-100 characters.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// Number of users that voted for this option.
        /// </summary>
        [JsonPropertyName("voter_count")]
        public int? VoterCount { get; set; }
    }
}
