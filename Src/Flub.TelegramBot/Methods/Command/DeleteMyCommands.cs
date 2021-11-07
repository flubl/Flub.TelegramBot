using Flub.TelegramBot.Types;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to delete the list of the bot's commands for the given scope and user language.
    /// After deletion, higher level commands will be shown to affected users.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class DeleteMyCommands : Method<bool?>
    {
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
        /// Initializes a new instance of the <see cref="DeleteMyCommands"/> class.
        /// </summary>
        public DeleteMyCommands() : base("deleteMyCommands") { }
    }

    public static class DeleteMyCommandsExtension
    {
        private static Task<bool?> DeleteMyCommands(this TelegramBot bot, DeleteMyCommands method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to delete the list of the bot's commands for the given scope and user language.
        /// After deletion, higher level commands will be shown to affected users.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="scope">A <see cref="BotCommandScope"/> object, describing scope of users for which the commands are relevant. Defaults to <see cref="BotCommandScopeDefault"/>.</param>
        /// <param name="languageCode">A two-letter ISO 639-1 language code. If empty, commands will be applied to all users from the given scope, for whose language there are no dedicated commands.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteMyCommands(this TelegramBot bot,
            BotCommandScope scope = null,
            string languageCode = null,
            CancellationToken cancellationToken = default) =>
            DeleteMyCommands(bot, new()
            {
                Scope = scope,
                LanguageCode = languageCode
            }, cancellationToken);
    }
}
