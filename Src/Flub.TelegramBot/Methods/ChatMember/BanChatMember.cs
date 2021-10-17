using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to ban a user in a group, a supergroup or a channel.
    /// In the case of supergroups and channels, the user will not be able to return to the chat on their own using invite links, etc., unless unbanned first.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. Returns <see cref="true"/> on success.
    /// </summary>
    public class BanChatMember : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target group or username of the target supergroup or channel (in the format @channelusername).
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
        /// Date when the user will be unbanned, unix time.
        /// If user is banned for more than 366 days or less than 30 seconds from the current time they are considered to be banned forever.
        /// Applied for supergroups and channels only.
        /// </summary>
        [JsonPropertyName("until_date")]
        public long? UntilDateValue { get; set; }
        /// <summary>
        /// Date when the user will be unbanned.
        /// If user is banned for more than 366 days or less than 30 seconds from the current time they are considered to be banned forever.
        /// Applied for supergroups and channels only.
        /// </summary>
        [JsonPropertyName("until_date")]
        public DateTime? UntilDate
        {
            get => UntilDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(UntilDateValue.Value).DateTime : null;
            set => UntilDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
        /// <summary>
        /// Pass <see cref="true"/> to delete all messages from the chat for the user that is being removed.
        /// If <see cref="false"/>, the user will be able to see messages in the group that were sent before the user was removed.
        /// Always <see cref="true"/> for supergroups and channels.
        /// </summary>
        [JsonPropertyName("revoke_messages")]
        public bool? RevokeMessages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BanChatMember"/> class.
        /// </summary>
        public BanChatMember() : base("banChatMember") { }
    }

    public static class BanChatMemberExtension
    {
        private static Task<bool?> BanChatMember(this TelegramBot bot, BanChatMember method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to ban a user in a group, a supergroup or a channel.
        /// In the case of supergroups and channels, the user will not be able to return to the chat on their own using invite links, etc., unless unbanned first.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target group or username of the target supergroup or channel (in the format @channelusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="untilDate">
        /// Date when the user will be unbanned, unix time.
        /// If user is banned for more than 366 days or less than 30 seconds from the current time they are considered to be banned forever.
        /// Applied for supergroups and channels only.
        /// </param>
        /// <param name="revokeMessages">
        /// Pass <see cref="true"/> to delete all messages from the chat for the user that is being removed.
        /// If <see cref="false"/>, the user will be able to see messages in the group that were sent before the user was removed.
        /// Always <see cref="true"/> for supergroups and channels.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> BanChatMember(this TelegramBot bot,
            string chatId,
            long? userId,
            long? untilDate = null,
            bool? revokeMessages = null,
            CancellationToken cancellationToken = default) =>
            BanChatMember(bot, new()
            {
                ChatId = chatId,
                UserId = userId,
                UntilDateValue = untilDate,
                RevokeMessages = revokeMessages
            }, cancellationToken);

        /// <summary>
        /// Use this method to ban a user in a group, a supergroup or a channel.
        /// In the case of supergroups and channels, the user will not be able to return to the chat on their own using invite links, etc., unless unbanned first.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target group or username of the target supergroup or channel (in the format @channelusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="untilDate">
        /// Date when the user will be unbanned.
        /// If user is banned for more than 366 days or less than 30 seconds from the current time they are considered to be banned forever.
        /// Applied for supergroups and channels only.
        /// </param>
        /// <param name="revokeMessages">
        /// Pass <see cref="true"/> to delete all messages from the chat for the user that is being removed.
        /// If <see cref="false"/>, the user will be able to see messages in the group that were sent before the user was removed.
        /// Always <see cref="true"/> for supergroups and channels.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> BanChatMember(this TelegramBot bot,
            string chatId,
            long? userId,
            DateTime? untilDate = null,
            bool? revokeMessages = null,
            CancellationToken cancellationToken = default) =>
            BanChatMember(bot, new()
            {
                ChatId = chatId,
                UserId = userId,
                UntilDate = untilDate,
                RevokeMessages = revokeMessages
            }, cancellationToken);

        /// <summary>
        /// Use this method to ban a user in a group, a supergroup or a channel.
        /// In the case of supergroups and channels, the user will not be able to return to the chat on their own using invite links, etc., unless unbanned first.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target group.</param>
        /// <param name="user">Target user.</param>
        /// <param name="untilDate">
        /// Date when the user will be unbanned.
        /// If user is banned for more than 366 days or less than 30 seconds from the current time they are considered to be banned forever.
        /// Applied for supergroups and channels only.
        /// </param>
        /// <param name="revokeMessages">
        /// Pass <see cref="true"/> to delete all messages from the chat for the user that is being removed.
        /// If <see cref="false"/>, the user will be able to see messages in the group that were sent before the user was removed.
        /// Always <see cref="true"/> for supergroups and channels.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> BanChatMember(this TelegramBot bot,
            IChat chat,
            IUser user,
            DateTime? untilDate = null,
            bool? revokeMessages = null,
            CancellationToken cancellationToken = default) =>
            BanChatMember(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                UserId = user?.Id,
                UntilDate = untilDate,
                RevokeMessages = revokeMessages
            }, cancellationToken);
    }
}
