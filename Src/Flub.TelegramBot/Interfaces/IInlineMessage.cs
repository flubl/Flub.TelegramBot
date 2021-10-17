namespace Flub.TelegramBot
{
    /// <summary>
    /// Inline message with an inline keyboard attached to it.
    /// </summary>
    public interface IInlineMessage
    {
        /// <summary>
        /// Identifier of the sent inline message.
        /// </summary>
        string InlineMessageId { get; }
    }
}
