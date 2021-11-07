using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send text messages. On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendMessage : SendToChatWithReplyMarkup<Message>
    {
        /// <summary>
        /// Text of the message to be sent, 1-4096 characters after entities parsing.
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
        /// List of special entities that appear in message text, which can be specified instead of <see cref="ParseMode"/>.
        /// </summary>
        [JsonPropertyName("entities")]
        public IEnumerable<MessageEntity> Entities { get; set; }
        /// <summary>
        /// Disables link previews for links in this message.
        /// </summary>
        [JsonPropertyName("disable_web_page_preview")]
        public bool? DisableWebPagePreview { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessage"/> class.
        /// </summary>
        public SendMessage() : base("sendMessage") { }
    }

    public static class SendMessageExtension
    {
        private static Task<Message> SendMessage(this TelegramBot bot, SendMessage method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send text messages. On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="text">Text of the message to be sent, 1-4096 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="entities">List of special entities that appear in message text, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendMessage(this TelegramBot bot,
            string chatId,
            string text,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> entities = null,
            bool? disableWebPagePreview = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) => SendMessage(bot, new()
            {
                ChatId = chatId,
                Text = text,
                ParseMode = parseMode,
                Entities = entities,
                DisableWebPagePreview = disableWebPagePreview,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send text messages. On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="text">Text of the message to be sent, 1-4096 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the message text. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="entities">List of special entities that appear in message text, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableWebPagePreview">Disables link previews for links in this message.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessage">If the message is a reply, the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendMessage(this TelegramBot bot,
            IChat chat,
            string text,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> entities = null,
            bool? disableWebPagePreview = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) => SendMessage(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Text = text,
                ParseMode = parseMode,
                Entities = entities,
                DisableWebPagePreview = disableWebPagePreview,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
