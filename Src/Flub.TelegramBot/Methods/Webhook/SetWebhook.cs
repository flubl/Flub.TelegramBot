using Flub.TelegramBot.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to specify a url and receive incoming updates via an outgoing webhook. Whenever there is an update for the bot,
    /// Telegram will send an HTTPS POST request to the specified url, containing a JSON-serialized Update. In case of an unsuccessful request,
    /// Telegram will give up after a reasonable amount of attempts. Returns <see cref="true"/> on success.
    /// If you'd like to make sure that the Webhook request comes from Telegram, Telegram recommends using a secret path in the URL,
    /// e.g. https://www.example.com/<token>. Since nobody else knows your bot's token, you can be pretty sure it's Telegram.
    /// Use <see cref="DeleteWebhook"/> to remove webhook integration.
    /// </summary>
    public class SetWebhook : MethodUpload<bool>
    {
        /// <summary>
        /// HTTPS url to send updates to.
        /// </summary>
        [Required]
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// Upload your public key certificate so that the root certificate in use can be checked.
        /// See the <see href="https://core.telegram.org/bots/self-signed">self-signed guide</see> for details.
        /// </summary>
        [JsonPropertyName("certificate")]
        public InputFile Certificate { get; set; }
        /// <summary>
        /// The fixed IP address which will be used to send webhook requests instead of the IP address resolved through DNS.
        /// </summary>
        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }
        /// <summary>
        /// Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery, 1-100.
        /// Defaults to 40. Use lower values to limit the load on your bot's server, and higher values to increase your bot's throughput.
        /// </summary>
        [JsonPropertyName("max_connections")]
        public int? MaxConnections { get; set; }
        /// <summary>
        /// A list of the update types you want your bot to receive.
        /// Specify an empty list to receive all update types except <see cref="UpdateType.ChatMember"/> (default).
        /// If not specified, the previous setting will be used.
        /// Please note that this parameter doesn't affect updates created before the call to the <see cref="SetWebhook"/>,
        /// so unwanted updates may be received for a short period of time.
        /// </summary>
        [JsonPropertyName("allowed_updates")]
        public IEnumerable<UpdateType> AllowedUpdates { get; set; }
        /// <summary>
        /// Pass <see cref="true"/> to drop all pending updates.
        /// </summary>
        [JsonPropertyName("drop_pending_updates")]
        public bool? DropPendingUpdates { get; set; }

        protected override IEnumerable<InputFile> Files { get { yield return Certificate; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetWebhook"/> class.
        /// </summary>
        public SetWebhook() : base("setWebhook") { }

    }

    public static class SetWebhookExtension
    {
        private static Task<bool> SetWebhook(this TelegramBot bot, SetWebhook method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to specify a url and receive incoming updates via an outgoing webhook. Whenever there is an update for the bot,
        /// Telegram will send an HTTPS POST request to the specified url, containing a JSON-serialized Update. In case of an unsuccessful request,
        /// Telegram will give up after a reasonable amount of attempts. Returns <see cref="true"/> on success.
        /// If you'd like to make sure that the Webhook request comes from Telegram, Telegram recommends using a secret path in the URL,
        /// e.g. https://www.example.com/{token}. Since nobody else knows your bot's token, you can be pretty sure it's Telegram.
        /// Use <see cref="DeleteWebhook"/> to remove webhook integration.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="url">HTTPS url to send updates to.</param>
        /// <param name="certificate">
        /// Upload your public key certificate so that the root certificate in use can be checked.
        /// See the <see href="https://core.telegram.org/bots/self-signed">self-signed guide</see> for details.
        /// </param>
        /// <param name="ipAddress">The fixed IP address which will be used to send webhook requests instead of the IP address resolved through DNS.</param>
        /// <param name="maxConnections">
        /// Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery, 1-100.
        /// Defaults to 40. Use lower values to limit the load on your bot's server, and higher values to increase your bot's throughput.
        /// </param>
        /// <param name="allowedUpdates">
        /// A list of the update types you want your bot to receive.
        /// Specify an empty list to receive all update types except <see cref="UpdateType.ChatMember"/> (default).
        /// If not specified, the previous setting will be used.
        /// Please note that this parameter doesn't affect updates created before the call to the <see cref="SetWebhook"/>,
        /// so unwanted updates may be received for a short period of time.
        /// </param>
        /// <param name="dropPendingUpdates">Pass <see cref="true"/> to drop all pending updates.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool> SetWebhook(this TelegramBot bot,
            Uri url,
            InputFile certificate = null,
            string ipAddress = null,
            int? maxConnections = null,
            IEnumerable<UpdateType> allowedUpdates = null,
            bool? dropPendingUpdates = null,
            CancellationToken cancellationToken = default) => SetWebhook(bot, new()
            {
                Url = url,
                Certificate = certificate,
                IpAddress = ipAddress,
                MaxConnections = maxConnections,
                AllowedUpdates = allowedUpdates,
                DropPendingUpdates = dropPendingUpdates
            }, cancellationToken);
    }
}
