using Flub.Utils.Json;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the scope of bot commands, covering all administrators of a specific group or supergroup chat.
    /// </summary>
    [JsonTyped(BotCommandScopeType.ChatAdministrators)]
    public class BotCommandScopeChatAdministrators : BotCommandScopeChat
    {
        public BotCommandScopeChatAdministrators() : base(BotCommandScopeType.ChatAdministrators) { }

        public override string ToString() => $"{nameof(BotCommandScopeChatAdministrators)}[{ChatId}]";
    }
}
