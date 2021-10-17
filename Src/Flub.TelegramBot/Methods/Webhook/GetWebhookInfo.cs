using Flub.TelegramBot.Types;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get current webhook status. On success, returns a <see cref="WebhookInfo"/> object. 
    /// If the bot is using <see cref="GetUpdates"/>, will return an object with the <see cref="WebhookInfo.Url"/> field empty.
    /// </summary>
    public class GetWebhookInfo : Method<WebhookInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWebhookInfo"/> class.
        /// </summary>
        public GetWebhookInfo() : base("getWebhookInfo") { }
    }

    public static class GetWebhookInfoExtension
    {
        private static Task<WebhookInfo> GetWebhookInfo(this TelegramBot bot, GetWebhookInfo method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get current webhook status. On success, returns a <see cref="WebhookInfo"/> object. 
        /// If the bot is using <see cref="GetUpdates"/>, will return an object with the <see cref="WebhookInfo.Url"/> field empty.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<WebhookInfo> GetWebhookInfo(this TelegramBot bot, CancellationToken cancellationToken = default) =>
            GetWebhookInfo(bot, new(), cancellationToken);
    }
}
