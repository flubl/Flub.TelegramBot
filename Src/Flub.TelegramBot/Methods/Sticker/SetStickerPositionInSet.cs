using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to move a sticker in a set created by the bot to a specific position.
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class SetStickerPositionInSet : Method<bool?>
    {
        /// <summary>
        /// File identifier of the sticker.
        /// </summary>
        [Required]
        [JsonPropertyName("sticker")]
        public string Sticker { get; set; }
        /// <summary>
        /// New sticker position in the set, zero-based.
        /// </summary>
        [Required]
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetStickerPositionInSet"/> class.
        /// </summary>
        public SetStickerPositionInSet() : base("setStickerPositionInSet") { }
    }

    public static class SetStickerPositionInSetExtension
    {
        private static Task<bool?> SetStickerPositionInSet(this TelegramBot bot, SetStickerPositionInSet method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to move a sticker in a set created by the bot to a specific position.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="sticker">File identifier of the sticker.</param>
        /// <param name="position">New sticker position in the set, zero-based.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetStickerPositionInSet(this TelegramBot bot,
            string sticker,
            int? position,
            CancellationToken cancellationToken = default) =>
            SetStickerPositionInSet(bot, new()
            {
                Sticker = sticker,
                Position = position
            }, cancellationToken);

        /// <summary>
        /// Use this method to move a sticker in a set created by the bot to a specific position.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="sticker">The sticker.</param>
        /// <param name="position">New sticker position in the set, zero-based.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetStickerPositionInSet(this TelegramBot bot,
            IFile sticker,
            int? position,
            CancellationToken cancellationToken = default) =>
            SetStickerPositionInSet(bot, new()
            {
                Sticker = sticker?.Id,
                Position = position
            }, cancellationToken);

        /// <summary>
        /// Use this method to move a sticker in a set created by the bot to a specific position.
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="sticker">The sticker.</param>
        /// <param name="position">New sticker position in the set, zero-based.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetStickerPositionInSet(this TelegramBot bot,
            Sticker sticker,
            int? position,
            CancellationToken cancellationToken = default) =>
            SetStickerPositionInSet(bot, new()
            {
                Sticker = sticker?.FileId,
                Position = position
            }, cancellationToken);
    }
}
