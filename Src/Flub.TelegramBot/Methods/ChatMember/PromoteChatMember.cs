using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to promote or demote a user in a supergroup or a channel.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Pass <see cref="false"/> for all boolean parameters to demote a user.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class PromoteChatMember : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Unique identifier of the target user.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator's presence in the chat is hidden.
        /// </summary>
        [JsonPropertyName("is_anonymous")]
        public bool? IsAnonymous { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can access the chat event log, chat statistics, message statistics in channels,
        /// see channel members, see anonymous administrators in supergroups and ignore slow mode.
        /// Implied by any other administrator privilege.
        /// </summary>
        [JsonPropertyName("can_manage_chat")]
        public bool? CanManageChat { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can create channel posts, channels only.
        /// </summary>
        [JsonPropertyName("can_post_messages")]
        public bool? CanPostMessages { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can edit messages of other users and can pin messages, channels only.
        /// </summary>
        [JsonPropertyName("can_edit_messages")]
        public bool? CanEditMessages { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can delete messages of other users.
        /// </summary>
        [JsonPropertyName("can_delete_messages")]
        public bool? CanDeleteMessages { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can manage voice chats.
        /// </summary>
        [JsonPropertyName("can_manage_voice_chats")]
        public bool? CanManageVoiceChats { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can restrict, ban or unban chat members.
        /// </summary>
        [JsonPropertyName("can_restrict_members")]
        public bool? CanRestrictMembers { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can add new administrators with a subset of their own privileges or demote administrators that he has promoted,
        /// directly or indirectly (promoted by administrators that were appointed by him).
        /// </summary>
        [JsonPropertyName("can_promote_members")]
        public bool? CanPromoteMembers { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can change chat title, photo and other settings.
        /// </summary>
        [JsonPropertyName("can_change_info")]
        public bool? CanChangeInfo { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can invite new users to the chat.
        /// </summary>
        [JsonPropertyName("can_invite_users")]
        public bool? CanInviteUsers { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the administrator can pin messages, supergroups only.
        /// </summary>
        [JsonPropertyName("can_pin_messages")]
        public bool? CanPinMessages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PromoteChatMember"/> class.
        /// </summary>
        public PromoteChatMember() : base("promoteChatMember") { }
    }

    public static class PromoteChatMemberExtension
    {
        private static Task<bool?> PromoteChatMember(this TelegramBot bot, PromoteChatMember method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to promote or demote a user in a supergroup or a channel.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Pass <see cref="false"/> for all boolean parameters to demote a user.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="isAnonymous">Pass <see cref="true"/>, if the administrator's presence in the chat is hidden.</param>
        /// <param name="canManageChat">
        /// Pass <see cref="true"/>, if the administrator can access the chat event log, chat statistics, message statistics in channels,
        /// see channel members, see anonymous administrators in supergroups and ignore slow mode.
        /// Implied by any other administrator privilege.
        /// </param>
        /// <param name="canPostMessages">Pass <see cref="true"/>, if the administrator can create channel posts, channels only.</param>
        /// <param name="canEditMessages">Pass <see cref="true"/>, if the administrator can edit messages of other users and can pin messages, channels only.</param>
        /// <param name="canDeleteMessages">Pass <see cref="true"/>, if the administrator can delete messages of other users.</param>
        /// <param name="canManageVoiceChats">Pass <see cref="true"/>, if the administrator can manage voice chats.</param>
        /// <param name="canRestrictMembers">Pass <see cref="true"/>, if the administrator can restrict, ban or unban chat members.</param>
        /// <param name="canPromoteMembers">
        /// Pass <see cref="true"/>, if the administrator can add new administrators with a subset of their own privileges or demote administrators that he has promoted,
        /// directly or indirectly (promoted by administrators that were appointed by him).
        /// </param>
        /// <param name="canChangeInfo">Pass <see cref="true"/>, if the administrator can change chat title, photo and other settings.</param>
        /// <param name="canInviteUsers">Pass <see cref="true"/>, if the administrator can invite new users to the chat.</param>
        /// <param name="canPinMessages">Pass <see cref="true"/>, if the administrator can pin messages, supergroups only.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> PromoteChatMember(this TelegramBot bot,
            string chatId,
            long? userId,
            bool? isAnonymous = null,
            bool? canManageChat = null,
            bool? canPostMessages = null,
            bool? canEditMessages = null,
            bool? canDeleteMessages = null,
            bool? canManageVoiceChats = null,
            bool? canRestrictMembers = null,
            bool? canPromoteMembers = null,
            bool? canChangeInfo = null,
            bool? canInviteUsers = null,
            bool? canPinMessages = null,
            CancellationToken cancellationToken = default) =>
            PromoteChatMember(bot, new()
            {
                ChatId = chatId,
                UserId = userId,
                IsAnonymous = isAnonymous,
                CanManageChat = canManageChat,
                CanPostMessages = canPostMessages,
                CanEditMessages = canEditMessages,
                CanDeleteMessages = canDeleteMessages,
                CanManageVoiceChats = canManageVoiceChats,
                CanRestrictMembers = canRestrictMembers,
                CanPromoteMembers = canPromoteMembers,
                CanChangeInfo = canChangeInfo,
                CanInviteUsers = canInviteUsers,
                CanPinMessages = canPinMessages
            }, cancellationToken);

        /// <summary>
        /// Use this method to promote or demote a user in a supergroup or a channel.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Pass <see cref="false"/> for all boolean parameters to demote a user.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="user">Target user.</param>
        /// <param name="isAnonymous">Pass <see cref="true"/>, if the administrator's presence in the chat is hidden.</param>
        /// <param name="canManageChat">
        /// Pass <see cref="true"/>, if the administrator can access the chat event log, chat statistics, message statistics in channels,
        /// see channel members, see anonymous administrators in supergroups and ignore slow mode.
        /// Implied by any other administrator privilege.
        /// </param>
        /// <param name="canPostMessages">Pass <see cref="true"/>, if the administrator can create channel posts, channels only.</param>
        /// <param name="canEditMessages">Pass <see cref="true"/>, if the administrator can edit messages of other users and can pin messages, channels only.</param>
        /// <param name="canDeleteMessages">Pass <see cref="true"/>, if the administrator can delete messages of other users.</param>
        /// <param name="canManageVoiceChats">Pass <see cref="true"/>, if the administrator can manage voice chats.</param>
        /// <param name="canRestrictMembers">Pass <see cref="true"/>, if the administrator can restrict, ban or unban chat members.</param>
        /// <param name="canPromoteMembers">
        /// Pass <see cref="true"/>, if the administrator can add new administrators with a subset of their own privileges or demote administrators that he has promoted,
        /// directly or indirectly (promoted by administrators that were appointed by him).
        /// </param>
        /// <param name="canChangeInfo">Pass <see cref="true"/>, if the administrator can change chat title, photo and other settings.</param>
        /// <param name="canInviteUsers">Pass <see cref="true"/>, if the administrator can invite new users to the chat.</param>
        /// <param name="canPinMessages">Pass <see cref="true"/>, if the administrator can pin messages, supergroups only.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> PromoteChatMember(this TelegramBot bot,
            IChat chat,
            IUser user,
            bool? isAnonymous = null,
            bool? canManageChat = null,
            bool? canPostMessages = null,
            bool? canEditMessages = null,
            bool? canDeleteMessages = null,
            bool? canManageVoiceChats = null,
            bool? canRestrictMembers = null,
            bool? canPromoteMembers = null,
            bool? canChangeInfo = null,
            bool? canInviteUsers = null,
            bool? canPinMessages = null,
            CancellationToken cancellationToken = default) =>
            PromoteChatMember(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                UserId = user?.Id,
                IsAnonymous = isAnonymous,
                CanManageChat = canManageChat,
                CanPostMessages = canPostMessages,
                CanEditMessages = canEditMessages,
                CanDeleteMessages = canDeleteMessages,
                CanManageVoiceChats = canManageVoiceChats,
                CanRestrictMembers = canRestrictMembers,
                CanPromoteMembers = canPromoteMembers,
                CanChangeInfo = canChangeInfo,
                CanInviteUsers = canInviteUsers,
                CanPinMessages = canPinMessages
            }, cancellationToken);
    }
}
