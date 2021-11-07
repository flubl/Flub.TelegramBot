using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a chat member that is under certain restrictions in the chat. Supergroups only.
    /// </summary>
    [JsonTyped(ChatMemberStatus.Restricted)]
    public class ChatMemberRestricted : ChatMemberMember, IChatPermissions
    {
        /// <summary>
        /// <see langword="true"/>, if the user is a member of the chat at the moment of the request.
        /// </summary>
        [JsonPropertyName("is_member")]
        public bool? IsMember { get; set; }
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
        /// <see langword="true"/>, if the user is allowed to pin messages.
        /// </summary>
        [JsonPropertyName("can_pin_messages")]
        public bool? CanPinMessages { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the user is allowed to send text messages, contacts, locations and venues.
        /// </summary>
        [JsonPropertyName("can_send_messages")]
        public bool? CanSendMessages { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the user is allowed to send audios, documents, photos, videos, video notes and voice notes.
        /// </summary>
        [JsonPropertyName("can_send_media_messages")]
        public bool? CanSendMediaMessages { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the user is allowed to send polls.
        /// </summary>
        [JsonPropertyName("can_send_polls")]
        public bool? CanSendPolls { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the user is allowed to send animations, games, stickers and use inline bots.
        /// </summary>
        [JsonPropertyName("can_send_other_messages")]
        public bool? CanSendOtherMessages { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the user is allowed to add web page previews to their messages.
        /// </summary>
        [JsonPropertyName("can_add_web_page_previews")]
        public bool? CanAddWebPagePreviews { get; set; }
        /// <summary>
        /// Date when restrictions will be lifted for this user; unix time. If 0, then the user is restricted forever.
        /// </summary>
        [JsonPropertyName("until_date")]
        public long? UntilDateValue { get; set; }
        /// <summary>
        /// Date when restrictions will be lifted for this user.
        /// </summary>
        [JsonIgnore]
        public DateTime? UntilDate
        {
            get => UntilDateValue.HasValue && UntilDateValue != 0 ? DateTimeOffset.FromUnixTimeSeconds(UntilDateValue.Value).DateTime : null;
            set => UntilDateValue = value.HasValue && new DateTimeOffset(value.Value).ToUnixTimeSeconds() is long l && l > 0 ? l : null;
        }
        /// <summary>
        /// <see langword="true"/>, if the user is restricted forever.
        /// </summary>
        [JsonIgnore]
        public bool? IsForever
        {
            get => UntilDateValue.HasValue ? UntilDateValue == 0 : null;
            set => UntilDateValue = value.HasValue ? value.Value ? 0 : UntilDateValue : null;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ChatMemberRestricted"/> with the <see cref="ChatMemberStatus.Restricted"/> status.
        /// </summary>
        public ChatMemberRestricted() : base(ChatMemberStatus.Restricted) { }

        public override string ToString() => $"{nameof(ChatMemberRestricted)}[{User}]";
    }
}
