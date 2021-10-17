using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to generate a new primary invite link for a chat; any previously generated primary link is revoked.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Returns the new invite link as <see cref="string"/> on success.
    /// </summary>
    public class ExportChatInviteLink : Method<string>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportChatInviteLink"/> class.
        /// </summary>
        public ExportChatInviteLink() : base("exportChatInviteLink") { }
    }

    public static class ExportChatInviteLinkExtension
    {
        private static Task<string> ExportChatInviteLink(this TelegramBot bot, ExportChatInviteLink method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to generate a new primary invite link for a chat; any previously generated primary link is revoked.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns the new invite link as <see cref="string"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<string> ExportChatInviteLink(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            ExportChatInviteLink(bot, new ExportChatInviteLink
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method to generate a new primary invite link for a chat; any previously generated primary link is revoked.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns the new invite link as <see cref="string"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<string> ExportChatInviteLink(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            ExportChatInviteLink(bot, new ExportChatInviteLink
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
