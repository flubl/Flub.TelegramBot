using Flub.Utils.Json;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a chat member that isn't currently a member of the chat, but may join it themselves.
    /// </summary>
    [JsonTyped(ChatMemberStatus.Left)]
    public class ChatMemberLeft : ChatMemberMember
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberLeft"/> with the <see cref="ChatMemberStatus.Left"/> status.
        /// </summary>
        public ChatMemberLeft()
            : base(ChatMemberStatus.Left)
        {

        }
    }
}
