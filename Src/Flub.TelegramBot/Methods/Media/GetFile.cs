using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get basic info about a file and prepare it for downloading.
    /// For the moment, bots can download files of up to 20MB in size.
    /// On success, a <see cref="File"/> object is returned.
    /// The file can then be downloaded using <see cref="TelegramBot.DownloadFile(File, CancellationToken)"/> or
    /// via the link https://api.telegram.org/file/bot{token}/{file_path}, where {file_path} is taken from the response.
    /// It is guaranteed that the link will be valid for at least 1 hour.
    /// When the link expires, a new one can be requested by calling <see cref="GetFile"/> again.
    /// </summary>
    public class GetFile : Method<File>
    {
        /// <summary>
        /// File identifier to get info about.
        /// </summary>
        [Required]
        [JsonPropertyName("file_id")]
        public string FileId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFile"/> class.
        /// </summary>
        public GetFile() : base("getFile") { }
    }

    public static class GetFileExtension
    {
        private static Task<File> GetFile(this TelegramBot bot, GetFile method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get basic info about a file and prepare it for downloading.
        /// For the moment, bots can download files of up to 20MB in size.
        /// On success, a <see cref="File"/> object is returned.
        /// The file can then be downloaded using <see cref="TelegramBot.DownloadFile(File, CancellationToken)"/> or
        /// via the link https://api.telegram.org/file/bot{token}/{file_path}, where {file_path} is taken from the response.
        /// It is guaranteed that the link will be valid for at least 1 hour.
        /// When the link expires, a new one can be requested by calling <see cref="GetFile"/> again.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="fileId">File identifier to get info about.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<File> GetFile(this TelegramBot bot,
            string fileId,
            CancellationToken cancellationToken = default) =>
            GetFile(bot, new GetFile
            {
                FileId = fileId
            }, cancellationToken);

        /// <summary>
        /// Use this method to get basic info about a file and prepare it for downloading.
        /// For the moment, bots can download files of up to 20MB in size.
        /// On success, a <see cref="File"/> object is returned.
        /// The file can then be downloaded using <see cref="TelegramBot.DownloadFile(File, CancellationToken)"/> or
        /// via the link https://api.telegram.org/file/bot{token}/{file_path}, where {file_path} is taken from the response.
        /// It is guaranteed that the link will be valid for at least 1 hour.
        /// When the link expires, a new one can be requested by calling <see cref="GetFile"/> again.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="file">File to get info about.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<File> GetFile(this TelegramBot bot,
            IFile file,
            CancellationToken cancellationToken = default) =>
            GetFile(bot, new GetFile
            {
                FileId = file?.Id
            }, cancellationToken);
    }
}
