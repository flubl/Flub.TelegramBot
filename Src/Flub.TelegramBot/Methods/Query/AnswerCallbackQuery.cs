using Flub.TelegramBot.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send an answer to a <see cref="CallbackQuery"/> sent from <see cref="InlineKeyboardMarkup"/>.
    /// The answer will be displayed to the user as a notification at the top of the chat screen or as an alert.
    /// On success, <see cref="true"/> is returned.
    /// </summary>
    public class AnswerCallbackQuery : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the query to be answered.
        /// </summary>
        [Required]
        [JsonPropertyName("callback_query_id")]
        public string CallbackQueryId { get; set; }
        /// <summary>
        /// Text of the notification. If not specified, nothing will be shown to the user, 0-200 characters.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// If <see cref="true"/>, an alert will be shown by the client instead of a notification at the top of the chat screen. Defaults to <see cref="false"/>.
        /// </summary>
        [JsonPropertyName("show_alert")]
        public bool? ShowAlert { get; set; }
        /// <summary>
        /// URL that will be opened by the user's client.
        /// If you have created a Game and accepted the conditions via @Botfather, specify the URL that opens your game
        /// — note that this will only work if the query comes from a callback_game button.
        /// Otherwise, you may use links like t.me/your_bot?start=XXXX that open your bot with a parameter.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// The maximum amount of time in seconds that the result of the callback query may be cached client-side.
        /// Telegram apps will support caching starting in version 3.14. Defaults to 0.
        /// </summary>
        [JsonPropertyName("cache_time")]
        public int? CacheTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerCallbackQuery"/> class.
        /// </summary>
        public AnswerCallbackQuery() : base("answerCallbackQuery") { }
    }

    public static class AnswerCallbackQueryExtension
    {
        private static Task<bool?> AnswerCallbackQuery(this TelegramBot bot, AnswerCallbackQuery method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send an answer to a <see cref="CallbackQuery"/> sent from <see cref="InlineKeyboardMarkup"/>.
        /// The answer will be displayed to the user as a notification at the top of the chat screen or as an alert.
        /// On success, <see cref="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="callbackQueryId">Unique identifier for the query to be answered.</param>
        /// <param name="text">Text of the notification. If not specified, nothing will be shown to the user, 0-200 characters.</param>
        /// <param name="showAlert">If <see cref="true"/>, an alert will be shown by the client instead of a notification at the top of the chat screen. Defaults to <see cref="false"/>.</param>
        /// <param name="url">
        /// URL that will be opened by the user's client.
        /// If you have created a Game and accepted the conditions via @Botfather, specify the URL that opens your game
        /// — note that this will only work if the query comes from a callback_game button.
        /// Otherwise, you may use links like t.me/your_bot?start=XXXX that open your bot with a parameter.
        /// </param>
        /// <param name="cacheTime">
        /// The maximum amount of time in seconds that the result of the callback query may be cached client-side.
        /// Telegram apps will support caching starting in version 3.14. Defaults to 0.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerCallbackQuery(this TelegramBot bot,
            string callbackQueryId,
            string text = null,
            bool? showAlert = null,
            Uri url = null,
            int? cacheTime = null,
            CancellationToken cancellationToken = default) =>
            AnswerCallbackQuery(bot, new()
            {
                CallbackQueryId = callbackQueryId,
                Text = text,
                ShowAlert = showAlert,
                Url = url,
                CacheTime = cacheTime
            }, cancellationToken);

        /// <summary>
        /// Use this method to send an answer to a <see cref="CallbackQuery"/> sent from <see cref="InlineKeyboardMarkup"/>.
        /// The answer will be displayed to the user as a notification at the top of the chat screen or as an alert.
        /// On success, <see cref="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="callbackQuery">The query to be answered.</param>
        /// <param name="text">Text of the notification. If not specified, nothing will be shown to the user, 0-200 characters.</param>
        /// <param name="showAlert">If <see cref="true"/>, an alert will be shown by the client instead of a notification at the top of the chat screen. Defaults to <see cref="false"/>.</param>
        /// <param name="url">
        /// URL that will be opened by the user's client.
        /// If you have created a Game and accepted the conditions via @Botfather, specify the URL that opens your game
        /// — note that this will only work if the query comes from a callback_game button.
        /// Otherwise, you may use links like t.me/your_bot?start=XXXX that open your bot with a parameter.
        /// </param>
        /// <param name="cacheTime">
        /// The maximum amount of time in seconds that the result of the callback query may be cached client-side.
        /// Telegram apps will support caching starting in version 3.14. Defaults to 0.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AnswerCallbackQuery(this TelegramBot bot,
            CallbackQuery callbackQuery,
            string text = null,
            bool? showAlert = null,
            Uri url = null,
            int? cacheTime = null,
            CancellationToken cancellationToken = default) =>
            AnswerCallbackQuery(bot, new()
            {
                CallbackQueryId = callbackQuery?.Id,
                Text = text,
                ShowAlert = showAlert,
                Url = url,
                CacheTime = cacheTime
            }, cancellationToken);
    }
}
