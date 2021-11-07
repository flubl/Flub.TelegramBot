using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to clear the list of pinned messages in a chat.
    /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
    /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
    /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class UnpinAllChatMessages : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnpinAllChatMessages"/> class.
        /// </summary>
        public UnpinAllChatMessages() : base("unpinAllChatMessages") { }
    }

    public static class UnpinAllChatMessagesExtension
    {
        private static Task<bool?> UnpinAllChatMessages(this TelegramBot bot, UnpinAllChatMessages method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to clear the list of pinned messages in a chat.
        /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
        /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
        /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> UnpinAllChatMessages(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            UnpinAllChatMessages(bot, new UnpinAllChatMessages
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method to clear the list of pinned messages in a chat.
        /// If the chat is not a private chat, the bot must be an administrator in the chat for this to work
        /// and must have the <see cref="ChatMemberAdministrator.CanPinMessages"/> admin right in a supergroup
        /// or <see cref="ChatMemberAdministrator.CanEditMessages"/> admin right in a channel.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> UnpinAllChatMessages(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            UnpinAllChatMessages(bot, new UnpinAllChatMessages
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
