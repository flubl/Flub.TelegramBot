namespace Flub.TelegramBot
{
    /// <summary>
    /// Contains a identifier for a chat.
    /// </summary>
    public interface IChat
    {
        /// <summary>
        /// Unique identifier for this chat.
        /// </summary>
        long? Id { get; }
    }
}
