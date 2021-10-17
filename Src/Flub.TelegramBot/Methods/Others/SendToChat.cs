using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Base class of a request method send to a chat.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class SendToChat<TResult> : Method<TResult>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        [JsonPropertyName("disable_notification")]
        public bool? DisableNotification { get; set; }
        /// <summary>
        /// If the message is a reply, ID of the original message.
        /// </summary>
        [JsonPropertyName("reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }
        /// <summary>
        /// Pass <see cref="true"/>, if the message should be sent even if the specified replied-to message is not found.
        /// </summary>
        [JsonPropertyName("allow_sending_without_reply")]
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendToChat{TResult}"/> class with a specified request method.
        /// </summary>
        /// <param name="name">The name of the request method.</param>
        protected SendToChat(string name) : base(name) { }
    }
}
