using Flub.TelegramBot.Methods;
using Flub.TelegramBot.Types;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot
{
    public partial class TelegramBot
    {
        /// <summary>
        /// Sends a <see cref="GetFile"/> request for the specifed file and starts to download the file.
        /// </summary>
        /// <param name="file">The file to download.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<System.IO.Stream> DownloadFile(IFile file, CancellationToken cancellationToken = default)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));
            return await DownloadFile(await this.GetFile(file, cancellationToken), cancellationToken);
        }

        /// <summary>
        /// Starts the download for the specified file.
        /// </summary>
        /// <param name="file">The file to download.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public Task<System.IO.Stream> DownloadFile(File file, CancellationToken cancellationToken = default)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));
            return client.GetStreamAsync($"https://api.telegram.org/file/bot{token}/{file.FilePath}", cancellationToken);
        }
    }
}
