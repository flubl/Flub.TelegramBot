using Flub.TelegramBot.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to restrict a user in a supergroup.
    /// The bot must be an administrator in the supergroup for this to work and must have the appropriate admin rights.
    /// Pass <see cref="true"/> for all permissions to lift restrictions from a user.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class RestrictChatMember : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).
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
        /// A <see cref="ChatPermissions"/> object for new user permissions.
        /// </summary>
        [Required]
        [JsonPropertyName("permissions")]
        public ChatPermissions Permissions { get; set; }
        /// <summary>
        /// Date when restrictions will be lifted for the user, unix time.
        /// If user is restricted for more than 366 days or less than 30 seconds from the current time, they are considered to be restricted forever.
        /// </summary>
        [JsonPropertyName("until_date")]
        public long? UntilDateValue { get; set; }
        /// <summary>
        /// Date when restrictions will be lifted for the user.
        /// If user is restricted for more than 366 days or less than 30 seconds from the current time, they are considered to be restricted forever.
        /// </summary>
        [JsonPropertyName("until_date")]
        public DateTime? UntilDate
        {
            get => UntilDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(UntilDateValue.Value).DateTime : null;
            set => UntilDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestrictChatMember"/> class.
        /// </summary>
        public RestrictChatMember() : base("restrictChatMember") { }
    }

    public static class RestrictChatMemberExtension
    {
        private static Task<bool?> RestrictChatMember(this TelegramBot bot, RestrictChatMember method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to restrict a user in a supergroup.
        /// The bot must be an administrator in the supergroup for this to work and must have the appropriate admin rights.
        /// Pass <see cref="true"/> for all permissions to lift restrictions from a user.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="permissions">A <see cref="ChatPermissions"/> object for new user permissions.</param>
        /// <param name="untilDate">
        /// Date when restrictions will be lifted for the user, unix time.
        /// If user is restricted for more than 366 days or less than 30 seconds from the current time, they are considered to be restricted forever.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> RestrictChatMember(this TelegramBot bot,
            string chatId,
            long? userId,
            ChatPermissions permissions,
            long? untilDate = null,
            CancellationToken cancellationToken = default) =>
            RestrictChatMember(bot, new()
            {
                ChatId = chatId,
                UserId = userId,
                Permissions = permissions,
                UntilDateValue = untilDate
            }, cancellationToken);

        /// <summary>
        /// Use this method to restrict a user in a supergroup.
        /// The bot must be an administrator in the supergroup for this to work and must have the appropriate admin rights.
        /// Pass <see cref="true"/> for all permissions to lift restrictions from a user.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="permissions">A <see cref="ChatPermissions"/> object for new user permissions.</param>
        /// <param name="untilDate">
        /// Date when restrictions will be lifted for the user, unix time.
        /// If user is restricted for more than 366 days or less than 30 seconds from the current time, they are considered to be restricted forever.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> RestrictChatMember(this TelegramBot bot,
            string chatId,
            long? userId,
            ChatPermissions permissions,
            DateTime? untilDate = null,
            CancellationToken cancellationToken = default) =>
            RestrictChatMember(bot, new()
            {
                ChatId = chatId,
                UserId = userId,
                Permissions = permissions,
                UntilDate = untilDate
            }, cancellationToken);

        /// <summary>
        /// Use this method to restrict a user in a supergroup.
        /// The bot must be an administrator in the supergroup for this to work and must have the appropriate admin rights.
        /// Pass <see cref="true"/> for all permissions to lift restrictions from a user.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="user">Target user.</param>
        /// <param name="permissions">A <see cref="ChatPermissions"/> object for new user permissions.</param>
        /// <param name="untilDate">
        /// Date when restrictions will be lifted for the user, unix time.
        /// If user is restricted for more than 366 days or less than 30 seconds from the current time, they are considered to be restricted forever.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> RestrictChatMember(this TelegramBot bot,
            IChat chat,
            IUser user,
            ChatPermissions permissions,
            DateTime? untilDate = null,
            CancellationToken cancellationToken = default) =>
            RestrictChatMember(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                UserId = user?.Id,
                Permissions = permissions,
                UntilDate = untilDate
            }, cancellationToken);
    }
}
