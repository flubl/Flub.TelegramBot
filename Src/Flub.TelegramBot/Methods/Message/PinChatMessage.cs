using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to add a message to the list of pinned messages in a chat.
    /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
    /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
    /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class PinChatMessage : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Identifier of a message to pin.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public long? MessageId { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if it is not necessary to send a notification to all chat members about the new pinned message.
        /// Notifications are always disabled in channels and private chats.
        /// </summary>
        [JsonPropertyName("disable_notification")]
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PinChatMessage"/> class.
        /// </summary>
        public PinChatMessage() : base("pinChatMessage") { }
    }

    public static class PinChatMessageExtension
    {
        private static Task<bool?> PinChatMessage(this TelegramBot bot, PinChatMessage method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to add a message to the list of pinned messages in a chat.
        /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
        /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
        /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of a message to pin.</param>
        /// <param name="disableNotification">
        /// Pass <see langword="true"/>, if it is not necessary to send a notification to all chat members about the new pinned message.
        /// Notifications are always disabled in channels and private chats.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> PinChatMessage(this TelegramBot bot,
            string chatId,
            long? messageId,
            bool? disableNotification = null,
            CancellationToken cancellationToken = default) =>
            PinChatMessage(bot, new()
            {
                ChatId = chatId,
                MessageId = messageId,
                DisableNotification = disableNotification
            }, cancellationToken);

        /// <summary>
        /// Use this method to add a message to the list of pinned messages in a chat.
        /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
        /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
        /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to pin.</param>
        /// <param name="disableNotification">
        /// Pass <see langword="true"/>, if it is not necessary to send a notification to all chat members about the new pinned message.
        /// Notifications are always disabled in channels and private chats.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> PinChatMessage(this TelegramBot bot,
            IChat chat,
            IMessage message,
            bool? disableNotification = null,
            CancellationToken cancellationToken = default) =>
            PinChatMessage(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                DisableNotification = disableNotification
            }, cancellationToken);
    }
}
