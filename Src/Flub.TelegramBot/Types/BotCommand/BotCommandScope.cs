using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents the scope to which bot commands are applied. Currently, the following 7 scopes are supported:
    /// <see cref="BotCommandScopeDefault"/>,
    /// <see cref="BotCommandScopeAllPrivateChats"/>,
    /// <see cref="BotCommandScopeAllGroupChats"/>,
    /// <see cref="BotCommandScopeAllChatAdministrators"/>,
    /// <see cref="BotCommandScopeChat"/>,
    /// <see cref="BotCommandScopeChatAdministrators"/>,
    /// <see cref="BotCommandScopeChatMember"/>
    /// </summary>
    [JsonConverter(typeof(JsonTypedConverter<BotCommandScope, BotCommandScopeType>))]
    public abstract class BotCommandScope : IJsonTyped<BotCommandScopeType>
    {
        /// <summary>
        /// Scope type.
        /// </summary>
        [JsonPropertyName("type")]
        public BotCommandScopeType Type { get; }

        protected BotCommandScope(BotCommandScopeType type)
        {
            Type = type;
        }
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter<BotCommandScopeType>))]
    public enum BotCommandScopeType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("default")]
        Default = 0x1,
        [JsonFieldValue("all_private_chats")]
        AllPrivateChats = 0x2,
        [JsonFieldValue("all_group_chats")]
        AllGroupChats = 0x4,
        [JsonFieldValue("all_chat_administrators")]
        AllChatAdministrators = 0x8,
        [JsonFieldValue("chat")]
        Chat = 0x10,
        [JsonFieldValue("chat_administrators")]
        ChatAdministrators = 0x20,
        [JsonFieldValue("chat_member")]
        ChatMember = 0x40
    }
}
