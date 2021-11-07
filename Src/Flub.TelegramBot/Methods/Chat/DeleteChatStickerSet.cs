using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to delete a group sticker set from a supergroup.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate administrator rights.
    /// Use the field <see cref="Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChat"/> requests to check if the bot can use this method.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class DeleteChatStickerSet : Method<Message>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteChatStickerSet"/> class.
        /// </summary>
        public DeleteChatStickerSet() : base("deleteChatStickerSet") { }
    }

    public static class DeleteChatStickerSetExtension
    {
        private static Task<Message> DeleteChatStickerSet(this TelegramBot bot, DeleteChatStickerSet method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to delete a group sticker set from a supergroup.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate administrator rights.
        /// Use the field <see cref="Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChat"/> requests to check if the bot can use this method.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> DeleteChatStickerSet(this TelegramBot bot,
            string chatId,
            CancellationToken cancellationToken = default) =>
            DeleteChatStickerSet(bot, new DeleteChatStickerSet
            {
                ChatId = chatId
            }, cancellationToken);

        /// <summary>
        /// Use this method to delete a group sticker set from a supergroup.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate administrator rights.
        /// Use the field <see cref="Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChat"/> requests to check if the bot can use this method.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> DeleteChatStickerSet(this TelegramBot bot,
            IChat chat,
            CancellationToken cancellationToken = default) =>
            DeleteChatStickerSet(bot, new DeleteChatStickerSet
            {
                ChatId = chat?.Id?.ToString()
            }, cancellationToken);
    }
}
