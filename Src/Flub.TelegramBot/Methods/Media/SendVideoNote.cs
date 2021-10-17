using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// As of v.4.0, Telegram clients support rounded square mp4 videos of up to 1 minute long.
    /// Use this method to send video messages.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendVideoNote : SendMediaWithThumb<Message>
    {
        /// <summary>
        /// Video note to send.
        /// Pass a file_id as <see cref="string"/> or <see cref="VideoNote"/> (<see cref="FileBase"/>) to send a video note that exists on the Telegram servers (recommended)
        /// or upload a new video using <see cref="InputFile"/>.
        /// Sending video notes by a URL is currently unsupported.
        /// </summary>
        [Required]
        [JsonPropertyName("video_note")]
        public override InputFile File { get; set; }
        /// <summary>
        /// Duration of sent video in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
        /// <summary>
        /// Video width and height, i.e. diameter of the video message.
        /// </summary>
        [JsonPropertyName("length")]
        public int? Length { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendVideoNote"/> class.
        /// </summary>
        public SendVideoNote() : base("sendVideoNote") { }
    }

    public static class SendVideoNoteExtension
    {
        private static Task<Message> SendVideoNote(this TelegramBot bot, SendVideoNote method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// As of v.4.0, Telegram clients support rounded square mp4 videos of up to 1 minute long.
        /// Use this method to send video messages.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="videoNote">
        /// Video note to send.
        /// Pass a file_id as <see cref="string"/> or <see cref="VideoNote"/> (<see cref="FileBase"/>) to send a video note that exists on the Telegram servers (recommended)
        /// or upload a new video using <see cref="InputFile"/>.
        /// Sending video notes by a URL is currently unsupported.
        /// </param>
        /// <param name="duration">Duration of sent video in seconds.</param>
        /// <param name="length">Video width and height, i.e. diameter of the video message.</param>
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
        public static Task<Message> SendVideoNote(this TelegramBot bot,
            string chatId,
            InputFile videoNote,
            int? duration = null,
            int? length = null,
            InputFile thumb = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendVideoNote(bot, new()
            {
                ChatId = chatId,
                File = videoNote,
                Duration = duration,
                Length = length,
                Thumb = thumb,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// As of v.4.0, Telegram clients support rounded square mp4 videos of up to 1 minute long.
        /// Use this method to send video messages.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="videoNote">
        /// Video note to send.
        /// Pass a file_id as <see cref="string"/> or <see cref="VideoNote"/> (<see cref="FileBase"/>) to send a video note that exists on the Telegram servers (recommended)
        /// or upload a new video using <see cref="InputFile"/>.
        /// Sending video notes by a URL is currently unsupported.
        /// </param>
        /// <param name="duration">Duration of sent video in seconds.</param>
        /// <param name="length">Video width and height, i.e. diameter of the video message.</param>
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
        public static Task<Message> SendVideoNote(this TelegramBot bot,
            IChat chat,
            InputFile videoNote,
            int? duration = null,
            int? length = null,
            InputFile thumb = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendVideoNote(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                File = videoNote,
                Duration = duration,
                Length = length,
                Thumb = thumb,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
