using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one size of a photo or a file / sticker thumbnail.
    /// </summary>
    public class PhotoSize : FileBase
    {
        /// <summary>
        /// Photo width.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        /// <summary>
        /// Photo height.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
    }
}
