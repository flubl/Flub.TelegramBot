namespace Flub.TelegramBot
{
    /// <summary>
    /// Contains information about permissions of a user in a chat.
    /// </summary>
    public interface IChatPermissions
    {
        /// <summary>
        /// Optional. True, if the user is allowed to send text messages, contacts, locations and venues.
        /// </summary>
        bool? CanSendMessages { get; set; }
        /// <summary>
        /// Optional. True, if the user is allowed to send audios, documents, photos, videos, video notes and voice notes, implies can_send_messages.
        /// </summary>
        bool? CanSendMediaMessages { get; set; }
        /// <summary>
        /// Optional. True, if the user is allowed to send polls, implies can_send_messages.
        /// </summary>
        bool? CanSendPolls { get; set; }
        /// <summary>
        /// Optional. True, if the user is allowed to send animations, games, stickers and use inline bots, implies can_send_media_messages.
        /// </summary>
        bool? CanSendOtherMessages { get; set; }
        /// <summary>
        /// Optional. True, if the user is allowed to add web page previews to their messages, implies can_send_media_messages.
        /// </summary>
        bool? CanAddWebPagePreviews { get; set; }
        /// <summary>
        /// Optional. True, if the user is allowed to change the chat title, photo and other settings. Ignored in public supergroups.
        /// </summary>
        bool? CanChangeInfo { get; set; }
        /// <summary>
        /// Optional. True, if the user is allowed to invite new users to the chat.
        /// </summary>
        bool? CanInviteUsers { get; set; }
        /// <summary>
        /// Optional. True, if the user is allowed to pin messages. Ignored in public supergroups.
        /// </summary>
        bool? CanPinMessages { get; set; }
    }
}
