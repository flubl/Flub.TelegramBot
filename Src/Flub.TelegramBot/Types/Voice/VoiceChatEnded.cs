using System;
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
        public int? DurationValue { get; set; }
        /// <summary>
        /// Voice chat duration.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? Duration
        {
            get => DurationValue.HasValue ? TimeSpan.FromSeconds(DurationValue.Value) : null;
            set => DurationValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
        }

        public override string ToString() => $"{nameof(VoiceChatEnded)}[{Duration}]";
    }
}
