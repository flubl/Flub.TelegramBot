using Flub.Utils.Json;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the scope of bot commands, covering all group and supergroup chats.
    /// </summary>
    [JsonTyped(BotCommandScopeType.AllGroupChats)]
    public class BotCommandScopeAllGroupChats : BotCommandScope
    {
        public BotCommandScopeAllGroupChats() : base(BotCommandScopeType.AllGroupChats) { }

        public override string ToString() => nameof(BotCommandScopeAllGroupChats);
    }
}
