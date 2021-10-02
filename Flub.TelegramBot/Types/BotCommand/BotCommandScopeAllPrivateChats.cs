using Flub.Utils.Json;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the scope of bot commands, covering all private chats.
    /// </summary>
    [JsonTyped(BotCommandScopeType.AllPrivateChats)]
    public class BotCommandScopeAllPrivateChats : BotCommandScope
    {
        public BotCommandScopeAllPrivateChats()
            : base(BotCommandScopeType.AllPrivateChats)
        {

        }
    }
}
