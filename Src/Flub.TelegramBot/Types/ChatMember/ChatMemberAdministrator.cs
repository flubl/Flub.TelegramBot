using Flub.Utils.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a chat member that has some additional privileges.
    /// </summary>
    [JsonTyped(ChatMemberStatus.Administrator)]
    public class ChatMemberAdministrator : ChatMemberOwner
    {
        /// <summary>
        /// <see langword="true"/>, if the bot is allowed to edit administrator privileges of that user.
        /// </summary>
        [JsonPropertyName("can_be_edited")]
        public bool? CanBeEdited { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the administrator can access the chat event log, chat statistics, message statistics in channels,
        /// see channel members, see anonymous administrators in supergroups and ignore slow mode. Implied by any other administrator privilege.
        /// </summary>
        [JsonPropertyName("can_manage_chat")]
        public bool? CanManageChat { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the administrator can delete messages of other users.
        /// </summary>
        [JsonPropertyName("can_delete_messages")]
        public bool? CanDeleteMessages { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the administrator can manage voice chats.
        /// </summary>
        [JsonPropertyName("can_manage_voice_chats")]
        public bool? CanManageVoiceChats { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the administrator can restrict, ban or unban chat members.
        /// </summary>
        [JsonPropertyName("can_restrict_members")]
        public bool? CanRestrictMembers { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the administrator can add new administrators with a subset of their own privileges or demote administrators that he has promoted,
        /// directly or indirectly (promoted by administrators that were appointed by the user).
        /// </summary>
        [JsonPropertyName("can_promote_members")]
        public bool? CanPromoteMembers { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the user is allowed to change the chat title, photo and other settings.
        /// </summary>
        [JsonPropertyName("can_change_info")]
        public bool? CanChangeInfo { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the user is allowed to invite new users to the chat.
        /// </summary>
        [JsonPropertyName("can_invite_users")]
        public bool? CanInviteUsers { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the administrator can post in the channel; channels only.
        /// </summary>
        [JsonPropertyName("can_post_messages")]
        public bool? CanPostMessages { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the administrator can edit messages of other users and can pin messages; channels only.
        /// </summary>
        [JsonPropertyName("can_edit_messages")]
        public bool? CanEditMessages { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to pin messages; groups and supergroups only.
        /// </summary>
        [JsonPropertyName("can_pin_messages")]
        public bool? CanPinMessages { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberAdministrator"/> with the <see cref="ChatMemberStatus.Administrator"/> status.
        /// </summary>
        public ChatMemberAdministrator() : base(ChatMemberStatus.Administrator) { }

        public override string ToString() => $"{nameof(ChatMemberAdministrator)}[{User}]";
    }
}
