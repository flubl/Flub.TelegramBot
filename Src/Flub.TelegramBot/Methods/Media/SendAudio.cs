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
    /// Use this method to send audio files, if you want Telegram clients to display them in the music player.
    /// Your audio must be in the .MP3 or .M4A format. On success, the sent <see cref="Message"/> is returned.
    /// Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
    /// For sending voice messages, use the <see cref="SendVoice"/> method instead.
    /// </summary>
    public class SendAudio : SendMediaWithThumb<Message>
    {
        /// <summary>
        /// Audio file to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Audio"/> (<see cref="FileBase"/>) to send an audio file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get an audio file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </summary>
        [Required]
        [JsonPropertyName("audio")]
        public override InputFile File { get; set; }
        /// <summary>
        /// Duration of the audio in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
        /// <summary>
        /// Performer.
        /// </summary>
        [JsonPropertyName("performer")]
        public string Performer { get; set; }
        /// <summary>
        /// Track name.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendAudio"/> class.
        /// </summary>
        public SendAudio() : base("sendAudio") { }
    }

    public static class SendAudioExtension
    {
        private static Task<Message> SendAudio(this TelegramBot bot, SendAudio method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display them in the music player.
        /// Your audio must be in the .MP3 or .M4A format. On success, the sent <see cref="Message"/> is returned.
        /// Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// For sending voice messages, use the <see cref="SendVoice"/> method instead.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="audio">
        /// Audio file to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Audio"/> (<see cref="FileBase"/>) to send an audio file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get an audio file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="caption">Caption, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">List of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="duration">Duration of the audio in seconds.</param>
        /// <param name="performer">Performer.</param>
        /// <param name="title">Track name.</param>
        /// <param name="thumb">
        /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
        /// The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320.
        /// Thumbnails can't be reused and can be only uploaded as a new file.
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
        public static Task<Message> SendAudio(this TelegramBot bot,
            string chatId,
            InputFile audio,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            int? duration = null,
            string performer = null,
            string title = null,
            InputFile thumb = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) => SendAudio(bot, new()
            {
                ChatId = chatId,
                File = audio,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                Duration = duration,
                Performer = performer,
                Title = title,
                Thumb = thumb,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display them in the music player.
        /// Your audio must be in the .MP3 or .M4A format. On success, the sent <see cref="Message"/> is returned.
        /// Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// For sending voice messages, use the <see cref="SendVoice"/> method instead.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="audio">
        /// Audio file to send.
        /// Pass a file id as <see cref="string"/> or <see cref="Audio"/> (<see cref="FileBase"/>) to send an audio file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get an audio file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="caption">Caption, 0-1024 characters after entities parsing.</param>
        /// <param name="parseMode">
        /// Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </param>
        /// <param name="captionEntities">List of special entities that appear in the caption, which can be specified instead of <paramref name="parseMode"/>.</param>
        /// <param name="duration">Duration of the audio in seconds.</param>
        /// <param name="performer">Performer.</param>
        /// <param name="title">Track name.</param>
        /// <param name="thumb">
        /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
        /// The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320.
        /// Thumbnails can't be reused and can be only uploaded as a new file.
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
        public static Task<Message> SendAudio(this TelegramBot bot,
            IChat chat,
            InputFile audio,
            string caption = null,
            ParseMode? parseMode = null,
            IEnumerable<MessageEntity> captionEntities = null,
            int? duration = null,
            string performer = null,
            string title = null,
            InputFile thumb = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) => SendAudio(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                File = audio,
                Caption = caption,
                ParseMode = parseMode,
                CaptionEntities = captionEntities,
                Duration = duration,
                Performer = performer,
                Title = title,
                Thumb = thumb,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
