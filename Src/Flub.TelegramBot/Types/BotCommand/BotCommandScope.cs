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
    /// <see cref="BotCommandScopeChatMember"/>.
    /// See <see href="https://core.telegram.org/bots/api#determining-list-of-commands">Determining list of Commands</see> for more informations about
    /// the algorithm used to determine the list of commands for a particular user viewing the bot menu.
    /// </summary>
    [JsonConverter(typeof(JsonTypedConverter))]
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

        public override string ToString() => $"{nameof(BotCommandScope)}[{Type}]";
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
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
