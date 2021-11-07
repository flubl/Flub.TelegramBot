using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents changes in the status of a chat member.
    /// </summary>
    public class ChatMemberUpdated
    {
        /// <summary>
        /// Chat the user belongs to.
        /// </summary>
        [JsonPropertyName("chat")]
        public Chat Chat { get; set; }
        /// <summary>
        /// Performer of the action, which resulted in the change.
        /// </summary>
        [JsonPropertyName("from")]
        public User From { get; set; }
        /// <summary>
        /// Date the change was done in Unix time.
        /// </summary>
        [JsonPropertyName("date")]
        public long? DateValue { get; set; }
        /// <summary>
        /// Date the change was done.
        /// </summary>
        [JsonIgnore]
        public DateTime? Date
        {
            get => DateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(DateValue.Value).DateTime : null;
            set => DateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
        /// <summary>
        /// Previous information about the chat member.
        /// </summary>
        [JsonPropertyName("old_chat_member")]
        public ChatMember OldChatMember { get; set; }
        /// <summary>
        /// New information about the chat member.
        /// </summary>
        [JsonPropertyName("new_chat_member")]
        public ChatMember NewChatMember { get; set; }
        /// <summary>
        /// Optional. Chat invite link, which was used by the user to join the chat; for joining by invite link events only.
        /// </summary>
        [JsonPropertyName("invite_link")]
        public ChatInviteLink InviteLink { get; set; }

        public override string ToString() => $"{nameof(ChatMemberUpdated)}[{Chat}, {From}, {Date}]";
    }
}
