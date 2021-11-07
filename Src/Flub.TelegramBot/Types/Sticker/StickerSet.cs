using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a sticker set.
    /// </summary>
    public class StickerSet
    {
        /// <summary>
        /// Sticker set name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// Sticker set title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the sticker set contains animated stickers.
        /// </summary>
        [JsonPropertyName("is_animated")]
        public bool? IsAnimated { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the sticker set contains masks
        /// </summary>
        [JsonPropertyName("contains_masks")]
        public bool? ContainsMasks { get; set; }
        /// <summary>
        /// List of all set stickers.
        /// </summary>
        [JsonPropertyName("stickers")]
        public IEnumerable<Sticker> Stickers { get; set; }
        /// <summary>
        /// Optional. Sticker set thumbnail in the .WEBP or .TGS format.
        /// </summary>
        [JsonPropertyName("thumb")]
        public PhotoSize Thumb { get; set; }

        public override string ToString() => $"{nameof(StickerSet)}[{Name},{Title},{Stickers.Count()} stickers]";
    }
}
