using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a service message about new members invited to a voice chat.
    /// </summary>
    public class VoiceChatParticipantsInvited
    {
        /// <summary>
        /// Optional. New members that were invited to the voice chat.
        /// </summary>
        [JsonPropertyName("users")]
        public IEnumerable<User> Users { get; set; }
    }
}
