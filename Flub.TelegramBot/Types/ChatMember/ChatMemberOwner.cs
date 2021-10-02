using Flub.Utils.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a chat member that owns the chat and has all administrator privileges.
    /// </summary>
    [JsonTyped(ChatMemberStatus.Creator)]
    public class ChatMemberOwner : ChatMemberMember
    {
        /// <summary>
        /// True, if the user's presence in the chat is hidden.
        /// </summary>
        [JsonPropertyName("is_anonymous")]
        public bool? IsAnonymous { get; set; }
        /// <summary>
        /// Optional. Custom title for this user.
        /// </summary>
        [JsonPropertyName("custom_title")]
        public string CustomTitle { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberOwner"/> with the specified status.
        /// </summary>
        /// <param name="status">The member's status in the chat.</param>
        protected ChatMemberOwner(ChatMemberStatus status)
            : base(status)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberOwner"/> with the <see cref="ChatMemberStatus.Creator"/> status.
        /// </summary>
        public ChatMemberOwner()
            : this(ChatMemberStatus.Creator)
        {

        }
    }
}
