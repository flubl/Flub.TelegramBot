using System.Collections.Generic;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Container for files to be uploaded.
    /// </summary>
    public interface IFileContainer
    {
        /// <summary>
        /// <see langword="true"/> if there are files to be uploaded.
        /// </summary>
        bool HasFiles { get; }
        /// <summary>
        /// The files to be uploaded.
        /// </summary>
        IEnumerable<InputFile> Files { get; }
    }
}
