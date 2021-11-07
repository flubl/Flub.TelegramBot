using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to set the thumbnail of a sticker set.
    /// Animated thumbnails can be set for animated sticker sets only.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class SetStickerSetThumb : Method<bool?>, IFileContainer
    {
        /// <summary>
        /// Sticker set name.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string StickerSetName { get; set; }
        /// <summary>
        /// User identifier of the sticker set owner.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// A PNG image with the thumbnail, must be up to 128 kilobytes in size and have width and height exactly 100px, 
        /// or a TGS animation with the thumbnail up to 32 kilobytes in size;
        /// see https://core.telegram.org/animated_stickers#technical-requirements for animated sticker technical requirements.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// Animated sticker set thumbnail can't be uploaded via HTTP URL.
        /// </summary>
        [JsonPropertyName("thumb")]
        public InputFile Thumb { get; set; }

        bool IFileContainer.HasFiles => Thumb?.IsFile ?? false;
        IEnumerable<InputFile> IFileContainer.Files { get { yield return Thumb; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetStickerSetThumb"/> class.
        /// </summary>
        public SetStickerSetThumb() : base("setStickerSetThumb") { }
    }

    public static class SetStickerSetThumbExtension
    {
        private static Task<bool?> SetStickerSetThumb(this TelegramBot bot, SetStickerSetThumb method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to set the thumbnail of a sticker set.
        /// Animated thumbnails can be set for animated sticker sets only.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="stickerSetName">Sticker set name.</param>
        /// <param name="userId">User identifier of the sticker set owner.</param>
        /// <param name="thumb">
        /// A PNG image with the thumbnail, must be up to 128 kilobytes in size and have width and height exactly 100px,
        /// or a TGS animation with the thumbnail up to 32 kilobytes in size;
        /// see https://core.telegram.org/animated_stickers#technical-requirements for animated sticker technical requirements.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// Animated sticker set thumbnail can't be uploaded via HTTP URL.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetStickerSetThumb(this TelegramBot bot,
            string stickerSetName,
            long? userId,
            InputFile thumb = null,
            CancellationToken cancellationToken = default) =>
            SetStickerSetThumb(bot, new()
            {
                StickerSetName = stickerSetName,
                UserId = userId,
                Thumb = thumb
            }, cancellationToken);

        /// <summary>
        /// Use this method to set the thumbnail of a sticker set.
        /// Animated thumbnails can be set for animated sticker sets only.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="stickerSet">Sticker set.</param>
        /// <param name="user">Owner of the sticker set.</param>
        /// <param name="thumb">
        /// A PNG image with the thumbnail, must be up to 128 kilobytes in size and have width and height exactly 100px,
        /// or a TGS animation with the thumbnail up to 32 kilobytes in size;
        /// see https://core.telegram.org/animated_stickers#technical-requirements for animated sticker technical requirements.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// Animated sticker set thumbnail can't be uploaded via HTTP URL.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetStickerSetThumb(this TelegramBot bot,
            StickerSet stickerSet,
            IUser user,
            InputFile thumb = null,
            CancellationToken cancellationToken = default) =>
            SetStickerSetThumb(bot, new()
            {
                StickerSetName = stickerSet.Name,
                UserId = user?.Id,
                Thumb = thumb
            }, cancellationToken);
    }
}
