using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object contains information about one member of a chat. Currently, the following 6 types of chat members are supported:
    /// <see cref="ChatMemberOwner"/>,
    /// <see cref="ChatMemberAdministrator"/>,
    /// <see cref="ChatMemberMember"/>,
    /// <see cref="ChatMemberRestricted"/>,
    /// <see cref="ChatMemberLeft"/>,
    /// <see cref="ChatMemberBanned"/>.
    /// </summary>
    [JsonConverter(typeof(JsonTypedConverter))]
    public abstract class ChatMember : IJsonTyped<ChatMemberStatus>
    {
        /// <summary>
        /// The member's status in the chat.
        /// </summary>
        [JsonPropertyName("status")]
        public ChatMemberStatus Type { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMember"/> with the specified status.
        /// </summary>
        /// <param name="status">The member's status in the chat.</param>
        protected ChatMember(ChatMemberStatus status)
        {
            Type = status;
        }

        public override string ToString() => $"{nameof(ChatMember)}[{Type}]";
    }

    /// <summary>
    /// The member's status in the chat.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum ChatMemberStatus : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("member")]
        Member = 0x1,
        [JsonFieldValue("creator")]
        Creator = 0x2,
        [JsonFieldValue("administrator")]
        Administrator = 0x4,
        [JsonFieldValue("restricted")]
        Restricted = 0x8,
        [JsonFieldValue("left")]
        Left = 0x10,
        [JsonFieldValue("kicked")]
        Kicked = 0x20
    }
}
