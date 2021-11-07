using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to delete a sticker from a set created by the bot.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class DeleteStickerFromSet : Method<bool?>
    {
        /// <summary>
        /// File identifier of the sticker.
        /// </summary>
        [Required]
        [JsonPropertyName("sticker")]
        public string Sticker { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStickerFromSet"/> class.
        /// </summary>
        public DeleteStickerFromSet() : base("deleteStickerFromSet") { }
    }

    public static class DeleteStickerFromSetExtension
    {
        private static Task<bool?> DeleteStickerFromSet(this TelegramBot bot, DeleteStickerFromSet method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to delete a sticker from a set created by the bot.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="sticker">File identifier of the sticker.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteStickerFromSet(this TelegramBot bot,
            string sticker,
            CancellationToken cancellationToken = default) =>
            DeleteStickerFromSet(bot, new DeleteStickerFromSet
            {
                Sticker = sticker
            }, cancellationToken);

        /// <summary>
        /// Use this method to delete a sticker from a set created by the bot.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="sticker">The sticker.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteStickerFromSet(this TelegramBot bot,
            IFile sticker,
            CancellationToken cancellationToken = default) =>
            DeleteStickerFromSet(bot, new DeleteStickerFromSet
            {
                Sticker = sticker?.Id
            }, cancellationToken);

        /// <summary>
        /// Use this method to delete a sticker from a set created by the bot.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="sticker">The sticker.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> DeleteStickerFromSet(this TelegramBot bot,
            Sticker sticker,
            CancellationToken cancellationToken = default) =>
            DeleteStickerFromSet(bot, new DeleteStickerFromSet
            {
                Sticker = sticker?.FileId
            }, cancellationToken);
    }
}
