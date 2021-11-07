using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to unban a previously banned user in a supergroup or channel.
    /// The user will not return to the group or channel automatically, but will be able to join via link, etc.
    /// The bot must be an administrator for this to work.
    /// By default, this method guarantees that after the call the user is not a member of the chat, but will be able to join it.
    /// So if the user is a member of the chat they will also be removed from the chat. If you don't want this, use the parameter <see cref="OnlyIfBanned"/>.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class UnbanChatMember : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target group or username of the target supergroup or channel (in the format @username).
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
        /// Do nothing if the user is not banned.
        /// </summary>
        [JsonPropertyName("only_if_banned")]
        public bool? OnlyIfBanned { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnbanChatMember"/> class.
        /// </summary>
        public UnbanChatMember() : base("unbanChatMember") { }
    }

    public static class UnbanChatMemberExtension
    {
        private static Task<bool?> UnbanChatMember(this TelegramBot bot, UnbanChatMember method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to unban a previously banned user in a supergroup or channel.
        /// The user will not return to the group or channel automatically, but will be able to join via link, etc.
        /// The bot must be an administrator for this to work.
        /// By default, this method guarantees that after the call the user is not a member of the chat, but will be able to join it.
        /// So if the user is a member of the chat they will also be removed from the chat. If you don't want this, use the parameter <see cref="OnlyIfBanned"/>.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target group or username of the target supergroup or channel (in the format @username).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="onlyIfBanned">Do nothing if the user is not banned.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> UnbanChatMember(this TelegramBot bot,
            string chatId,
            long? userId,
            bool? onlyIfBanned = null,
            CancellationToken cancellationToken = default) =>
            UnbanChatMember(bot, new()
            {
                ChatId = chatId,
                UserId = userId,
                OnlyIfBanned = onlyIfBanned
            }, cancellationToken);

        /// <summary>
        /// Use this method to unban a previously banned user in a supergroup or channel.
        /// The user will not return to the group or channel automatically, but will be able to join via link, etc.
        /// The bot must be an administrator for this to work.
        /// By default, this method guarantees that after the call the user is not a member of the chat, but will be able to join it.
        /// So if the user is a member of the chat they will also be removed from the chat. If you don't want this, use the parameter <see cref="OnlyIfBanned"/>.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target group.</param>
        /// <param name="user">Target user.</param>
        /// <param name="onlyIfBanned">Do nothing if the user is not banned.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> UnbanChatMember(this TelegramBot bot,
            IChat chat,
            IUser user,
            bool? onlyIfBanned = null,
            CancellationToken cancellationToken = default) =>
            UnbanChatMember(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                UserId = user?.Id,
                OnlyIfBanned = onlyIfBanned
            }, cancellationToken);
    }
}
