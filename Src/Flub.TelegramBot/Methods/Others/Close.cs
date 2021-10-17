using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to close the bot instance before moving it from one local server to another.
    /// You need to delete the webhook before calling this method to ensure that the bot isn't launched again after server restart.
    /// The method will return error 429 in the first 10 minutes after the bot is launched.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class Close : Method<bool?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Close"/> class.
        /// </summary>
        public Close() : base("close") { }
    }

    public static class CloseMeExtension
    {
        private static Task<bool?> Close(this TelegramBot bot, Close method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to close the bot instance before moving it from one local server to another.
        /// You need to delete the webhook before calling this method to ensure that the bot isn't launched again after server restart.
        /// The method will return error 429 in the first 10 minutes after the bot is launched.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> Close(this TelegramBot bot, CancellationToken cancellationToken = default) =>
            Close(bot, new(), cancellationToken);
    }
}
