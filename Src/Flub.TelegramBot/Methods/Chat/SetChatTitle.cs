using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to change the title of a chat.
    /// Titles can't be changed for private chats.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class SetChatTitle : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// New chat title, 1-255 characters.
        /// </summary>
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetChatTitle"/> class.
        /// </summary>
        public SetChatTitle() : base("setChatTitle") { }
    }

    public static class SetChatTitleExtension
    {
        private static Task<bool?> SetChatTitle(this TelegramBot bot, SetChatTitle method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to change the title of a chat.
        /// Titles can't be changed for private chats.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="title">New chat title, 1-255 characters.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatTitle(this TelegramBot bot,
            string chatId,
            string title,
            CancellationToken cancellationToken = default) =>
            SetChatTitle(bot, new()
            {
                ChatId = chatId,
                Title = title
            }, cancellationToken);

        /// <summary>
        /// Use this method to change the title of a chat.
        /// Titles can't be changed for private chats.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="title">New chat title, 1-255 characters.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatTitle(this TelegramBot bot,
            IChat chat,
            string title,
            CancellationToken cancellationToken = default) =>
            SetChatTitle(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Title = title
            }, cancellationToken);
    }
}
