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
    /// Use this method to send animation files (GIF or H.264/MPEG-4 AVC video without sound).
    /// On success, the sent <see cref="Message"/> is returned.
    /// Bots can currently send animation files of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendAnimation : SendMediaWithThumb<Message>
    {
        /// <summary>
        /// Animation to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Animation"/> (<see cref="FileBase"/>) to send an animation that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get an animation from the Internet, or upload a new animation using <see cref="InputFile"/>.
        /// </summary>
        [Required]
        [JsonPropertyName("animation")]
        public override InputFile File { get; set; }
        /// <summary>
        /// Duration of sent animation in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
        /// <summary>
        /// Animation width.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        /// <summary>
        /// Animation height.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendAnimation"/> class.
        /// </summary>
        public SendAnimation() : base("sendAnimation") { }
    }

    public static class SendAnimationExtension
    {
        private static Task<Message> SendAnimation(this TelegramBot bot, SendAnimation method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send animation files (GIF or H.264/MPEG-4 AVC video without sound).
        /// On success, the sent <see cref="Message"/> is returned.
        /// Bots can currently send animation files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="animation">
        /// Animation to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Animation"/> (<see cref="FileBase"/>) to send an animation that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get an animation from the Internet, or upload a new animation using <see cref="InputFile"/>.
        /// </param>
        /// <param name="duration">Duration of sent animation in seconds.</param>
        /// <param name="width">Animation width.</param>
        /// <param name="height">Animation height.</param>
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
        public static Task<Message> SendAnimation(this TelegramBot bot,
            string chatId,
            InputFile animation,
            int? duration = null,
            int? width = null,
            int? height = null,
            InputFile thumb = null,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendAnimation(bot, new()
            {
                ChatId = chatId,
                File = animation,
                Duration = duration,
                Width = width,
                Height = height,
                Thumb = thumb,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send animation files (GIF or H.264/MPEG-4 AVC video without sound).
        /// On success, the sent <see cref="Message"/> is returned.
        /// Bots can currently send animation files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="animation">
        /// Animation to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Animation"/> (<see cref="FileBase"/>) to send an animation that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get an animation from the Internet, or upload a new animation using <see cref="InputFile"/>.
        /// </param>
        /// <param name="duration">Duration of sent animation in seconds.</param>
        /// <param name="width">Animation width.</param>
        /// <param name="height">Animation height.</param>
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
        public static Task<Message> SendAnimation(this TelegramBot bot,
            IChat chat,
            InputFile animation,
            int? duration = null,
            int? width = null,
            int? height = null,
            InputFile thumb = null,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendAnimation(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                File = animation,
                Duration = duration,
                Width = width,
                Height = height,
                Thumb = thumb,
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
