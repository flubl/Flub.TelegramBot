using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to log out from the cloud Bot API server before launching the bot locally.
    /// You must log out the bot before running it locally, otherwise there is no guarantee that the bot will receive updates.
    /// After a successful call, you can immediately log in on a local server, but will not be able to log in back to the cloud Bot API server for 10 minutes.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class LogOut : Method<bool?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogOut"/> class.
        /// </summary>
        public LogOut() : base("logOut") { }
    }

    public static class LogOutExtension
    {
        private static Task<bool?> LogOut(this TelegramBot bot, LogOut method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to log out from the cloud Bot API server before launching the bot locally.
        /// You must log out the bot before running it locally, otherwise there is no guarantee that the bot will receive updates.
        /// After a successful call, you can immediately log in on a local server, but will not be able to log in back to the cloud Bot API server for 10 minutes.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> LogOut(this TelegramBot bot, CancellationToken cancellationToken = default) =>
            LogOut(bot, new(), cancellationToken);
    }
}
