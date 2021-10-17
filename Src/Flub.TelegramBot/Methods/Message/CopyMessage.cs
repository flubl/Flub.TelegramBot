using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to copy messages of any kind. Service messages and invoice messages can't be copied.
    /// The method is analogous to the method forwardMessage, but the copied message doesn't have a link to the original message.
    /// Returns the <see cref="MessageId"/> of the sent message on success.
    /// </summary>
    public class CopyMessage : SendToChatWithReplyMarkup<MessageId>
    {
        /// <summary>
        /// Unique identifier for the chat where the original message was sent (or channel username in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("from_chat_id")]
        public string FromChatId { get; set; }
        /// <summary>
        /// Message identifier in the chat specified in <see cref="FromChatId"/>.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public int? MessageId { get; set; }
        /// <summary>
        /// New caption for media, 0-1024 characters after entities parsing. If not specified, the original caption is kept.
        /// </summary>
        [JsonPropertyName("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// Mode for parsing entities in the new caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("parse_mode")]
        public ParseMode? ParseMode { get; set; }
        /// <summary>
        /// A list of special entities that appear in the new caption, which can be specified instead of <see cref="ParseMode"/>.
        /// </summary>
        [JsonPropertyName("caption_entities")]
        public IEnumerable<MessageEntity> CaptionEntities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyMessage"/> class.
        /// </summary>
        public CopyMessage() : base("copyMessage") { }
    }

    public static class CopyMessageExtension
    {
        private static Task<MessageId> CopyMessage(this TelegramBot bot, CopyMessage method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to copy messages of any kind. Service messages and invoice messages can't be copied.
        /// The method is analogous to the method forwardMessage, but the copied message doesn't have a link to the original message.
        /// Returns the <see cref="MessageId"/> of the sent message on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="fromChatId">Unique identifier for the chat where the original message was sent (or channel username in the format @channelusername).</param>
        /// <param name="messageId">Message identifier in the chat specified in <paramref name="fromChatId"/>.</param>
        /// <param name="caption">New caption for media, 0-1024 characters after entities parsing. If not specified, the original caption is kept.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the new caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">A list of special entities that appear in the new caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see cref="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<MessageId> CopyMessage(this TelegramBot bot,
            string chatId,
            string fromChatId,
            int? messageId,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            CopyMessage(bot, new()
            {
                ChatId = chatId,
                FromChatId = fromChatId,
                MessageId = messageId,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup,
            }, cancellationToken);

        /// <summary>
        /// Use this method to copy messages of any kind. Service messages and invoice messages can't be copied.
        /// The method is analogous to the method forwardMessage, but the copied message doesn't have a link to the original message.
        /// Returns the <see cref="MessageId"/> of the sent message on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="fromChat">The chat where the original message was sent.</param>
        /// <param name="message">Message in the chat specified in <paramref name="fromChat"/>.</param>
        /// <param name="caption">New caption for media, 0-1024 characters after entities parsing. If not specified, the original caption is kept.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the new caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">A list of special entities that appear in the new caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessage">If the message is a reply, the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see cref="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<MessageId> CopyMessage(this TelegramBot bot,
            IChat chat,
            IChat fromChat,
            IMessage message,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            CopyMessage(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                FromChatId = fromChat?.Id?.ToString(),
                MessageId = message?.Id,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup,
            }, cancellationToken);
    }
}
