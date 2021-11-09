using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a file uploaded to Telegram Passport.
    /// Currently all Telegram Passport files are in JPEG format when decrypted and don't exceed 10MB.
    /// </summary>
    public class PassportFile
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
        /// File size in bytes.
        /// </summary>
        [JsonPropertyName("file_size")]
        public int? FileSize { get; set; }
        /// <summary>
        /// Unix time when the file was uploaded.
        /// </summary>
        [JsonPropertyName("file_date")]
        public long? FileDateValue { get; set; }
        /// <summary>
        /// Time when the file was uploaded.
        /// </summary>
        [JsonIgnore]
        public DateTime? FileDate
        {
            get => FileDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(FileDateValue.Value).DateTime : null;
            set => FileDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }

        public override string ToString() => $"{nameof(PassportFile)}[{FileId}, {FileDate}]";
    }
}
