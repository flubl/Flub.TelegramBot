using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to change the description of a group, a supergroup or a channel.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class SetChatDescription : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// New chat description, 0-255 characters.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetChatDescription"/> class.
        /// </summary>
        public SetChatDescription() : base("setChatDescription") { }
    }

    public static class SetChatDescriptionExtension
    {
        private static Task<bool?> SetChatDescription(this TelegramBot bot, SetChatDescription method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to change the description of a group, a supergroup or a channel.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="description">New chat description, 0-255 characters.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatDescription(this TelegramBot bot,
            string chatId,
            string description = null,
            CancellationToken cancellationToken = default) =>
            SetChatDescription(bot, new()
            {
                ChatId = chatId,
                Description = description
            }, cancellationToken);

        /// <summary>
        /// Use this method to change the description of a group, a supergroup or a channel.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="description">New chat description, 0-255 characters.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatDescription(this TelegramBot bot,
            IChat chat,
            string description = null,
            CancellationToken cancellationToken = default) =>
            SetChatDescription(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Description = description
            }, cancellationToken);
    }
}
