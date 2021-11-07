using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send a group of photos, videos, documents or audios as an album.
    /// Documents and audio files can be only grouped in an album with messages of the same type.
    /// On success, an list of <see cref="Message"/> that were sent is returned.
    /// </summary>
    public class SendMediaGroup<TInputMedia> : MethodUpload<IEnumerable<Message>> where TInputMedia : InputMedia
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// A list describing messages to be sent, must include 2-10 items.
        /// </summary>
        [Required]
        [JsonPropertyName("media")]
        public IEnumerable<TInputMedia> Media { get; set; }
        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        [JsonPropertyName("disable_notification")]
        public bool? DisableNotification { get; set; }
        /// <summary>
        /// If the message is a reply, ID of the original message.
        /// </summary>
        [JsonPropertyName("reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.
        /// </summary>
        [JsonPropertyName("allow_sending_without_reply")]
        public bool? AllowSendingWithoutReply { get; set; }

        protected override IEnumerable<InputFile> Files =>
            Media?.Select(m => (IFileContainer)m).Where(c => c?.Files is not null).SelectMany(c => c?.Files);

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMediaGroup"/> class.
        /// </summary>
        public SendMediaGroup() : base("sendMediaGroup") { }
    }

    public static class SendMediaGroupExtension
    {
        private static Task<IEnumerable<Message>> SendMediaGroup<TInputMedia>(this TelegramBot bot, SendMediaGroup<TInputMedia> method, CancellationToken cancellationToken = default)
            where TInputMedia : InputMedia => bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send a group of photos, videos, documents or audios as an album.
        /// Documents and audio files can be only grouped in an album with messages of the same type.
        /// On success, an list of <see cref="Message"/> that were sent is returned.
        /// </summary>
        /// <typeparam name="TInputMedia"></typeparam>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="media">A list describing messages to be sent, must include 2-10 items.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<IEnumerable<Message>> SendMediaGroup<TInputMedia>(this TelegramBot bot,
            string chatId,
            IEnumerable<TInputMedia> media,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            CancellationToken cancellationToken = default) where TInputMedia : InputMedia =>
            SendMediaGroup<TInputMedia>(bot, new()
            {
                ChatId = chatId,
                Media = media,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply
            }, cancellationToken);

        /// <summary>
        /// Use this method to send a group of photos, videos, documents or audios as an album.
        /// Documents and audio files can be only grouped in an album with messages of the same type.
        /// On success, an list of <see cref="Message"/> that were sent is returned.
        /// </summary>
        /// <typeparam name="TInputMedia"></typeparam>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="media">A list describing messages to be sent, must include 2-10 items.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessage">If the message is a reply, the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<IEnumerable<Message>> SendMediaGroup<TInputMedia>(this TelegramBot bot,
            IChat chat,
            IEnumerable<TInputMedia> media,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            CancellationToken cancellationToken = default) where TInputMedia : InputMedia =>
            SendMediaGroup<TInputMedia>(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Media = media,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply
            }, cancellationToken);
    }
}
