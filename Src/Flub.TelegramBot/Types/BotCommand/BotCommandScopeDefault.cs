using Flub.Utils.Json;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the default scope of bot commands. Default commands are used if no commands with a narrower scope are specified for the user.
    /// </summary>
    [JsonTyped(BotCommandScopeType.Default)]
    public class BotCommandScopeDefault : BotCommandScope
    {
        public BotCommandScopeDefault()
            : base(BotCommandScopeType.Default)
        {

        }
    }
}
