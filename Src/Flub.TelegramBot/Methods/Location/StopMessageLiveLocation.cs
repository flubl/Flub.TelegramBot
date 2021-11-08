using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to stop updating a live location message before <see cref="Location.LivePeriod"/> expires.
    /// On success, if the message is not an inline message, the edited <see cref="Message"/> is returned, otherwise <see langword="true"/> is returned.
    /// </summary>
    public abstract class StopMessageLiveLocation<TResult> : Method<TResult>
    {
        /// <summary>
        /// A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StopMessageLiveLocation{TResult}"/> class.
        /// </summary>
        protected StopMessageLiveLocation() : base("stopMessageLiveLocation") { }
    }

    /// <summary>
    /// Use this method to stop updating a live location message before <see cref="Location.LivePeriod"/> expires.
    /// On success, the edited <see cref="Message"/> is returned.
    /// </summary>
    public class StopMessageLiveLocation : StopMessageLiveLocation<Message>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Identifier of the message with live location to stop.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public long? MessageId { get; set; }
    }

    /// <summary>
    /// Use this method to stop updating a live location message before <see cref="Location.LivePeriod"/> expires.
    /// On success, <see langword="true"/> is returned.
    /// </summary>
    public class StopInlineMessageLiveLocation : StopMessageLiveLocation<bool?>
    {
        /// <summary>
        /// Identifier of the inline message.
        /// </summary>
        [Required]
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
    }

    public static class StopMessageLiveLocationExtension
    {
        private static Task<TResult> StopMessageLiveLocation<TResult>(this TelegramBot bot, StopMessageLiveLocation<TResult> method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to stop updating a live location message before <see cref="Location.LivePeriod"/> expires.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the message with live location to stop.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> StopMessageLiveLocation(this TelegramBot bot,
            string chatId,
            long? messageId,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            StopMessageLiveLocation(bot, new StopMessageLiveLocation
            {
                ChatId = chatId,
                MessageId = messageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to stop updating a live location message before <see cref="Location.LivePeriod"/> expires.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message with live location to stop.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> StopMessageLiveLocation(this TelegramBot bot,
            IChat chat,
            IMessage message,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            StopMessageLiveLocation(bot, new StopMessageLiveLocation
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to stop updating a live location message before <see cref="Location.LivePeriod"/> expires.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessageId">Identifier of the inline message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> StopMessageLiveLocation(this TelegramBot bot,
            string inlineMessageId,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            StopMessageLiveLocation(bot, new StopInlineMessageLiveLocation
            {
                InlineMessageId = inlineMessageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to stop updating a live location message before <see cref="Location.LivePeriod"/> expires.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> StopMessageLiveLocation(this TelegramBot bot,
            IInlineMessage inlineMessage,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            StopMessageLiveLocation(bot, new StopInlineMessageLiveLocation
            {
                InlineMessageId = inlineMessage?.InlineMessageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
