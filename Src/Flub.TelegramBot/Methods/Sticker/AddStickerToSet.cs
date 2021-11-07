using Flub.TelegramBot.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to add a new sticker to a set created by the bot.
    /// You must use exactly one of the properties <see cref="PngSticker"/> or <see cref="TgsSticker"/>.
    /// Animated stickers can be added to animated sticker sets and only to them.
    /// Animated sticker sets can have up to 50 stickers.
    /// Static sticker sets can have up to 120 stickers.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class AddStickerToSet : Method<bool?>, IFileContainer
    {
        /// <summary>
        /// User identifier of sticker set owner.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// Sticker set name.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string StickerSetName { get; set; }
        /// <summary>
        /// PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </summary>
        [JsonPropertyName("png_sticker")]
        public InputFile PngSticker { get; set; }
        /// <summary>
        /// TGS animation with the sticker. See https://core.telegram.org/animated_stickers#technical-requirements for technical requirements.
        /// </summary>
        [JsonPropertyName("tgs_sticker")]
        public InputFile TgsSticker { get; set; }
        /// <summary>
        /// One or more emoji corresponding to the sticker.
        /// </summary>
        [Required]
        [JsonPropertyName("emojis")]
        public string Emojis { get; set; }
        /// <summary>
        /// A object for position where the mask should be placed on faces.
        /// </summary>
        [JsonPropertyName("mask_position")]
        public MaskPosition MaskPosition { get; set; }

        bool IFileContainer.HasFiles => ((IFileContainer)this).Files.Any(f => f?.IsFile == true);
        IEnumerable<InputFile> IFileContainer.Files { get { yield return PngSticker; yield return TgsSticker; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddStickerToSet"/> class.
        /// </summary>
        public AddStickerToSet() : base("addStickerToSet") { }
    }

    public static class AddStickerToSetExtension
    {
        private static Task<bool?> AddStickerToSet(this TelegramBot bot, AddStickerToSet method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to add a new sticker to a set created by the bot.
        /// You must use exactly one of the parameters <paramref name="pngSticker"/> or <paramref name="tgsSticker"/>.
        /// Animated stickers can be added to animated sticker sets and only to them.
        /// Animated sticker sets can have up to 50 stickers.
        /// Static sticker sets can have up to 120 stickers.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="userId">User identifier of sticker set owner.</param>
        /// <param name="stickerSetName">Sticker set name.</param>
        /// <param name="pngSticker">
        /// PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="tgsSticker">TGS animation with the sticker. See https://core.telegram.org/animated_stickers#technical-requirements for technical requirements.</param>
        /// <param name="emojis">One or more emoji corresponding to the sticker.</param>
        /// <param name="maskPosition">A object for position where the mask should be placed on faces.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AddStickerToSet(this TelegramBot bot,
            long? userId,
            string stickerSetName,
            string emojis,
            InputFile pngSticker = null,
            InputFile tgsSticker = null,
            MaskPosition maskPosition = null,
            CancellationToken cancellationToken = default) =>
            AddStickerToSet(bot, new()
            {
                UserId = userId,
                StickerSetName = stickerSetName,
                PngSticker = pngSticker,
                TgsSticker = tgsSticker,
                Emojis = emojis,
                MaskPosition = maskPosition
            }, cancellationToken);

        /// <summary>
        /// Use this method to add a new sticker to a set created by the bot.
        /// You must use exactly one of the parameters <paramref name="pngSticker"/> or <paramref name="tgsSticker"/>.
        /// Animated stickers can be added to animated sticker sets and only to them.
        /// Animated sticker sets can have up to 50 stickers.
        /// Static sticker sets can have up to 120 stickers.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Owner of sticker set.</param>
        /// <param name="stickerSet">Sticker set.</param>
        /// <param name="pngSticker">
        /// PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="tgsSticker">TGS animation with the sticker. See https://core.telegram.org/animated_stickers#technical-requirements for technical requirements.</param>
        /// <param name="emojis">One or more emoji corresponding to the sticker.</param>
        /// <param name="maskPosition">A object for position where the mask should be placed on faces.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> AddStickerToSet(this TelegramBot bot,
            IUser user,
            StickerSet stickerSet,
            string emojis,
            InputFile pngSticker = null,
            InputFile tgsSticker = null,
            MaskPosition maskPosition = null,
            CancellationToken cancellationToken = default) =>
            AddStickerToSet(bot, new()
            {
                UserId = user?.Id,
                StickerSetName = stickerSet.Name,
                PngSticker = pngSticker,
                TgsSticker = tgsSticker,
                Emojis = emojis,
                MaskPosition = maskPosition
            }, cancellationToken);
    }
}
