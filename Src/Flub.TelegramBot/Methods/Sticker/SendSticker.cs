using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send static .WEBP or animated .TGS stickers.
    /// On success, the sent Message is returned.
    /// </summary>
    public class SendSticker : SendToChatWithReplyMarkup<Message>, IFileContainer
    {
        /// <summary>
        /// Sticker to send. Pass a file id as <see cref="string"/> or <see cref="Types.Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a .WEBP file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </summary>
        [Required]
        [JsonPropertyName("sticker")]
        public InputFile Sticker { get; set; }

        bool IFileContainer.HasFiles => Sticker?.IsFile ?? false;
        IEnumerable<InputFile> IFileContainer.Files { get { yield return Sticker; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSticker"/> class.
        /// </summary>
        public SendSticker() : base("sendSticker") { }
    }

    public static class SendStickerExtension
    {
        private static Task<Message> SendSticker(this TelegramBot bot, SendSticker method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send static .WEBP or animated .TGS stickers.
        /// On success, the sent Message is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="sticker">
        /// Sticker to send. Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a .WEBP file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
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
        public static Task<Message> SendSticker(this TelegramBot bot,
            string chatId,
            InputFile sticker,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendSticker(bot, new()
            {
                ChatId = chatId,
                Sticker = sticker,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send static .WEBP or animated .TGS stickers.
        /// On success, the sent Message is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="sticker">
        /// Sticker to send. Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a .WEBP file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
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
        public static Task<Message> SendSticker(this TelegramBot bot,
            IChat chat,
            InputFile sticker,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendSticker(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Sticker = sticker,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
