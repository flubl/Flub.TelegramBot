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
    /// Use this method to send general files. On success, the sent <see cref="Message"/> is returned.
    /// Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendDocument : SendMediaWithThumb<Message>
    {
        /// <summary>
        /// File to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Document"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </summary>
        [Required]
        [JsonPropertyName("document")]
        public override InputFile File { get; set; }
        /// <summary>
        /// Disables automatic server-side content type detection for files uploaded using <see cref="InputFile"/>.
        /// </summary>
        [JsonPropertyName("disable_content_type_detection")]
        public bool? DisableContentTypeDetection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendDocument"/> class.
        /// </summary>
        public SendDocument() : base("sendDocument") { }
    }

    public static class SendDocumentExtension
    {
        private static Task<Message> SendDocument(this TelegramBot bot, SendDocument method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send general files. On success, the sent <see cref="Message"/> is returned.
        /// Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="document">
        /// File to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Document"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="thumb">
        /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
        /// The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320.
        /// Thumbnails can't be reused and can be only uploaded as a new file.
        /// </param>
        /// <param name="caption">Caption, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">List of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableContentTypeDetection">Disables automatic server-side content type detection for files uploaded using <see cref="InputFile"/>.</param>
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
        public static Task<Message> SendDocument(this TelegramBot bot,
            string chatId,
            InputFile document,
            InputFile thumb = null,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableContentTypeDetection = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendDocument(bot, new()
            {
                ChatId = chatId,
                File = document,
                Thumb = thumb,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                DisableContentTypeDetection = disableContentTypeDetection,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send general files. On success, the sent <see cref="Message"/> is returned.
        /// Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="document">
        /// File to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Document"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="thumb">
        /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
        /// The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320.
        /// Thumbnails can't be reused and can be only uploaded as a new file.
        /// </param>
        /// <param name="caption">Caption, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">List of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="disableContentTypeDetection">Disables automatic server-side content type detection for files uploaded using <see cref="InputFile"/>.</param>
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
        public static Task<Message> SendDocument(this TelegramBot bot,
            IChat chat,
            InputFile document,
            InputFile thumb = null,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableContentTypeDetection = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendDocument(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                File = document,
                Thumb = thumb,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                DisableContentTypeDetection = disableContentTypeDetection,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
