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
    /// Use this method to create a new sticker set owned by a user.
    /// The bot will be able to edit the sticker set thus created.
    /// You must use exactly one of the properties <see cref="PngSticker"/> or <see cref="TgsSticker"/>.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class CreateNewStickerSet : Method<bool?>, IFileContainer
    {
        /// <summary>
        /// User identifier of created sticker set owner.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// Short name of sticker set, to be used in t.me/addstickers/ URLs (e.g., animals).
        /// Can contain only english letters, digits and underscores.
        /// Must begin with a letter, can't contain consecutive underscores and must end in "_by_{bot username}". {bot_username} is case insensitive. 1-64 characters.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string StickerSetName { get; set; }
        /// <summary>
        /// Sticker set title, 1-64 characters.
        /// </summary>
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
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
        /// Pass <see langword="true"/>, if a set of mask stickers should be created.
        /// </summary>
        [JsonPropertyName("contains_masks")]
        public bool? ContainsMasks { get; set; }
        /// <summary>
        /// A object for position where the mask should be placed on faces.
        /// </summary>
        [JsonPropertyName("mask_position")]
        public MaskPosition MaskPosition { get; set; }

        bool IFileContainer.HasFiles => ((IFileContainer)this).Files.Any(f => f?.IsFile == true);
        IEnumerable<InputFile> IFileContainer.Files { get { yield return PngSticker; yield return TgsSticker; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewStickerSet"/> class.
        /// </summary>
        public CreateNewStickerSet() : base("createNewStickerSet") { }
    }

    public static class CreateNewStickerSetExtension
    {
        private static Task<bool?> CreateNewStickerSet(this TelegramBot bot, CreateNewStickerSet method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to create a new sticker set owned by a user.
        /// The bot will be able to edit the sticker set thus created.
        /// You must use exactly one of the parameters <paramref name="pngSticker"/> or <paramref name="tgsSticker"/>.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="userId">User identifier of created sticker set owner.</param>
        /// <param name="stickerSetName">
        /// Short name of sticker set, to be used in t.me/addstickers/ URLs (e.g., animals).
        /// Can contain only english letters, digits and underscores.
        /// Must begin with a letter, can't contain consecutive underscores and must end in "_by_{bot username}". {bot_username} is case insensitive. 1-64 characters.
        /// </param>
        /// <param name="title">Sticker set title, 1-64 characters.</param>
        /// <param name="pngSticker">
        /// PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="tgsSticker">TGS animation with the sticker. See https://core.telegram.org/animated_stickers#technical-requirements for technical requirements.</param>
        /// <param name="emojis">One or more emoji corresponding to the sticker.</param>
        /// <param name="containsMasks">Pass <see langword="true"/>, if a set of mask stickers should be created.</param>
        /// <param name="maskPosition">A object for position where the mask should be placed on faces.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> CreateNewStickerSet(this TelegramBot bot,
            long? userId,
            string stickerSetName,
            string title,
            string emojis,
            InputFile pngSticker = null,
            InputFile tgsSticker = null,
            bool? containsMasks = null,
            MaskPosition maskPosition = null,
            CancellationToken cancellationToken = default) =>
            CreateNewStickerSet(bot, new()
            {
                UserId = userId,
                StickerSetName = stickerSetName,
                Title = title,
                PngSticker = pngSticker,
                TgsSticker = tgsSticker,
                Emojis = emojis,
                ContainsMasks = containsMasks,
                MaskPosition = maskPosition
            }, cancellationToken);

        /// <summary>
        /// Use this method to create a new sticker set owned by a user.
        /// The bot will be able to edit the sticker set thus created.
        /// You must use exactly one of the parameters <paramref name="pngSticker"/> or <paramref name="tgsSticker"/>.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Owner of created sticker set.</param>
        /// <param name="stickerSetName">
        /// Short name of sticker set, to be used in t.me/addstickers/ URLs (e.g., animals).
        /// Can contain only english letters, digits and underscores.
        /// Must begin with a letter, can't contain consecutive underscores and must end in "_by_{bot username}". {bot_username} is case insensitive. 1-64 characters.
        /// </param>
        /// <param name="title">Sticker set title, 1-64 characters.</param>
        /// <param name="pngSticker">
        /// PNG image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px.
        /// Pass a file id as <see cref="string"/> or <see cref="Sticker"/> (<see cref="FileBase"/>) to send a file that exists on the Telegram servers,
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </param>
        /// <param name="tgsSticker">TGS animation with the sticker. See https://core.telegram.org/animated_stickers#technical-requirements for technical requirements.</param>
        /// <param name="emojis">One or more emoji corresponding to the sticker.</param>
        /// <param name="containsMasks">Pass <see langword="true"/>, if a set of mask stickers should be created.</param>
        /// <param name="maskPosition">A object for position where the mask should be placed on faces.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> CreateNewStickerSet(this TelegramBot bot,
            IUser user,
            string stickerSetName,
            string title,
            string emojis,
            InputFile pngSticker = null,
            InputFile tgsSticker = null,
            bool? containsMasks = null,
            MaskPosition maskPosition = null,
            CancellationToken cancellationToken = default) =>
            CreateNewStickerSet(bot, new()
            {
                UserId = user?.Id,
                StickerSetName = stickerSetName,
                Title = title,
                PngSticker = pngSticker,
                TgsSticker = tgsSticker,
                Emojis = emojis,
                ContainsMasks = containsMasks,
                MaskPosition = maskPosition
            }, cancellationToken);
    }
}
