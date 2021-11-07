using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send answers to an inline query.
    /// On success, <see langword="true"/> is returned.
    /// No more than 50 results per query are allowed.
    /// </summary>
    public class AnswerInlineQuery : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the answered query.
        /// </summary>
        [Required]
        [JsonPropertyName("inline_query_id")]
        public string InlineQueryId { get; set; }
        /// <summary>
        /// A <see cref="InlineQueryResult"/> list of results for the inline query.
        /// </summary>
        [Required]
        [JsonPropertyName("results")]
        public IEnumerable<InlineQueryResult> Results { get; set; }
        /// <summary>
        /// The maximum amount of time in seconds that the result of the inline query may be cached on the server. Defaults to 300.
        /// </summary>
        [JsonPropertyName("cache_time")]
        public int? CacheTime { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if results may be cached on the server side only for the user that sent the query.
        /// By default, results may be returned to any user who sends the same query.
        /// </summary>
        [JsonPropertyName("is_personal")]
        public bool? IsPersonal { get; set; }
        /// <summary>
        /// Pass the offset that a client should send in the next query with the same text to receive more results.
        /// Pass an empty <see cref="string"/> if there are no more results or if you don't support pagination. Offset length can't exceed 64 bytes.
        /// </summary>
        [JsonPropertyName("next_offset")]
        public string NextOffset { get; set; }
        /// <summary>
        /// If passed, clients will display a button with specified text that switches the user to a private chat
        /// with the bot and sends the bot a start message with the parameter <see cref="SwitchPmText"/>.
        /// </summary>
        [JsonPropertyName("switch_pm_text")]
        public string SwitchPmText { get; set; }
        /// <summary>
        /// Deep-linking parameter for the /start message sent to the bot when user presses the switch button. 1-64 characters, only A-Z, a-z, 0-9, _ and - are allowed.
        /// </summary>
        [JsonPropertyName("switch_pm_parameter")]
        public string SwitchPmParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerInlineQuery"/> class.
        /// </summary>
        public AnswerInlineQuery() : base("answerInlineQuery") { }
    }

    public static class AnswerInlineQueryExtension
    {
        private static Task<bool?> AnswerInlineQuery(this TelegramBot bot, AnswerInlineQuery method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send answers to an inline query.
        /// On success, <see langword="true"/> is returned.
        /// No more than 50 results per query are allowed.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineQueryId">Unique identifier for the answered query.</param>
        /// <param name="results">A <see cref="InlineQueryResult"/> list of results for the inline query.</param>
        /// <param name="cacheTime">The maximum amount of time in seconds that the result of the inline query may be cached on the server. Defaults to 300.</param>
        /// <param name="isPersonal">
        /// Pass <see langword="true"/>, if results may be cached on the server side only for the user that sent the query.
        /// By default, results may be returned to any user who sends the same query.
        /// </param>
        /// <param name="nextOffset">
        /// Pass the offset that a client should send in the next query with the same text to receive more results.
        /// Pass an empty <see cref="string"/> if there are no more results or if you don't support pagination. Offset length can't exceed 64 bytes.
        /// </param>
        /// <param name="switchPmText">
        /// If passed, clients will display a button with specified text that switches the user to a private chat
        /// with the bot and sends the bot a start message with the parameter <see cref="SwitchPmText"/>.
        /// </param>
        /// <param name="switchPmParameter">Deep-linking parameter for the /start message sent to the bot when user presses the switch button. 1-64 characters, only A-Z, a-z, 0-9, _ and - are allowed.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerInlineQuery(this TelegramBot bot,
            string inlineQueryId,
            IEnumerable<InlineQueryResult> results,
            int? cacheTime = null,
            bool? isPersonal = null,
            string nextOffset = null,
            string switchPmText = null,
            string switchPmParameter = null,
            CancellationToken cancellationToken = default) =>
            AnswerInlineQuery(bot, new()
            {
                InlineQueryId = inlineQueryId,
                Results = results,
                CacheTime = cacheTime,
                IsPersonal = isPersonal,
                NextOffset = nextOffset,
                SwitchPmText = switchPmText,
                SwitchPmParameter = switchPmParameter
            }, cancellationToken);

        /// <summary>
        /// Use this method to send answers to an inline query.
        /// On success, <see langword="true"/> is returned.
        /// No more than 50 results per query are allowed.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineQuery">The answered query.</param>
        /// <param name="results">A <see cref="InlineQueryResult"/> list of results for the inline query.</param>
        /// <param name="cacheTime">The maximum amount of time in seconds that the result of the inline query may be cached on the server. Defaults to 300.</param>
        /// <param name="isPersonal">
        /// Pass <see langword="true"/>, if results may be cached on the server side only for the user that sent the query.
        /// By default, results may be returned to any user who sends the same query.
        /// </param>
        /// <param name="nextOffset">
        /// Pass the offset that a client should send in the next query with the same text to receive more results.
        /// Pass an empty <see cref="string"/> if there are no more results or if you don't support pagination. Offset length can't exceed 64 bytes.
        /// </param>
        /// <param name="switchPmText">
        /// If passed, clients will display a button with specified text that switches the user to a private chat
        /// with the bot and sends the bot a start message with the parameter <see cref="SwitchPmText"/>.
        /// </param>
        /// <param name="switchPmParameter">Deep-linking parameter for the /start message sent to the bot when user presses the switch button. 1-64 characters, only A-Z, a-z, 0-9, _ and - are allowed.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerInlineQuery(this TelegramBot bot,
            InlineQuery inlineQuery,
            IEnumerable<InlineQueryResult> results,
            int? cacheTime = null,
            bool? isPersonal = null,
            string nextOffset = null,
            string switchPmText = null,
            string switchPmParameter = null,
            CancellationToken cancellationToken = default) =>
            AnswerInlineQuery(bot, new()
            {
                InlineQueryId = inlineQuery?.Id,
                Results = results,
                CacheTime = cacheTime,
                IsPersonal = isPersonal,
                NextOffset = nextOffset,
                SwitchPmText = switchPmText,
                SwitchPmParameter = switchPmParameter
            }, cancellationToken);
    }
}
