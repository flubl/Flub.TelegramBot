using Flub.TelegramBot.Types;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// A simple method for testing your bot's auth token.
    /// Returns basic information about the bot in form of a <see cref="User"/> object.
    /// </summary>
    public class GetMe : Method<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMe"/> class.
        /// </summary>
        public GetMe() : base("getMe") { }
    }

    public static class GetMeExtension
    {
        private static Task<User> GetMe(this TelegramBot bot, GetMe method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// A simple method for testing your bot's auth token.
        /// Returns basic information about the bot in form of a <see cref="User"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<User> GetMe(this TelegramBot bot, CancellationToken cancellationToken = default) =>
            GetMe(bot, new(), cancellationToken);
    }
}
