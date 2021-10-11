using System.ComponentModel.DataAnnotations;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Provides options to be used with <see cref="TelegramBot"/>.
    /// </summary>
    public class TelegramBotOptions
    {
        /// <summary>
        /// Default section in the config file with this options.
        /// </summary>
        public const string Position = "TelegramBot";

        /// <summary>
        /// Url of the Telegram Bot API without the <see cref="Token">bot token</see>.
        /// </summary>
        [Required]
        [Url]
        public string API { get; set; }
        /// <summary>
        /// Each bot is given a unique authentication token when it is created. The token looks something like 123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11.
        /// You can learn about obtaining tokens and generating new ones in <see href="https://core.telegram.org/bots#6-botfather">this document</see>.
        /// </summary>
        [Required]
        [RegularExpression("^\\d+:[^/]+$", ErrorMessage = "Token was not valid. See https://core.telegram.org/bots/api#authorizing-your-bot for more information.")]
        public string Token { get; set; }
    }
}
