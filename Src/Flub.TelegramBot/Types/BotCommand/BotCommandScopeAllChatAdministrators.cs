using Flub.Utils.Json;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the scope of bot commands, covering all group and supergroup chat administrators.
    /// </summary>
    [JsonTyped(BotCommandScopeType.AllChatAdministrators)]
    public class BotCommandScopeAllChatAdministrators : BotCommandScope
    {
        public BotCommandScopeAllChatAdministrators() : base(BotCommandScopeType.AllChatAdministrators) { }

        public override string ToString() => nameof(BotCommandScopeAllChatAdministrators);
    }
}
