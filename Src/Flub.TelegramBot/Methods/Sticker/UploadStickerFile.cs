using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to upload a .PNG file with a sticker for later use in <see cref="CreateNewStickerSet"/> and <see cref="AddStickerToSet"/> methods (can be used multiple times).
    /// Returns the uploaded <see cref="File"/> on success.
    /// </summary>
    public class UploadStickerFile : Method<File>, IFileContainer
    {
        /// <summary>
        /// User identifier of sticker file owner.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.
        /// </summary>
        [Required]
        [JsonPropertyName("png_sticker")]
        public InputFile PngSticker { get; set; }

        bool IFileContainer.HasFiles => PngSticker?.IsFile ?? false;
        IEnumerable<InputFile> IFileContainer.Files { get { yield return PngSticker; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadStickerFile"/> class.
        /// </summary>
        public UploadStickerFile() : base("uploadStickerFile") { }
    }

    public static class UploadStickerFileExtension
    {
        private static Task<File> UploadStickerFile(this TelegramBot bot, UploadStickerFile method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to upload a .PNG file with a sticker for later use in <see cref="CreateNewStickerSet"/> and <see cref="AddStickerToSet"/> methods (can be used multiple times).
        /// Returns the uploaded <see cref="File"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="userId">User identifier of sticker file owner.</param>
        /// <param name="pngSticker">PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<File> UploadStickerFile(this TelegramBot bot,
            long? userId,
            InputFile pngSticker,
            CancellationToken cancellationToken = default) =>
            UploadStickerFile(bot, new()
            {
                UserId = userId,
                PngSticker = pngSticker
            }, cancellationToken);

        /// <summary>
        /// Use this method to upload a .PNG file with a sticker for later use in <see cref="CreateNewStickerSet"/> and <see cref="AddStickerToSet"/> methods (can be used multiple times).
        /// Returns the uploaded <see cref="File"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Owner of sticker file.</param>
        /// <param name="pngSticker">PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<File> UploadStickerFile(this TelegramBot bot,
            IUser user,
            InputFile pngSticker,
            CancellationToken cancellationToken = default) =>
            UploadStickerFile(bot, new()
            {
                UserId = user?.Id,
                PngSticker = pngSticker
            }, cancellationToken);
    }
}
