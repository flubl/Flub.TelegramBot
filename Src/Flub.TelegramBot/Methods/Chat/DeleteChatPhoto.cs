using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to delete a chat photo. Photos can't be changed for private chats.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class DeleteChatPhoto : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteChatPhoto"/> class.
        /// </summary>
        public DeleteChatPhoto() : base("deleteChatPhoto") { }
    }

    public static class DeleteChatPhotoExtension
    {
        private static Task<bool?> DeleteChatPhoto(this TelegramBot bot, DeleteChatPhoto method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to delete a chat photo. Photos can't be changed for private chats.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteChatPhoto(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            DeleteChatPhoto(bot, new DeleteChatPhoto
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method to delete a chat photo. Photos can't be changed for private chats.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteChatPhoto(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            DeleteChatPhoto(bot, new DeleteChatPhoto
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
