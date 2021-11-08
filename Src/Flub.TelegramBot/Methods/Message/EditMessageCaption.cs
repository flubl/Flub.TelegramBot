using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to edit captions of messages.
    /// On success, if the edited message is not an inline message, the edited <see cref="Message"/> is returned, otherwise <see langword="true"/> is returned.
    /// </summary>
    public abstract class EditMessageCaption<TResult> : Method<TResult>
    {
        /// <summary>
        /// New caption of the message, 0-1024 characters after entities parsing.
        /// </summary>
        [JsonPropertyName("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// Mode for parsing entities in the message caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("parse_mode")]
        public string ParseMode { get; set; }
        /// <summary>
        /// A list of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode"/>.
        /// </summary>
        [JsonPropertyName("caption_entities")]
        public IEnumerable<MessageEntity> CaptionEntities { get; set; }
        /// <summary>
        /// A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditMessageCaption{TResult}"/> class.
        /// </summary>
        protected EditMessageCaption() : base("editMessageCaption") { }
    }

    /// <summary>
    /// Use this method to edit captions of messages.
    /// On success, the edited <see cref="Message"/> is returned.
    /// </summary>
    public class EditMessageCaption : EditMessageCaption<Message>
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
    /// Use this method to edit captions of messages.
    /// On success, <see langword="true"/> is returned.
    /// </summary>
    public class EditInlineMessageCaption : EditMessageCaption<bool?>
    {
        /// <summary>
        /// Identifier of the inline message.
        /// </summary>
        [Required]
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
    }

    public static class EditMessageCaptionExtension
    {
        private static Task<TResult> EditMessageCaption<TResult>(this TelegramBot bot, EditMessageCaption<TResult> method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to edit captions of messages.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the message to edit.</param>
        /// <param name="caption">New caption of the message, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="captionEntities">A list of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageCaption(this TelegramBot bot,
            string chatId,
            long? messageId,
            string caption = null,
            string parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageCaption(bot, new EditMessageCaption
            {
                ChatId = chatId,
                MessageId = messageId,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit captions of messages.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to edit.</param>
        /// <param name="caption">New caption of the message, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="captionEntities">A list of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageCaption(this TelegramBot bot,
            IChat chat,
            IMessage message,
            string caption = null,
            string parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageCaption(bot, new EditMessageCaption
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit captions of messages.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessageId">Identifier of the inline message.</param>
        /// <param name="caption">New caption of the message, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="captionEntities">A list of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageCaption(this TelegramBot bot,
            string inlineMessageId,
            string caption = null,
            string parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageCaption(bot, new EditInlineMessageCaption
            {
                InlineMessageId = inlineMessageId,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit captions of messages.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="caption">New caption of the message, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">Mode for parsing entities in the message caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="captionEntities">A list of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for an inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageCaption(this TelegramBot bot,
            IInlineMessage inlineMessage,
            string caption = null,
            string parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageCaption(bot, new EditInlineMessageCaption
            {
                InlineMessageId = inlineMessage?.InlineMessageId,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
