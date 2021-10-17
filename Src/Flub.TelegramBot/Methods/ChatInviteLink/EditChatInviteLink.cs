using Flub.TelegramBot.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to edit a non-primary invite link created by the bot.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Returns the edited invite link as a <see cref="ChatInviteLink"/> object.
    /// </summary>
    public class EditChatInviteLink : Method<ChatInviteLink>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// The invite link to edit.
        /// </summary>
        [Required]
        [JsonPropertyName("invite_link")]
        public Uri InviteLink { get; set; }
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
        public long? MemberLimit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditChatInviteLink"/> class.
        /// </summary>
        public EditChatInviteLink() : base("editChatInviteLink") { }
    }

    public static class EditChatInviteLinkExtension
    {
        private static Task<ChatInviteLink> EditChatInviteLink(this TelegramBot bot, EditChatInviteLink method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to edit a non-primary invite link created by the bot.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns the edited invite link as a <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="inviteLink">The invite link to edit.</param>
        /// <param name="expireDate">Point in time (Unix timestamp) when the link will expire.</param>
        /// <param name="memberLimit">Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> EditChatInviteLink(this TelegramBot bot,
            string chatId,
            Uri inviteLink,
            long? expireDate = null,
            long? memberLimit = null,
            CancellationToken cancellationToken = default) =>
            EditChatInviteLink(bot, new()
            {
                ChatId = chatId,
                InviteLink = inviteLink,
                ExpireDateValue = expireDate,
                MemberLimit = memberLimit
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit a non-primary invite link created by the bot.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns the edited invite link as a <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="inviteLink">The invite link to edit.</param>
        /// <param name="expireDate">Point in time when the link will expire.</param>
        /// <param name="memberLimit">Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> EditChatInviteLink(this TelegramBot bot,
            string chatId,
            Uri inviteLink,
            DateTime? expireDate = null,
            long? memberLimit = null,
            CancellationToken cancellationToken = default) =>
            EditChatInviteLink(bot, new()
            {
                ChatId = chatId,
                InviteLink = inviteLink,
                ExpireDate = expireDate,
                MemberLimit = memberLimit
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit a non-primary invite link created by the bot.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns the edited invite link as a <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="inviteLink">The invite link to edit.</param>
        /// <param name="expireDate">Point in time when the link will expire.</param>
        /// <param name="memberLimit">Maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> EditChatInviteLink(this TelegramBot bot,
            IChat chat,
            ChatInviteLink inviteLink,
            DateTime? expireDate = null,
            long? memberLimit = null,
            CancellationToken cancellationToken = default) =>
            EditChatInviteLink(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                InviteLink = inviteLink?.InviteLink,
                ExpireDate = expireDate,
                MemberLimit = memberLimit
            }, cancellationToken);
    }
}
