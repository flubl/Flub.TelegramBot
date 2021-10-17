using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get information about a member of a chat.
    /// Returns a <see cref="ChatMember"/> object on success.
    /// </summary>
    public class GetChatMember : Method<ChatMember>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).
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
        /// Initializes a new instance of the <see cref="GetChatMember"/> class.
        /// </summary>
        public GetChatMember() : base("getChatMember") { }
    }

    public static class GetChatMemberExtension
    {
        private static Task<ChatMember> GetChatMember(this TelegramBot bot, GetChatMember method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get information about a member of a chat.
        /// Returns a <see cref="ChatMember"/> object on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername).</param>
        /// <param name="userId">Unique identifier of the target user.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatMember> GetChatMember(this TelegramBot bot,
            string chatId,
            long? userId,
            CancellationToken cancellationToken = default) =>
            GetChatMember(bot, new()
            {
                ChatId = chatId,
                UserId = userId
            }, cancellationToken);

        /// <summary>
        /// Use this method to get information about a member of a chat.
        /// Returns a <see cref="ChatMember"/> object on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="user">Target user.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<ChatMember> GetChatMember(this TelegramBot bot,
            IChat chat,
            IUser user,
            CancellationToken cancellationToken = default) =>
            GetChatMember(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                UserId = user?.Id
            }, cancellationToken);
    }
}
