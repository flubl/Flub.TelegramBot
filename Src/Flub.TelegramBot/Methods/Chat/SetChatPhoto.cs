using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to set a new profile photo for the chat.
    /// Photos can't be changed for private chats.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Returns <see cref="true"/> on success.
    /// </summary>
    public class SetChatPhoto : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// New chat photo.
        /// </summary>
        [Required]
        [JsonPropertyName("photo")]
        public InputFile Photo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetChatPhoto"/> class.
        /// </summary>
        public SetChatPhoto() : base("setChatPhoto") { }
    }

    public static class SetChatPhotoExtension
    {
        private static Task<bool?> SetChatPhoto(this TelegramBot bot, SetChatPhoto method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to set a new profile photo for the chat.
        /// Photos can't be changed for private chats.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="photo">New chat photo.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatPhoto(this TelegramBot bot,
            string chatId,
            InputFile photo,
            CancellationToken cancellationToken = default) =>
            SetChatPhoto(bot, new()
            {
                ChatId = chatId,
                Photo = photo
            }, cancellationToken);

        /// <summary>
        /// Use this method to set a new profile photo for the chat.
        /// Photos can't be changed for private chats.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see cref="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="photo">New chat photo.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatPhoto(this TelegramBot bot,
            IChat chat,
            InputFile photo,
            CancellationToken cancellationToken = default) =>
            SetChatPhoto(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Photo = photo
            }, cancellationToken);
    }
}
