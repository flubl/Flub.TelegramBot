using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    public class Sticker : IFile
    {
        /// <summary>
        /// Identifier for this file, which can be used to download or reuse the file.
        /// </summary>
        [JsonPropertyName("file_id")]
        public string FileId { get; set; }
        /// <summary>
        /// Unique identifier for this file, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
        /// </summary>
        [JsonPropertyName("file_unique_id")]
        public string FileUniqueId { get; set; }
        /// <summary>
        /// Sticker width.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        /// <summary>
        /// Sticker height.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the sticker is animated
        /// </summary>
        [JsonPropertyName("is_animated")]
        public bool? IsAnimated { get; set; }
        /// <summary>
        /// Optional. Sticker thumbnail in the .WEBP or .JPG format.
        /// </summary>
        [JsonPropertyName("thumb")]
        public PhotoSize Thumb { get; set; }
        /// <summary>
        /// Optional. Emoji associated with the sticker.
        /// </summary>
        [JsonPropertyName("emoji")]
        public string Emoji { get; set; }
        /// <summary>
        /// Optional. Name of the sticker set to which the sticker belongs.
        /// </summary>
        [JsonPropertyName("set_name")]
        public string SetName { get; set; }
        /// <summary>
        /// Optional. For mask stickers, the position where the mask should be placed.
        /// </summary>
        [JsonPropertyName("mask_position")]
        public MaskPosition MaskPosition { get; set; }
        /// <summary>
        /// Optional. File size in bytes.
        /// </summary>
        [JsonPropertyName("file_size")]
        public int? FileSize { get; set; }

        string IFile.Id => FileId;

        public override string ToString() => $"{nameof(Sticker)}[{Width}x{Height}, {FileId}]";
    }
}
