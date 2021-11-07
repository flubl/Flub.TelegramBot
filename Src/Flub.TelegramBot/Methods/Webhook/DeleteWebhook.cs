using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to remove webhook integration if you decide to switch back to <see cref="GetUpdates"/>. Returns <see langword="true"/> on success.
    /// </summary>
    public class DeleteWebhook : Method<bool?>
    {
        /// <summary>
        /// Pass <see langword="true"/> to drop all pending updates.
        /// </summary>
        [JsonPropertyName("drop_pending_updates")]
        public bool? DropPendingUpdates { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWebhook"/> class.
        /// </summary>
        public DeleteWebhook() : base("deleteWebhook") { }
    }

    public static class DeleteWebhookExtension
    {
        private static Task<bool?> DeleteWebhook(this TelegramBot bot, DeleteWebhook method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to remove webhook integration if you decide to switch back to <see cref="GetUpdates"/>. Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="dropPendingUpdates">Pass <see langword="true"/> to drop all pending updates.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteWebhook(this TelegramBot bot,
            bool? dropPendingUpdates = null,
            CancellationToken cancellationToken = default) =>
            DeleteWebhook(bot, new DeleteWebhook
            {
                DropPendingUpdates = dropPendingUpdates
            }, cancellationToken);
    }
}
