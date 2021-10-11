using Flub.Utils.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the scope of bot commands, covering a specific chat.
    /// </summary>
    [JsonTyped(BotCommandScopeType.Chat)]
    public class BotCommandScopeChat : BotCommandScope
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).
        /// </summary>
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        protected BotCommandScopeChat(BotCommandScopeType type)
            : base(type)
        {

        }

        public BotCommandScopeChat()
            : this(BotCommandScopeType.Chat)
        {

        }
    }
}
