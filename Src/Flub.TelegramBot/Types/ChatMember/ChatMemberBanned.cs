using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a chat member that was banned in the chat and can't return to the chat or view chat messages.
    /// </summary>
    [JsonTyped(ChatMemberStatus.Kicked)]
    public class ChatMemberBanned : ChatMemberMember
    {
        /// <summary>
        /// Date when restrictions will be lifted for this user; unix time. If 0, then the user is banned forever.
        /// </summary>
        [JsonPropertyName("until_date")]
        public long? UntilDateValue { get; set; }
        /// <summary>
        /// Date when restrictions will be lifted for this user.
        /// </summary>
        [JsonIgnore]
        public DateTime? UntilDate
        {
            get => UntilDateValue.HasValue && UntilDateValue != 0 ? DateTimeOffset.FromUnixTimeSeconds(UntilDateValue.Value).DateTime : null;
            set => UntilDateValue = value.HasValue && new DateTimeOffset(value.Value).ToUnixTimeSeconds() is long l && l > 0 ? l : null;
        }
        /// <summary>
        /// <see langword="true"/>, if the user is banned forever.
        /// </summary>
        [JsonIgnore]
        public bool? IsForever
        {
            get => UntilDateValue.HasValue ? UntilDateValue == 0 : null;
            set => UntilDateValue = value.HasValue ? value.Value ? 0 : UntilDateValue : null;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberBanned"/> with the <see cref="ChatMemberStatus.Kicked"/> status.
        /// </summary>
        public ChatMemberBanned() : base(ChatMemberStatus.Kicked) { }

        public override string ToString() => $"{nameof(ChatMemberBanned)}[{User}, until {UntilDate}]";
    }
}
