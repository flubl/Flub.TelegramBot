using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one button of the reply keyboard. For simple text buttons String can be used instead of this object to specify text of the button.
    /// Optional fields <see cref="RequestContact"/>, <see cref="RequestLocation"/>, and <see cref="RequestPoll"/> are mutually exclusive.
    /// </summary>
    public class KeyboardButton
    {
        /// <summary>
        /// Text of the button. If none of the optional fields are used, it will be sent as a message when the button is pressed.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// Optional. If <see langword="true"/>, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only.
        /// </summary>
        [JsonPropertyName("request_contact")]
        public bool? RequestContact { get; set; }
        /// <summary>
        /// Optional. If <see langword="true"/>, the user's current location will be sent when the button is pressed. Available in private chats only.
        /// </summary>
        [JsonPropertyName("request_location")]
        public bool? RequestLocation { get; set; }
        /// <summary>
        /// Optional. If specified, the user will be asked to create a poll and send it to the bot when the button is pressed. Available in private chats only.
        /// </summary>
        [JsonPropertyName("request_poll")]
        public KeyboardButtonPollType RequestPoll { get; set; }

        public override string ToString() => $"{nameof(KeyboardButton)}[{Text}]";

        public static implicit operator KeyboardButton(string text) => new() { Text = text };
    }
}
