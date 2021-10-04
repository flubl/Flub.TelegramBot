using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an answer of a user in a non-anonymous poll.
    /// </summary>
    public class PollAnswer
    {
        /// <summary>
        /// Unique poll identifier.
        /// </summary>
        [JsonPropertyName("poll_id")]
        public string PollId { get; set; }
        /// <summary>
        /// The user, who changed the answer to the poll.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
        /// <summary>
        /// Identifiers of answer options, chosen by the user. May be empty if the user retracted their vote.
        /// </summary>
        [JsonPropertyName("poll_id")]
        public IEnumerable<int> OptionIds { get; set; }
    }
}
