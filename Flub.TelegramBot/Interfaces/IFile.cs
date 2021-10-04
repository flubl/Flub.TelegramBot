namespace Flub.TelegramBot
{
    /// <summary>
    /// Interface of a file with a id stored on the telegram servers.
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// Identifier for this file, which can be used to download or reuse the file.
        /// </summary>
        string Id { get; }
    }
}
