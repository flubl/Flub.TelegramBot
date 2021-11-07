using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// If you sent an invoice requesting a shipping address and the property <see cref="SendInvoice.IsFlexible"/> was specified,
    /// the Bot API will send an <see cref="Update"/> with a <see cref="Update.ShippingQuery"/> property to the bot.
    /// Use this method to reply to shipping queries.
    /// On success, <see langword="true"/> is returned.
    /// </summary>
    public class AnswerShippingQuery : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the query to be answered.
        /// </summary>
        [Required]
        [JsonPropertyName("shipping_query_id")]
        public string ShippingQueryId { get; set; }
        /// <summary>
        /// Specify <see langword="true"/> if delivery to the specified address is possible
        /// and <see langword="false"/> if there are any problems (for example, if delivery to the specified address is not possible).
        /// </summary>
        [Required]
        [JsonPropertyName("ok")]
        public bool? Ok { get; set; }
        /// <summary>
        /// Required if ok is <see langword="true"/>. A list of available shipping options.
        /// </summary>
        [JsonPropertyName("shipping_options")]
        public IEnumerable<ShippingOption> ShippingOptions { get; set; }
        /// <summary>
        /// Required if ok is <see langword="false"/>.
        /// Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable').
        /// Telegram will display this message to the user.
        /// </summary>
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerShippingQuery"/> class.
        /// </summary>
        public AnswerShippingQuery() : base("answerShippingQuery") { }
    }

    public static class AnswerShippingQueryExtension
    {
        private static Task<bool?> AnswerShippingQuery(this TelegramBot bot, AnswerShippingQuery method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// If you sent an invoice requesting a shipping address and the property <see cref="SendInvoice.IsFlexible"/> was specified,
        /// the Bot API will send an <see cref="Update"/> with a <see cref="Update.ShippingQuery"/> property to the bot.
        /// Use this method to reply to shipping queries.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="shippingQueryId">Unique identifier for the query to be answered.</param>
        /// <param name="ok">
        /// Specify <see langword="true"/> if delivery to the specified address is possible
        /// and <see langword="false"/> if there are any problems (for example, if delivery to the specified address is not possible).
        /// </param>
        /// <param name="shippingOptions">Required if ok is <see langword="true"/>. A list of available shipping options.</param>
        /// <param name="errorMessage">
        /// Required if ok is <see langword="false"/>.
        /// Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable').
        /// Telegram will display this message to the user.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerShippingQuery(this TelegramBot bot,
            string shippingQueryId,
            bool? ok,
            IEnumerable<ShippingOption> shippingOptions = null,
            string errorMessage = null,
            CancellationToken cancellationToken = default) =>
            AnswerShippingQuery(bot, new()
            {
                ShippingQueryId = shippingQueryId,
                Ok = ok,
                ShippingOptions = shippingOptions,
                ErrorMessage = errorMessage
            }, cancellationToken);

        /// <summary>
        /// If you sent an invoice requesting a shipping address and the property <see cref="SendInvoice.IsFlexible"/> was specified,
        /// the Bot API will send an <see cref="Update"/> with a <see cref="Update.ShippingQuery"/> property to the bot.
        /// Use this method to reply to shipping queries.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="shippingQuery">The query to be answered.</param>
        /// <param name="ok">
        /// Specify <see langword="true"/> if delivery to the specified address is possible
        /// and <see langword="false"/> if there are any problems (for example, if delivery to the specified address is not possible).
        /// </param>
        /// <param name="shippingOptions">Required if ok is <see langword="true"/>. A list of available shipping options.</param>
        /// <param name="errorMessage">
        /// Required if ok is <see langword="false"/>.
        /// Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable').
        /// Telegram will display this message to the user.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerShippingQuery(this TelegramBot bot,
            ShippingQuery shippingQuery,
            bool? ok,
            IEnumerable<ShippingOption> shippingOptions = null,
            string errorMessage = null,
            CancellationToken cancellationToken = default) =>
            AnswerShippingQuery(bot, new()
            {
                ShippingQueryId = shippingQuery.Id,
                Ok = ok,
                ShippingOptions = shippingOptions,
                ErrorMessage = errorMessage
            }, cancellationToken);

        /// <summary>
        /// If you sent an invoice requesting a shipping address and the property <see cref="SendInvoice.IsFlexible"/> was specified,
        /// the Bot API will send an <see cref="Update"/> with a <see cref="Update.ShippingQuery"/> property to the bot.
        /// Use this method to reply to shipping queries.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="shippingQuery">The query to be answered.</param>
        /// <param name="shippingOptions">A list of available shipping options.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerShippingQuery(this TelegramBot bot,
            ShippingQuery shippingQuery,
            IEnumerable<ShippingOption> shippingOptions,
            CancellationToken cancellationToken = default) =>
            AnswerShippingQuery(bot, new()
            {
                ShippingQueryId = shippingQuery.Id,
                Ok = true,
                ShippingOptions = shippingOptions
            }, cancellationToken);

        /// <summary>
        /// If you sent an invoice requesting a shipping address and the property <see cref="SendInvoice.IsFlexible"/> was specified,
        /// the Bot API will send an <see cref="Update"/> with a <see cref="Update.ShippingQuery"/> property to the bot.
        /// Use this method to reply to shipping queries.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="shippingQuery">The query to be answered.</param>
        /// <param name="errorMessage">
        /// Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable').
        /// Telegram will display this message to the user.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerShippingQuery(this TelegramBot bot,
            ShippingQuery shippingQuery,
            string errorMessage,
            CancellationToken cancellationToken = default) =>
            AnswerShippingQuery(bot, new()
            {
                ShippingQueryId = shippingQuery.Id,
                Ok = false,
                ErrorMessage = errorMessage
            }, cancellationToken);
    }
}
