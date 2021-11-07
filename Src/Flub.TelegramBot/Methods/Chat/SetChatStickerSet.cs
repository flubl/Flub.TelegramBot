using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to set a new group sticker set for a supergroup.
    /// The bot must be an administrator in the chat for this to work and must have the appropriate administrator rights.
    /// Use the field <see cref="Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChat"/> requests to check if the bot can use this method.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class SetChatStickerSet : Method<bool?>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Name of the sticker set to be set as the group sticker set.
        /// </summary>
        [Required]
        [JsonPropertyName("sticker_set_name")]
        public string StickerSetName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetChatStickerSet"/> class.
        /// </summary>
        public SetChatStickerSet() : base("setChatStickerSet") { }
    }

    public static class SetChatStickerSetExtension
    {
        private static Task<bool?> SetChatStickerSet(this TelegramBot bot, SetChatStickerSet method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to set a new group sticker set for a supergroup.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate administrator rights.
        /// Use the field <see cref="Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChat"/> requests to check if the bot can use this method.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername).</param>
        /// <param name="stickerSetName">Name of the sticker set to be set as the group sticker set.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatStickerSet(this TelegramBot bot,
            string chatId,
            string stickerSetName,
            CancellationToken cancellationToken = default) =>
            SetChatStickerSet(bot, new()
            {
                ChatId = chatId,
                StickerSetName = stickerSetName
            }, cancellationToken);

        /// <summary>
        /// Use this method to set a new group sticker set for a supergroup.
        /// The bot must be an administrator in the chat for this to work and must have the appropriate administrator rights.
        /// Use the field <see cref="Chat.CanSetStickerSet"/> optionally returned in <see cref="GetChat"/> requests to check if the bot can use this method.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="stickerSet">The sticker set to be set as the group sticker set.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetChatStickerSet(this TelegramBot bot,
            IChat chat,
            StickerSet stickerSet,
            CancellationToken cancellationToken = default) =>
            SetChatStickerSet(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                StickerSetName = stickerSet.Name
            }, cancellationToken);
    }
}
