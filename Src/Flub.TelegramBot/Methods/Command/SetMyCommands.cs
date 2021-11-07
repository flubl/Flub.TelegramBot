using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to change the list of the bot's commands.
    /// See https://core.telegram.org/bots#commands for more details about bot commands.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class SetMyCommands : Method<bool?>
    {
        /// <summary>
        /// A list of <see cref="BotCommand"/> to be set as the list of the bot's commands. At most 100 commands can be specified.
        /// </summary>
        [Required]
        [JsonPropertyName("commands")]
        public IEnumerable<BotCommand> Commands { get; set; }
        /// <summary>
        /// A <see cref="BotCommandScope"/> object, describing scope of users for which the commands are relevant. Defaults to <see cref="BotCommandScopeDefault"/>.
        /// </summary>
        [JsonPropertyName("scope")]
        public BotCommandScope Scope { get; set; }
        /// <summary>
        /// A two-letter ISO 639-1 language code. If empty, commands will be applied to all users from the given scope, for whose language there are no dedicated commands.
        /// </summary>
        [JsonPropertyName("language_code")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetMyCommands"/> class.
        /// </summary>
        public SetMyCommands() : base("setMyCommands") { }
    }

    public static class SetMyCommandsExtension
    {
        private static Task<bool?> SetMyCommands(this TelegramBot bot, SetMyCommands method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to change the list of the bot's commands.
        /// See https://core.telegram.org/bots#commands for more details about bot commands.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="commands">A list of <see cref="BotCommand"/> to be set as the list of the bot's commands. At most 100 commands can be specified.</param>
        /// <param name="scope">A <see cref="BotCommandScope"/> object, describing scope of users for which the commands are relevant. Defaults to <see cref="BotCommandScopeDefault"/>.</param>
        /// <param name="languageCode">A two-letter ISO 639-1 language code. If empty, commands will be applied to all users from the given scope, for whose language there are no dedicated commands.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetMyCommands(this TelegramBot bot,
            IEnumerable<BotCommand> commands,
            BotCommandScope scope = null,
            string languageCode = null,
            CancellationToken cancellationToken = default) =>
            SetMyCommands(bot, new()
            {
                Commands = commands,
                Scope = scope,
                LanguageCode = languageCode
            }, cancellationToken);
    }
}
