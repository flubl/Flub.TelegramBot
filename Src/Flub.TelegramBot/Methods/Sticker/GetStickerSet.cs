using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get a sticker set.
    /// On success, a <see cref="StickerSet"/> is returned.
    /// </summary>
    public class GetStickerSet : Method<StickerSet>
    {
        /// <summary>
        /// Name of the sticker set.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string StickerSetName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStickerSet"/> class.
        /// </summary>
        public GetStickerSet() : base("getStickerSet") { }
    }

    public static class GetStickerSetExtension
    {
        private static Task<StickerSet> GetStickerSet(this TelegramBot bot, GetStickerSet method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get a sticker set.
        /// On success, a <see cref="StickerSet"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="stickerSetName">Name of the sticker set.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<StickerSet> GetStickerSet(this TelegramBot bot,
            string stickerSetName,
            CancellationToken cancellationToken = default) =>
            GetStickerSet(bot, new GetStickerSet
            {
                StickerSetName = stickerSetName
            }, cancellationToken);

        /// <summary>
        /// Use this method to get a sticker set.
        /// On success, a <see cref="StickerSet"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="stickerSet">The sticker set.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<StickerSet> GetStickerSet(this TelegramBot bot,
            StickerSet stickerSet,
            CancellationToken cancellationToken = default) =>
            GetStickerSet(bot, new GetStickerSet
            {
                StickerSetName = stickerSet.Name
            }, cancellationToken);
    }
}
