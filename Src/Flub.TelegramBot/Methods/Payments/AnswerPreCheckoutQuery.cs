using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Once the user has confirmed their payment and shipping details,
    /// the Bot API sends the final confirmation in the form of an <see cref="Update"/> with the property <see cref="Update.PreCheckoutQuery"/>.
    /// Use this method to respond to such pre-checkout queries.
    /// On success, <see langword="true"/> is returned. Note: The Bot API must receive an answer within 10 seconds after the pre-checkout query was sent.
    /// </summary>
    public class AnswerPreCheckoutQuery : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the query to be answered.
        /// </summary>
        [Required]
        [JsonPropertyName("pre_checkout_query_id")]
        public string PreCheckoutQueryId { get; set; }
        /// <summary>
        /// Specify <see langword="true"/> if everything is alright (goods are available, etc.) and the bot is ready to proceed with the order.
        /// Use <see langword="false"/> if there are any problems.
        /// </summary>
        [Required]
        [JsonPropertyName("ok")]
        public bool? Ok { get; set; }
        /// <summary>
        /// Required if ok is <see langword="false"/>.
        /// Error message in human readable form that explains the reason for failure to proceed with the checkout
        /// (e.g. "Sorry, somebody just bought the last of our amazing black T-shirts while you were busy filling out your payment details. Please choose a different color or garment!").
        /// Telegram will display this message to the user.
        /// </summary>
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerPreCheckoutQuery"/> class.
        /// </summary>
        public AnswerPreCheckoutQuery() : base("answerPreCheckoutQuery") { }
    }

    public static class AnswerPreCheckoutQueryExtension
    {
        private static Task<bool?> AnswerPreCheckoutQuery(this TelegramBot bot, AnswerPreCheckoutQuery method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Once the user has confirmed their payment and shipping details,
        /// the Bot API sends the final confirmation in the form of an <see cref="Update"/> with the property <see cref="Update.PreCheckoutQuery"/>.
        /// Use this method to respond to such pre-checkout queries.
        /// On success, <see langword="true"/> is returned. Note: The Bot API must receive an answer within 10 seconds after the pre-checkout query was sent.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="preCheckoutQueryId">Unique identifier for the query to be answered.</param>
        /// <param name="ok">
        /// Specify <see langword="true"/> if everything is alright (goods are available, etc.) and the bot is ready to proceed with the order.
        /// Use <see langword="false"/> if there are any problems.
        /// </param>
        /// <param name="errorMessage">
        /// Required if ok is <see langword="false"/>.
        /// Error message in human readable form that explains the reason for failure to proceed with the checkout
        /// (e.g. "Sorry, somebody just bought the last of our amazing black T-shirts while you were busy filling out your payment details. Please choose a different color or garment!").
        /// Telegram will display this message to the user.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerPreCheckoutQuery(this TelegramBot bot,
            string preCheckoutQueryId,
            bool? ok,
            string errorMessage = null,
            CancellationToken cancellationToken = default) =>
            AnswerPreCheckoutQuery(bot, new AnswerPreCheckoutQuery
            {
                PreCheckoutQueryId = preCheckoutQueryId,
                Ok = ok,
                ErrorMessage = errorMessage
            }, cancellationToken);

        /// <summary>
        /// Once the user has confirmed their payment and shipping details,
        /// the Bot API sends the final confirmation in the form of an <see cref="Update"/> with the property <see cref="Update.PreCheckoutQuery"/>.
        /// Use this method to respond to such pre-checkout queries.
        /// On success, <see langword="true"/> is returned. Note: The Bot API must receive an answer within 10 seconds after the pre-checkout query was sent.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="preCheckoutQueryId">Unique identifier for the query to be answered.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerPreCheckoutQuery(this TelegramBot bot,
            string preCheckoutQueryId,
            CancellationToken cancellationToken = default) =>
            AnswerPreCheckoutQuery(bot, new AnswerPreCheckoutQuery
            {
                PreCheckoutQueryId = preCheckoutQueryId,
                Ok = true
            }, cancellationToken);

        /// <summary>
        /// Once the user has confirmed their payment and shipping details,
        /// the Bot API sends the final confirmation in the form of an <see cref="Update"/> with the property <see cref="Update.PreCheckoutQuery"/>.
        /// Use this method to respond to such pre-checkout queries.
        /// On success, <see langword="true"/> is returned. Note: The Bot API must receive an answer within 10 seconds after the pre-checkout query was sent.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="preCheckoutQueryId">Unique identifier for the query to be answered.</param>
        /// <param name="errorMessage">
        /// Error message in human readable form that explains the reason for failure to proceed with the checkout
        /// (e.g. "Sorry, somebody just bought the last of our amazing black T-shirts while you were busy filling out your payment details. Please choose a different color or garment!").
        /// Telegram will display this message to the user.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerPreCheckoutQuery(this TelegramBot bot,
            string preCheckoutQueryId,
            string errorMessage,
            CancellationToken cancellationToken = default) =>
            AnswerPreCheckoutQuery(bot, new AnswerPreCheckoutQuery
            {
                PreCheckoutQueryId = preCheckoutQueryId,
                Ok = false,
                ErrorMessage = errorMessage
            }, cancellationToken);
    }
}
