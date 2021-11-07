using System;
using System.Text.Json.Serialization;
using System.Threading;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a file ready to be downloaded.
    /// The file can be downloaded via the link https://api.telegram.org/file/bot{token}/{file_path} or
    /// <see cref="TelegramBot.DownloadFile(File, CancellationToken)"/>.
    /// It is guaranteed that the link will be valid for at least 1 hour.
    /// When the link expires, a new one can be requested by calling <see cref="Methods.GetFile"/>.
    /// Maximum file size to download is 20 MB.
    /// </summary>
    public class File : FileBase
    {
        /// <summary>
        /// Optional. File path. Use https://api.telegram.org/file/bot{token}/{file_path} or <see cref="TelegramBot.DownloadFile(File, CancellationToken)"/> to get the file.
        /// </summary>
        [JsonPropertyName("file_path")]
        public Uri FilePath { get; set; }

        public override string ToString() => $"{nameof(File)}[{Id}, {FilePath}]";
    }
}
