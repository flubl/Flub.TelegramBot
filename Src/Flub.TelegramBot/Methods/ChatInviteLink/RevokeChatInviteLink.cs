using Flub.TelegramBot.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to revoke an invite link created by the bot.
    /// If the primary link is revoked, a new link is automatically generated.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Returns the revoked invite link as <see cref="ChatInviteLink"/> object.
    /// </summary>
    public class RevokeChatInviteLink : Method<ChatInviteLink>
    {
        /// <summary>
        /// Unique identifier of the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// The invite link to revoke.
        /// </summary>
        [Required]
        [JsonPropertyName("invite_link")]
        public Uri InviteLink { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RevokeChatInviteLink"/> class.
        /// </summary>
        public RevokeChatInviteLink() : base("revokeChatInviteLink") { }
    }

    public static class RevokeChatInviteLinkExtension
    {
        private static Task<ChatInviteLink> RevokeChatInviteLink(this TelegramBot bot, RevokeChatInviteLink method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to revoke an invite link created by the bot.
        /// If the primary link is revoked, a new link is automatically generated.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns the revoked invite link as <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier of the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="inviteLink">The invite link to revoke.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> RevokeChatInviteLink(this TelegramBot bot,
            string chatId,
            Uri inviteLink,
            CancellationToken cancellationToken = default) =>
            RevokeChatInviteLink(bot, new()
            {
                ChatId = chatId,
                InviteLink = inviteLink
            }, cancellationToken);

        /// <summary>
        /// Use this method to revoke an invite link created by the bot.
        /// If the primary link is revoked, a new link is automatically generated.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns the revoked invite link as <see cref="ChatInviteLink"/> object.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="inviteLink">The invite link to revoke.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatInviteLink> RevokeChatInviteLink(this TelegramBot bot,
            IChat chat,
            ChatInviteLink inviteLink,
            CancellationToken cancellationToken = default) =>
            RevokeChatInviteLink(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                InviteLink = inviteLink?.InviteLink
            }, cancellationToken);
    }
}
