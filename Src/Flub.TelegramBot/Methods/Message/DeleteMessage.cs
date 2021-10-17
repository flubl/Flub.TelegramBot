using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to delete a message, including service messages, with the following limitations:
    /// - A message can only be deleted if it was sent less than 48 hours ago.
    /// - A dice message in a private chat can only be deleted if it was sent more than 24 hours ago.
    /// - Bots can delete outgoing messages in private chats, groups, and supergroups.
    /// - Bots can delete incoming messages in private chats.
    /// - Bots granted <see cref="ChatMemberAdministrator.CanPostMessages"/> permissions can delete outgoing messages in channels.
    /// - If the bot is an administrator of a group, it can delete any message there.
    /// - If the bot has <see cref="ChatMemberAdministrator.CanDeleteMessages"/> permission in a supergroup or a channel, it can delete any message there.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class DeleteMessage : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Identifier of the message to delete.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public long? MessageId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMessage"/> class.
        /// </summary>
        public DeleteMessage() : base("deleteMessage") { }
    }

    public static class DeleteMessageExtension
    {
        private static Task<bool?> DeleteMessage(this TelegramBot bot, DeleteMessage method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to delete a message, including service messages, with the following limitations:
        /// - A message can only be deleted if it was sent less than 48 hours ago.
        /// - A dice message in a private chat can only be deleted if it was sent more than 24 hours ago.
        /// - Bots can delete outgoing messages in private chats, groups, and supergroups.
        /// - Bots can delete incoming messages in private chats.
        /// - Bots granted <see cref="ChatMemberAdministrator.CanPostMessages"/> permissions can delete outgoing messages in channels.
        /// - If the bot is an administrator of a group, it can delete any message there.
        /// - If the bot has <see cref="ChatMemberAdministrator.CanDeleteMessages"/> permission in a supergroup or a channel, it can delete any message there.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the message to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteMessage(this TelegramBot bot,
            string chatId,
            long? messageId,
            CancellationToken cancellationToken = default) =>
            DeleteMessage(bot, new()
            {
                ChatId = chatId,
                MessageId = messageId
            }, cancellationToken);

        /// <summary>
        /// Use this method to delete a message, including service messages, with the following limitations:
        /// - A message can only be deleted if it was sent less than 48 hours ago.
        /// - A dice message in a private chat can only be deleted if it was sent more than 24 hours ago.
        /// - Bots can delete outgoing messages in private chats, groups, and supergroups.
        /// - Bots can delete incoming messages in private chats.
        /// - Bots granted <see cref="ChatMemberAdministrator.CanPostMessages"/> permissions can delete outgoing messages in channels.
        /// - If the bot is an administrator of a group, it can delete any message there.
        /// - If the bot has <see cref="ChatMemberAdministrator.CanDeleteMessages"/> permission in a supergroup or a channel, it can delete any message there.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteMessage(this TelegramBot bot,
            IChat chat,
            IMessage message,
            CancellationToken cancellationToken = default) =>
            DeleteMessage(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id
            }, cancellationToken);
    }
}
