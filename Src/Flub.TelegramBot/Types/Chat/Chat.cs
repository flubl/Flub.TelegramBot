using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    public class Chat : IUser
    {
        /// <summary>
        /// Unique identifier for this chat.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        /// <summary>
        /// Type of chat, can be either “private”, “group”, “supergroup” or “channel”.
        /// </summary>
        [JsonPropertyName("type")]
        public ChatType? Type { get; set; }
        /// <summary>
        /// Optional. Title, for supergroups, channels and group chats.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Username, for private chats, supergroups and channels if available.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }
        /// <summary>
        /// Optional. First name of the other party in a private chat.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Optional. Last name of the other party in a private chat.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Optional. Chat photo. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("photo")]
        public ChatPhoto Photo { get; set; }
        /// <summary>
        /// Optional. Bio of the other party in a private chat. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("bio")]
        public string Bio { get; set; }
        /// <summary>
        /// Optional. Description, for groups, supergroups and channel chats. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Optional. Primary invite link, for groups, supergroups and channel chats. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("invite_link")]
        public Uri InviteLink { get; set; }
        /// <summary>
        /// Optional. The most recent pinned message (by sending date). Returned only in getChat.
        /// </summary>
        [JsonPropertyName("pinned_message")]
        public Message PinnedMessage { get; set; }
        /// <summary>
        /// Optional. Default chat member permissions, for groups and supergroups. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("permissions")]
        public ChatPermissions Permissions { get; set; }
        /// <summary>
        /// Optional. For supergroups, the minimum allowed delay between consecutive messages sent by each unpriviledged user. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("slow_mode_delay")]
        public int? SlowModeDelay { get; set; }
        /// <summary>
        /// Optional. The time after which all messages sent to the chat will be automatically deleted; in seconds. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("message_auto_delete_time")]
        public int? MessageAutoDeleteTime { get; set; }
        /// <summary>
        /// Optional. For supergroups, name of group sticker set. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("sticker_set_name")]
        public string StickerSetName { get; set; }
        /// <summary>
        /// Optional. True, if the bot can change the group sticker set. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("can_set_sticker_set")]
        public bool? CanSetStickerSet { get; set; }
        /// <summary>
        /// Optional. Unique identifier for the linked chat, i.e. the discussion group identifier for a channel and vice versa; for supergroups and channel chats. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("linked_chat_id")]
        public long? LinkedChatId { get; set; }
        /// <summary>
        /// Optional. For supergroups, the location to which the supergroup is connected. Returned only in getChat.
        /// </summary>
        [JsonPropertyName("location")]
        public ChatLocation Location { get; set; }
    }

    /// <summary>
    /// Available chat types.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter<ChatType>))]
    public enum ChatType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("private")]
        Private = 0x1,
        [JsonFieldValue("group")]
        Group = 0x2,
        [JsonFieldValue("supergroup")]
        Supergroup = 0x4,
        [JsonFieldValue("channel")]
        Channel = 0x8,
        [JsonFieldValue("sender")]
        Sender = 0x10
    }
}
