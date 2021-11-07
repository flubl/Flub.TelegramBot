using Flub.Utils.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method when you need to tell the user that something is happening on the bot's side.
    /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class SendChatAction : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Type of action to broadcast. Choose one, depending on what the user is about to receive: <see cref="ChatAction.Typing"/> for text messages,
        /// <see cref="ChatAction.UploadPhoto"/> for photos, <see cref="ChatAction.RecordVideo"/> or <see cref="ChatAction.UploadVideo"/> for videos,
        /// <see cref="ChatAction.RecordVoice"/> or <see cref="ChatAction.UploadVoice"/> for voice notes, <see cref="ChatAction.UploadDocument"/> for general files,
        /// <see cref="ChatAction.FindLocation"/> for location data, <see cref="ChatAction.RecordVideoNote"/> or <see cref="ChatAction.UploadVideoNote"/> for video notes.
        /// </summary>
        [Required]
        [JsonPropertyName("action")]
        public ChatAction? Action { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendChatAction"/> class.
        /// </summary>
        public SendChatAction() : base("sendChatAction") { }
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum ChatAction : int
    {
        [JsonIgnore]
        None = 0,
        [JsonFieldValue("typing")]
        Typing = 0x1,
        [JsonFieldValue("upload_photo")]
        UploadPhoto = 0x2,
        [JsonFieldValue("record_video")]
        RecordVideo = 0x4,
        [JsonFieldValue("upload_video")]
        UploadVideo = 0x8,
        [JsonFieldValue("record_voice")]
        RecordVoice = 0x10,
        [JsonFieldValue("upload_voice")]
        UploadVoice = 0x20,
        [JsonFieldValue("upload_document")]
        UploadDocument = 0x40,
        [JsonFieldValue("find_location")]
        FindLocation = 0x80,
        [JsonFieldValue("record_video_note")]
        RecordVideoNote = 0x100,
        [JsonFieldValue("upload_video_note")]
        UploadVideoNote = 0x200
    }

    public static class SendChatActionExtension
    {
        private static Task<bool?> SendChatAction(this TelegramBot bot, SendChatAction method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method when you need to tell the user that something is happening on the bot's side.
        /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="action">
        /// Type of action to broadcast. Choose one, depending on what the user is about to receive: <see cref="ChatAction.Typing"/> for text messages,
        /// <see cref="ChatAction.UploadPhoto"/> for photos, <see cref="ChatAction.RecordVideo"/> or <see cref="ChatAction.UploadVideo"/> for videos,
        /// <see cref="ChatAction.RecordVoice"/> or <see cref="ChatAction.UploadVoice"/> for voice notes, <see cref="ChatAction.UploadDocument"/> for general files,
        /// <see cref="ChatAction.FindLocation"/> for location data, <see cref="ChatAction.RecordVideoNote"/> or <see cref="ChatAction.UploadVideoNote"/> for video notes.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SendChatAction(this TelegramBot bot,
            string chatId,
            ChatAction? action,
            CancellationToken cancellationToken = default) =>
            SendChatAction(bot, new()
            {
                ChatId = chatId,
                Action = action
            }, cancellationToken);

        /// <summary>
        /// Use this method when you need to tell the user that something is happening on the bot's side.
        /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="action">
        /// Type of action to broadcast. Choose one, depending on what the user is about to receive: <see cref="ChatAction.Typing"/> for text messages,
        /// <see cref="ChatAction.UploadPhoto"/> for photos, <see cref="ChatAction.RecordVideo"/> or <see cref="ChatAction.UploadVideo"/> for videos,
        /// <see cref="ChatAction.RecordVoice"/> or <see cref="ChatAction.UploadVoice"/> for voice notes, <see cref="ChatAction.UploadDocument"/> for general files,
        /// <see cref="ChatAction.FindLocation"/> for location data, <see cref="ChatAction.RecordVideoNote"/> or <see cref="ChatAction.UploadVideoNote"/> for video notes.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SendChatAction(this TelegramBot bot,
            IChat chat,
            ChatAction? action,
            CancellationToken cancellationToken = default) =>
            SendChatAction(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Action = action
            }, cancellationToken);
    }
}
