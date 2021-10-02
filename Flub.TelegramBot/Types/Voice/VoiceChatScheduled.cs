using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a service message about a voice chat scheduled in the chat.
    /// </summary>
    public class VoiceChatScheduled
    {
        /// <summary>
        /// Point in time (Unix timestamp) when the voice chat is supposed to be started by a chat administrator.
        /// </summary>
        [JsonPropertyName("start_date")]
        public long? StartDateValue { get; set; }
        /// <summary>
        /// Point in time when the voice chat is supposed to be started by a chat administrator.
        /// </summary>
        [JsonIgnore]
        public DateTime? StartDate
        {
            get => StartDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(StartDateValue.Value).DateTime : null;
            set => StartDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
    }
}
