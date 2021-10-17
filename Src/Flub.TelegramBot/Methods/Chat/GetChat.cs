using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get up to date information about the chat (current name of the user for one-on-one conversations, current username of a user, group or channel, etc.).
    /// Returns a <see cref="Chat"/> object on success.
    /// </summary>
    public class GetChat : Method<Chat>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetChat"/> class.
        /// </summary>
        public GetChat() : base("getChat") { }
    }

    public static class GetChatExtension
    {
        private static Task<Chat> GetChat(this TelegramBot bot, GetChat method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get up to date information about the chat (current name of the user for one-on-one conversations, current username of a user, group or channel, etc.).
        /// Returns a <see cref="Chat"/> object on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Chat> GetChat(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            GetChat(bot, new GetChat
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method to get up to date information about the chat (current name of the user for one-on-one conversations, current username of a user, group or channel, etc.).
        /// Returns a <see cref="Chat"/> object on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Chat> GetChat(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            GetChat(bot, new GetChat
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
