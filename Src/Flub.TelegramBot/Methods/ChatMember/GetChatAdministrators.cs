using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get a list of administrators in a chat.
    /// On success, returns an Array of <see cref="ChatMember"/> objects that contains information about all chat administrators except other bots.
    /// If the chat is a group or a supergroup and no administrators were appointed, only the creator will be returned.
    /// </summary>
    public class GetChatAdministrators : Method<ChatMember[]>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetChatAdministrators"/> class.
        /// </summary>
        public GetChatAdministrators() : base("getChatAdministrators") { }
    }

    public static class GetChatAdministratorsExtension
    {
        private static Task<ChatMember[]> GetChatAdministrators(this TelegramBot bot, GetChatAdministrators method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get a list of administrators in a chat.
        /// On success, returns an Array of <see cref="ChatMember"/> objects that contains information about all chat administrators except other bots.
        /// If the chat is a group or a supergroup and no administrators were appointed, only the creator will be returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatMember[]> GetChatAdministrators(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            GetChatAdministrators(bot, new GetChatAdministrators
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method to get a list of administrators in a chat.
        /// On success, returns an Array of <see cref="ChatMember"/> objects that contains information about all chat administrators except other bots.
        /// If the chat is a group or a supergroup and no administrators were appointed, only the creator will be returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatMember[]> GetChatAdministrators(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            GetChatAdministrators(bot, new GetChatAdministrators
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
