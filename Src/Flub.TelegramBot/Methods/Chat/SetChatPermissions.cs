using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to set default chat permissions for all members.
    /// The bot must be an administrator in the group or a supergroup for this to work and must have the <see cref="ChatMemberAdministrator.CanRestrictMembers"/> admin rights.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class SetChatPermissions : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// A <see cref="ChatPermissions"/> object for new default chat permissions.
        /// </summary>
        [Required]
        [JsonPropertyName("permissions")]
        public ChatPermissions Permissions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetChatPermissions"/> class.
        /// </summary>
        public SetChatPermissions() : base("setChatPermissions") { }
    }

    public static class SetChatPermissionsExtension
    {
        private static Task<bool?> SetChatPermissions(this TelegramBot bot, SetChatPermissions method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to set default chat permissions for all members.
        /// The bot must be an administrator in the group or a supergroup for this to work and must have the <see cref="ChatMemberAdministrator.CanRestrictMembers"/> admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).</param>
        /// <param name="permissions">A <see cref="ChatPermissions"/> object for new default chat permissions.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatPermissions(this TelegramBot bot,
            string chatId,
            ChatPermissions permissions,
            CancellationToken cancellationToken = default) =>
            SetChatPermissions(bot, new()
            {
                ChatId = chatId,
                Permissions = permissions
            }, cancellationToken);

        /// <summary>
        /// Use this method to set default chat permissions for all members.
        /// The bot must be an administrator in the group or a supergroup for this to work and must have the <see cref="ChatMemberAdministrator.CanRestrictMembers"/> admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="permissions">A <see cref="ChatPermissions"/> object for new default chat permissions.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatPermissions(this TelegramBot bot,
            IChat chat,
            ChatPermissions permissions,
            CancellationToken cancellationToken = default) =>
            SetChatPermissions(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Permissions = permissions
            }, cancellationToken);
    }
}
