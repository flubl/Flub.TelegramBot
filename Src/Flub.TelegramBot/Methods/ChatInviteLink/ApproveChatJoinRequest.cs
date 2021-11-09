using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to approve a chat join request.
    /// The bot must be an administrator in the chat for this to work and must have the <see cref="IChatPermissions.CanInviteUsers"/> administrator right.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class ApproveChatJoinRequest : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
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
        /// Initializes a new instance of the <see cref="ApproveChatJoinRequest"/> class.
        /// </summary>
        public ApproveChatJoinRequest() : base("approveChatJoinRequest") { }
    }

    public static class ApproveChatJoinRequestExtension
    {
        private static Task<bool?> ApproveChatJoinRequest(this TelegramBot bot, ApproveChatJoinRequest method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to approve a chat join request.
        /// The bot must be an administrator in the chat for this to work and must have the <see cref="IChatPermissions.CanInviteUsers"/> administrator right.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> ApproveChatJoinRequest(this TelegramBot bot,
            string chatId,
            long? userId,
            CancellationToken cancellationToken = default) =>
            ApproveChatJoinRequest(bot, new()
            {
                ChatId = chatId,
                UserId = userId
            }, cancellationToken);

        /// <summary>
        /// Use this method to approve a chat join request.
        /// The bot must be an administrator in the chat for this to work and must have the <see cref="IChatPermissions.CanInviteUsers"/> administrator right.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="user">The target user.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> ApproveChatJoinRequest(this TelegramBot bot,
            IChat chat,
            IUser user,
            CancellationToken cancellationToken = default) =>
            ApproveChatJoinRequest(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                UserId = user?.Id
            }, cancellationToken);
    }
}
