using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a join request sent to a chat.
    /// </summary>
    public class ChatJoinRequest
    {
        /// <summary>
        /// Chat to which the request was sent.
        /// </summary>
        [JsonPropertyName("chat")]
        public Chat Chat { get; set; }
        /// <summary>
        /// User that sent the join request.
        /// </summary>
        [JsonPropertyName("from")]
        public User From { get; set; }
        /// <summary>
        /// Date the request was sent in Unix time.
        /// </summary>
        [JsonPropertyName("date")]
        public long? DateValue { get; set; }
        /// <summary>
        /// Date the request was sent.
        /// </summary>
        [JsonIgnore]
        public DateTime? Date
        {
            get => DateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(DateValue.Value).DateTime : null;
            set => DateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
        /// <summary>
        /// Optional. Bio of the user.
        /// </summary>
        [JsonPropertyName("bio")]
        public string Bio { get; set; }
        /// <summary>
        /// Optional. Chat invite link that was used by the user to send the join request.
        /// </summary>
        [JsonPropertyName("invite_link")]
        public ChatInviteLink InviteLink { get; set; }

        public override string ToString() => $"{nameof(ChatJoinRequest)}[{Chat}, {From}, {Date}]";
    }
}
