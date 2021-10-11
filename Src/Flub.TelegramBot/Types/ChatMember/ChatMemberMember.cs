using Flub.Utils.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a chat member that has no additional privileges or restrictions.
    /// </summary>
    [JsonTyped(ChatMemberStatus.Member)]
    public class ChatMemberMember : ChatMember
    {
        /// <summary>
        /// Information about the user.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberMember"/> with the specified status.
        /// </summary>
        /// <param name="status">The member's status in the chat.</param>
        protected ChatMemberMember(ChatMemberStatus status)
            : base(status)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberMember"/> with the <see cref="ChatMemberStatus.Member"/> status.
        /// </summary>
        public ChatMemberMember()
            : this(ChatMemberStatus.Member)
        {

        }
    }
}
