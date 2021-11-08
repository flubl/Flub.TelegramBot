using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to edit only the reply markup of messages.
    /// On success, if the edited message is not an inline message, the edited <see cref="Message"/> is returned, otherwise <see langword="true"/> is returned.
    /// </summary>
    public abstract class EditMessageReplyMarkup<TResult> : Method<TResult>
    {
        /// <summary>
        /// A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditMessageReplyMarkup{TResult}"/> class.
        /// </summary>
        protected EditMessageReplyMarkup() : base("editMessageReplyMarkup") { }
    }

    /// <summary>
    /// Use this method to edit only the reply markup of messages.
    /// On success, the edited <see cref="Message"/> is returned.
    /// </summary>
    public class EditMessageReplyMarkup : EditMessageReplyMarkup<Message>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Identifier of the message to edit.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public long? MessageId { get; set; }
    }

    /// <summary>
    /// Use this method to edit only the reply markup of messages.
    /// On success, <see langword="true"/> is returned.
    /// </summary>
    public class EditInlineMessageReplyMarkup : EditMessageReplyMarkup<bool?>
    {
        /// <summary>
        /// Identifier of the inline message.
        /// </summary>
        [Required]
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
    }

    public static class EditMessageReplyMarkupExtension
    {
        private static Task<TResult> EditMessageReplyMarkup<TResult>(this TelegramBot bot, EditMessageReplyMarkup<TResult> method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to edit only the reply markup of messages.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the message to edit.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageReplyMarkup(this TelegramBot bot,
            string chatId,
            long? messageId,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageReplyMarkup(bot, new EditMessageReplyMarkup
            {
                ChatId = chatId,
                MessageId = messageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit only the reply markup of messages.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to edit.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageReplyMarkup(this TelegramBot bot,
            IChat chat,
            IMessage message,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageReplyMarkup(bot, new EditMessageReplyMarkup
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit only the reply markup of messages.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessageId">Identifier of the inline message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageReplyMarkup(this TelegramBot bot,
            string inlineMessageId = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageReplyMarkup(bot, new EditInlineMessageReplyMarkup
            {
                InlineMessageId = inlineMessageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit only the reply markup of messages.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageReplyMarkup(this TelegramBot bot,
            IInlineMessage inlineMessage = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageReplyMarkup(bot, new EditInlineMessageReplyMarkup
            {
                InlineMessageId = inlineMessage?.InlineMessageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
