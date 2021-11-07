using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a general file (as opposed to photos, voice messages and audio files).
    /// </summary>
    public class Document : FileBase
    {
        /// <summary>
        /// Optional. Document thumbnail as defined by sender.
        /// </summary>
        [JsonPropertyName("thumb")]
        public PhotoSize Thumb { get; set; }
        /// <summary>
        /// Optional. Original filename as defined by sender.
        /// </summary>
        [JsonPropertyName("file_name")]
        public string FileName { get; set; }
        /// <summary>
        /// Optional. MIME type of the file as defined by sender.
        /// </summary>
        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }

        public override string ToString() => $"{nameof(Document)}[{Id}]";
    }
}
