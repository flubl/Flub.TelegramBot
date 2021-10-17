using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get the number of members in a chat.
    /// Returns <see cref="int?"/> on success.
    /// </summary>
    public class GetChatMemberCount : Method<int?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetChatMemberCount"/> class.
        /// </summary>
        public GetChatMemberCount() : base("getChatMemberCount") { }
    }

    public static class GetChatMemberCountExtension
    {
        private static Task<int?> GetChatMemberCount(this TelegramBot bot, GetChatMemberCount method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get the number of members in a chat.
        /// Returns <see cref="int?"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<int?> GetChatMemberCount(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            GetChatMemberCount(bot, new GetChatMemberCount
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method to get the number of members in a chat.
        /// Returns <see cref="int?"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<int?> GetChatMemberCount(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            GetChatMemberCount(bot, new GetChatMemberCount
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
