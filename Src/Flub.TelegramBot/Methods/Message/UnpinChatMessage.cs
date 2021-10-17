using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to remove a message from the list of pinned messages in a chat.
    /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
    /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
    /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class UnpinChatMessage : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Identifier of a message to unpin. If not specified, the most recent pinned message (by sending date) will be unpinned.
        /// </summary>
        [JsonPropertyName("message_id")]
        public long? MessageId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnpinChatMessage"/> class.
        /// </summary>
        public UnpinChatMessage() : base("unpinChatMessage") { }
    }

    public static class UnpinChatMessageExtension
    {
        private static Task<bool?> UnpinChatMessage(this TelegramBot bot, UnpinChatMessage method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to remove a message from the list of pinned messages in a chat.
        /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
        /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
        /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of a message to unpin. If not specified, the most recent pinned message (by sending date) will be unpinned.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> UnpinChatMessage(this TelegramBot bot,
            string chatId,
            long? messageId = null,
            CancellationToken cancellationToken = default) =>
            UnpinChatMessage(bot, new()
            {
                ChatId = chatId,
                MessageId = messageId
            }, cancellationToken);

        /// <summary>
        /// Use this method to remove a message from the list of pinned messages in a chat.
        /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
        /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
        /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to unpin. If not specified, the most recent pinned message (by sending date) will be unpinned.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> UnpinChatMessage(this TelegramBot bot,
            IChat chat,
            IMessage message = null,
            CancellationToken cancellationToken = default) =>
            UnpinChatMessage(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id
            }, cancellationToken);
    }
}
