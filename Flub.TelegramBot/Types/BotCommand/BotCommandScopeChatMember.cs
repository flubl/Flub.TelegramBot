using Flub.Utils.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the scope of bot commands, covering a specific member of a group or supergroup chat.
    /// </summary>
    [JsonTyped(BotCommandScopeType.ChatMember)]
    public class BotCommandScopeChatMember : BotCommandScopeChat
    {
        /// <summary>
        /// Unique identifier of the target user.
        /// </summary>
        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        public BotCommandScopeChatMember()
            : base(BotCommandScopeType.ChatMember)
        {

        }
    }
}
