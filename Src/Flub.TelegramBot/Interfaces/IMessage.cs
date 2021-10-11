namespace Flub.TelegramBot
{
    /// <summary>
    /// Contains a identifier for a message.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Unique message identifier.
        /// </summary>
        int? Id { get; }
    }
}
