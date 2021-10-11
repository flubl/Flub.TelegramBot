using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Base class for files stored on the telegram servers.
    /// </summary>
    public abstract class FileBase : IFile
    {
        /// <summary>
        /// Identifier for this file, which can be used to download or reuse the file.
        /// </summary>
        [JsonPropertyName("file_id")]
        public string Id { get; set; }
        /// <summary>
        /// Unique identifier for this file, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
        /// </summary>
        [JsonPropertyName("file_unique_id")]
        public string UniqueId { get; set; }
        /// <summary>
        /// Optional. File size.
        /// </summary>
        [JsonPropertyName("file_size")]
        public int? Size { get; set; }
    }
}
