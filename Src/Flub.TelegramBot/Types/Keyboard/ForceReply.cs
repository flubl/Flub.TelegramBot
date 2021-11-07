using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user (act as if the user has selected the bot's message and tapped 'Reply').
    /// This can be extremely useful if you want to create user-friendly step-by-step interfaces
    /// without having to sacrifice <see href="https://core.telegram.org/bots#privacy-mode">privacy mode</see>.
    /// </summary>
    public class ForceReply : ReplyMarkup
    {
        /// <summary>
        /// Shows reply interface to the user, as if they manually selected the bot's message and tapped 'Reply'.
        /// </summary>
        [JsonPropertyName("force_reply")]
        public bool? ForceReplyValue { get; } = true;
        /// <summary>
        /// Optional. The placeholder to be shown in the input field when the reply is active; 1-64 characters.
        /// </summary>
        [JsonPropertyName("input_field_placeholder")]
        public string InputFieldPlaceholder { get; set; }
        /// <summary>
        /// Optional. Use this parameter if you want to force reply from specific users only.
        /// Targets: 
        /// 1) users that are @mentioned in the text of the <see cref="Message">Message</see> object;
        /// 2) if the bot's message is a reply (has <see cref="Message.ReplyToMessage"/>), sender of the original message.
        /// </summary>
        [JsonPropertyName("selective")]
        public bool? Selective { get; set; }

        public override string ToString() => nameof(ForceReply);
    }
}
