using Flub.TelegramBot.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to create an additional invite link for a chat.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// The link can be revoked using the method <see cref="RevokeChatInviteLink"/>.
    /// Returns the new invite link as <see cref="ChatInviteLink"/> object.
    /// </summary>
    public class CreateChatInviteLink : Method<ChatInviteLink>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Point in time (Unix timestamp) when the link will expire.
        /// </summary>
        [JsonPropertyName("expire_date")]
        public long? ExpireDateValue { get; set; }
        /// <summary>
        /// Point in time when the link will expire.
        /// </summary>
        [JsonPropertyName("expire_date")]
        public DateTime? ExpireDate
        {
            get => ExpireDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(ExpireDateValue.Value).DateTime : null;
            set => ExpireDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
        /// <summary>
        /// Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.
        /// </summary>
        [JsonPropertyName("member_limit")]
        public int? MemberLimit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateChatInviteLink"/> class.
        /// </summary>
        public CreateChatInviteLink() : base("createChatInviteLink") { }
    }

    public static class CreateChatInviteLinkExtension
    {
        private static Task<ChatInviteLink> CreateChatInviteLink(this TelegramBot bot, CreateChatInviteLink method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to create an additional invite link for a chat.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// The link can be revoked using the method <see cref="RevokeChatInviteLink"/>.
        /// Returns the new invite link as <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="expireDate">Point in time (Unix timestamp) when the link will expire.</param>
        /// <param name="memberLimit">Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> CreateChatInviteLink(this TelegramBot bot,
            string chatId,
            long? expireDate = null,
            int? memberLimit = null,
            CancellationToken cancellationToken = default) =>
            CreateChatInviteLink(bot, new()
            {
                ChatId = chatId,
                ExpireDateValue = expireDate,
                MemberLimit = memberLimit
            }, cancellationToken);

        /// <summary>
        /// Use this method to create an additional invite link for a chat.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// The link can be revoked using the method <see cref="RevokeChatInviteLink"/>.
        /// Returns the new invite link as <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="expireDate">Point in time when the link will expire.</param>
        /// <param name="memberLimit">Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> CreateChatInviteLink(this TelegramBot bot,
            string chatId,
            DateTime? expireDate = null,
            int? memberLimit = null,
            CancellationToken cancellationToken = default) =>
            CreateChatInviteLink(bot, new()
            {
                ChatId = chatId,
                ExpireDate = expireDate,
                MemberLimit = memberLimit
            }, cancellationToken);

        /// <summary>
        /// Use this method to create an additional invite link for a chat.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// The link can be revoked using the method <see cref="RevokeChatInviteLink"/>.
        /// Returns the new invite link as <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="expireDate">Point in time when the link will expire.</param>
        /// <param name="memberLimit">Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> CreateChatInviteLink(this TelegramBot bot,
            IChat chat,
            DateTime? expireDate = null,
            int? memberLimit = null,
            CancellationToken cancellationToken = default) =>
            CreateChatInviteLink(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                ExpireDate = expireDate,
                MemberLimit = memberLimit
            }, cancellationToken);
    }
}
