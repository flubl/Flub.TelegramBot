using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to edit text and game messages.
    /// On success, if the edited message is not an inline message, the edited <see cref="Message"/> is returned, otherwise <see cref="true"/> is returned.
    /// </summary>
    public class EditMessageText<TResult> : Method<TResult>
    {
        /// <summary>
        /// New text of the message, 1-4096 characters after entities parsing.
        /// </summary>
        [Required]
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("parse_mode")]
        public ParseMode? ParseMode { get; set; }
        /// <summary>
        /// A list of special entities that appear in message text, which can be specified instead of <see cref="ParseMode"/>.
        /// </summary>
        [JsonPropertyName("entities")]
        public IEnumerable<MessageEntity> Entities { get; set; }
        /// <summary>
        /// Disables link previews for links in this message.
        /// </summary>
        [JsonPropertyName("disable_web_page_preview")]
        public bool? DisableWebPagePreview { get; set; }
        /// <summary>
        /// A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditMessageText{TResult}"/> class.
        /// </summary>
        public EditMessageText() : base("editMessageText") { }
    }

    /// <summary>
    /// Use this method to edit text and game messages.
    /// On success, the edited <see cref="Message"/> is returned.
    /// </summary>
    public class EditMessageText : EditMessageText<Message>
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
    /// Use this method to edit text and game messages.
    /// On success, <see cref="true"/> is returned.
    /// </summary>
    public class EditInlineMessageText : EditMessageText<bool?>
    {
        /// <summary>
        /// Identifier of the inline message.
        /// </summary>
        [Required]
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
    }

    public static class EditMessageTextExtension
    {
        private static Task<TResult> EditMessageText<TResult>(this TelegramBot bot, EditMessageText<TResult> method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to edit text and game messages.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the message to edit.</param>
        /// <param name="text">New text of the message, 1-4096 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="entities">A list of special entities that appear in message text, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageText(this TelegramBot bot,
            string chatId,
            long? messageId,
            string text,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> entities = null,
            bool? disableWebPagePreview = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageText(bot, new EditMessageText
            {
                ChatId = chatId,
                MessageId = messageId,
                Text = text,
                ParseMode = parseMode,
                Entities = entities,
                DisableWebPagePreview = disableWebPagePreview,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit text and game messages.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to edit.</param>
        /// <param name="text">New text of the message, 1-4096 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="entities">A list of special entities that appear in message text, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageText(this TelegramBot bot,
            IChat chat,
            IMessage message,
            string text,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> entities = null,
            bool? disableWebPagePreview = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageText(bot, new EditMessageText
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                Text = text,
                ParseMode = parseMode,
                Entities = entities,
                DisableWebPagePreview = disableWebPagePreview,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit text and game messages.
        /// On success, <see cref="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessageId">Identifier of the inline message.</param>
        /// <param name="text">New text of the message, 1-4096 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="entities">A list of special entities that appear in message text, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageText(this TelegramBot bot,
            string inlineMessageId,
            string text,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> entities = null,
            bool? disableWebPagePreview = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageText(bot, new EditInlineMessageText
            {
                InlineMessageId = inlineMessageId,
                Text = text,
                ParseMode = parseMode,
                Entities = entities,
                DisableWebPagePreview = disableWebPagePreview,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit text and game messages.
        /// On success, <see cref="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="text">New text of the message, 1-4096 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="entities">A list of special entities that appear in message text, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageText(this TelegramBot bot,
            IInlineMessage inlineMessage,
            string text,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> entities = null,
            bool? disableWebPagePreview = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageText(bot, new EditInlineMessageText
            {
                InlineMessageId = inlineMessage?.InlineMessageId,
                Text = text,
                ParseMode = parseMode,
                Entities = entities,
                DisableWebPagePreview = disableWebPagePreview,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
