using Flub.TelegramBot.Types;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get the current list of the bot's commands for the given scope and user language.
    /// Returns Array of <see cref="BotCommand"/> on success. If commands aren't set, an empty list is returned.
    /// </summary>
    public class GetMyCommands : Method<BotCommand>
    {
        /// <summary>
        /// A <see cref="BotCommandScope"/> object, describing scope of users. Defaults to <see cref="BotCommandScopeDefault"/>.
        /// </summary>
        [JsonPropertyName("scope")]
        public BotCommandScope Scope { get; set; }
        /// <summary>
        /// A two-letter ISO 639-1 language code or an empty string.
        /// </summary>
        [JsonPropertyName("language_code")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMyCommands"/> class.
        /// </summary>
        public GetMyCommands() : base("getMyCommands") { }
    }

    public static class GetMyCommandsExtension
    {
        private static Task<BotCommand> GetMyCommands(this TelegramBot bot, GetMyCommands method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get the current list of the bot's commands for the given scope and user language.
        /// Returns Array of <see cref="BotCommand"/> on success. If commands aren't set, an empty list is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="scope">A <see cref="BotCommandScope"/> object, describing scope of users. Defaults to <see cref="BotCommandScopeDefault"/>.</param>
        /// <param name="languageCode">A two-letter ISO 639-1 language code or an empty string.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<BotCommand> GetMyCommands(this TelegramBot bot,
            BotCommandScope scope = null,
            string languageCode = null,
            CancellationToken cancellationToken = default) =>
            GetMyCommands(bot, new()
            {
                Scope = scope,
                LanguageCode = languageCode
            }, cancellationToken);
    }
}
