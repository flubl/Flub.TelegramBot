using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to set a custom title for an administrator in a supergroup promoted by the bot.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class SetChatAdministratorCustomTitle : Method<bool?>
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
        /// New custom title for the administrator; 0-16 characters, emoji are not allowed.
        /// </summary>
        [Required]
        [JsonPropertyName("custom_title")]
        public string CustomTitle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetChatAdministratorCustomTitle"/> class.
        /// </summary>
        public SetChatAdministratorCustomTitle() : base("setChatAdministratorCustomTitle") { }
    }

    public static class SetChatAdministratorCustomTitleExtension
    {
        private static Task<bool?> SetChatAdministratorCustomTitle(this TelegramBot bot, SetChatAdministratorCustomTitle method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to set a custom title for an administrator in a supergroup promoted by the bot.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="customTitle">New custom title for the administrator; 0-16 characters, emoji are not allowed.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatAdministratorCustomTitle(this TelegramBot bot,
            string chatId,
            long? userId,
            string customTitle,
            CancellationToken cancellationToken = default) =>
            SetChatAdministratorCustomTitle(bot, new()
            {
                ChatId = chatId,
                UserId = userId,
                CustomTitle = customTitle
            }, cancellationToken);

        /// <summary>
        /// Use this method to set a custom title for an administrator in a supergroup promoted by the bot.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="user">Target user.</param>
        /// <param name="customTitle">New custom title for the administrator; 0-16 characters, emoji are not allowed.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatAdministratorCustomTitle(this TelegramBot bot,
            IChat chat,
            IUser user,
            string customTitle,
            CancellationToken cancellationToken = default) =>
            SetChatAdministratorCustomTitle(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                UserId = user?.Id,
                CustomTitle = customTitle
            }, cancellationToken);
    }
}
