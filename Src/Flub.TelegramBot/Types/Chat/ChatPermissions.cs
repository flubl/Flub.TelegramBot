using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Describes actions that a non-administrator user is allowed to take in a chat.
    /// </summary>
    public class ChatPermissions : IChatPermissions
    {
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to send text messages, contacts, locations and venues.
        /// </summary>
        [JsonPropertyName("can_send_messages")]
        public bool? CanSendMessages { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to send audios, documents, photos, videos, video notes and voice notes, implies <see cref="CanSendMessages"/>.
        /// </summary>
        [JsonPropertyName("can_send_media_messages")]
        public bool? CanSendMediaMessages { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to send polls, implies <see cref="CanSendMessages"/>.
        /// </summary>
        [JsonPropertyName("can_send_polls")]
        public bool? CanSendPolls { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to send animations, games, stickers and use inline bots, implies <see cref="CanSendMediaMessages"/>.
        /// </summary>
        [JsonPropertyName("can_send_other_messages")]
        public bool? CanSendOtherMessages { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to add web page previews to their messages, implies <see cref="CanSendMediaMessages"/>.
        /// </summary>
        [JsonPropertyName("can_add_web_page_previews")]
        public bool? CanAddWebPagePreviews { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to change the chat title, photo and other settings. Ignored in public supergroups.
        /// </summary>
        [JsonPropertyName("can_change_info")]
        public bool? CanChangeInfo { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to invite new users to the chat.
        /// </summary>
        [JsonPropertyName("can_invite_users")]
        public bool? CanInviteUsers { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the user is allowed to pin messages. Ignored in public supergroups.
        /// </summary>
        [JsonPropertyName("can_pin_messages")]
        public bool? CanPinMessages { get; set; }

        public override string ToString() => nameof(ChatPermissions);
    }
}
