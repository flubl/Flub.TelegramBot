using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a service message about a change in auto-delete timer settings.
    /// </summary>
    public class MessageAutoDeleteTimerChanged
    {
        /// <summary>
        /// New auto-delete time in seconds for messages in the chat.
        /// </summary>
        [JsonPropertyName("message_auto_delete_time")]
        public int? MessageAutoDeleteTimeValue { get; set; }
        /// <summary>
        /// New auto-delete time for messages in the chat.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? MessageAutoDeleteTime
        {
            get => MessageAutoDeleteTimeValue.HasValue ? TimeSpan.FromSeconds(MessageAutoDeleteTimeValue.Value) : null;
            set => MessageAutoDeleteTimeValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
        }

        public override string ToString() => $"{nameof(MessageAutoDeleteTimerChanged)}[{MessageAutoDeleteTime}]";
    }
}
