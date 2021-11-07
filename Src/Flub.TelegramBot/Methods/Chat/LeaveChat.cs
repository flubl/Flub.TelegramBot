using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method for your bot to leave a group, supergroup or channel.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class LeaveChat : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeaveChat"/> class.
        /// </summary>
        public LeaveChat() : base("leaveChat") { }
    }

    public static class LeaveChatExtension
    {
        private static Task<bool?> LeaveChat(this TelegramBot bot, LeaveChat method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method for your bot to leave a group, supergroup or channel.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> LeaveChat(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            LeaveChat(bot, new LeaveChat
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method for your bot to leave a group, supergroup or channel.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> LeaveChat(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            LeaveChat(bot, new LeaveChat
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
