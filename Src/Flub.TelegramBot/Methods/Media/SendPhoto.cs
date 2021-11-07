using Flub.TelegramBot.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send photos. On success, the sent <see cref="Message"/> is returned.
    /// The photo must be at most 10 MB in size. The photo's width and height must not exceed 10000 in total.
    /// Width and height ratio must be at most 20.
    /// </summary>
    public class SendPhoto : SendMedia<Message>
    {
        /// <summary>
        /// Photo to send.
        /// Pass a file id as <see cref="string"/> or <see cref="PhotoSize"/> (<see cref="FileBase"/>) to send a photo that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a photo from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </summary>
        [Required]
        [JsonPropertyName("photo")]
        public override InputFile File { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendPhoto"/> class.
        /// </summary>
        public SendPhoto() : base("sendPhoto") { }
    }

    public static class SendPhotoExtension
    {
        private static Task<Message> SendPhoto(this TelegramBot bot, SendPhoto method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send photos. On success, the sent <see cref="Message"/> is returned.
        /// The photo must be at most 10 MB in size. The photo's width and height must not exceed 10000 in total.
        /// Width and height ratio must be at most 20.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="photo">
        /// Photo to send.
        /// Pass a file id as <see cref="string"/> or <see cref="PhotoSize"/> (<see cref="FileBase"/>) to send a photo that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a photo from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="caption">Caption, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">List of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
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
        public static Task<Message> SendPhoto(this TelegramBot bot,
            string chatId,
            InputFile photo,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) => SendPhoto(bot, new()
            {
                ChatId = chatId,
                File = photo,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send photos. On success, the sent <see cref="Message"/> is returned.
        /// The photo must be at most 10 MB in size. The photo's width and height must not exceed 10000 in total.
        /// Width and height ratio must be at most 20.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="photo">
        /// Photo to send.
        /// Pass a file id as <see cref="string"/> or <see cref="PhotoSize"/> (<see cref="FileBase"/>) to send a photo that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a photo from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="caption">Caption, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">List of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
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
        public static Task<Message> SendPhoto(this TelegramBot bot,
            IChat chat,
            InputFile photo,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) => SendPhoto(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                File = photo,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
