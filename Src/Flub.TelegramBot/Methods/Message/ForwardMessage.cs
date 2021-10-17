using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to forward messages of any kind. Service messages can't be forwarded.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class ForwardMessage : Method<Message>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Unique identifier for the chat where the original message was sent (or channel username in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("from_chat_id")]
        public string FromChatId { get; set; }
        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        [JsonPropertyName("disable_notification")]
        public bool? DisableNotification { get; set; }
        /// <summary>
        /// Message identifier in the chat specified in <see cref="FromChatId"/>.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public int? MessageId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForwardMessage"/> class.
        /// </summary>
        public ForwardMessage() : base("forwardMessage") { }
    }

    public static class ForwardMessageExtension
    {
        private static Task<Message> ForwardMessage(this TelegramBot bot, ForwardMessage method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to forward messages of any kind. Service messages can't be forwarded.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="fromChatId">Unique identifier for the chat where the original message was sent (or channel username in the format @channelusername).</param>
        /// <param name="messageId">Message identifier in the chat specified in <paramref name="fromChatId"/>.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> ForwardMessage(this TelegramBot bot,
            string chatId,
            string fromChatId,
            int? messageId,
            bool? disableNotification = null,
            CancellationToken cancellationToken = default) =>
            ForwardMessage(bot, new()
            {
                ChatId = chatId,
                FromChatId = fromChatId,
                MessageId = messageId,
                DisableNotification = disableNotification,
            }, cancellationToken);

        /// <summary>
        /// Use this method to forward messages of any kind. Service messages can't be forwarded.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="fromChat">The chat where the original message was sent.</param>
        /// <param name="message">Message in the chat specified in <paramref name="fromChat"/>.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> ForwardMessage(this TelegramBot bot,
            IChat chat,
            IChat fromChat,
            IMessage message,
            bool? disableNotification = null,
            CancellationToken cancellationToken = default) =>
            ForwardMessage(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                FromChatId = fromChat?.Id?.ToString(),
                MessageId = message?.Id,
                DisableNotification = disableNotification,
            }, cancellationToken);
    }
}
