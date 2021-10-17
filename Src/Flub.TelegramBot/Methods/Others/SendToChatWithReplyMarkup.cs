using Flub.TelegramBot.Types;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Base class of a request method send to a chat with a reply markup.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class SendToChatWithReplyMarkup<TResult> : SendToChat<TResult>
    {
        /// <summary>
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public ReplyMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendToChatWithReplyMarkup{TResult}"/> class with a specified request method.
        /// </summary>
        /// <param name="name">The name of the request method.</param>
        protected SendToChatWithReplyMarkup(string name) : base(name) { }
    }
}
