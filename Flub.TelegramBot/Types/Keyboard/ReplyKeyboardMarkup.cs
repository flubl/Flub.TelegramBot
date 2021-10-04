using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a custom keyboard with reply options (see <see href="https://core.telegram.org/bots#keyboards">Introduction to bots</see> for details and examples).
    /// </summary>
    public class ReplyKeyboardMarkup : ReplyMarkup
    {
        /// <summary>
        /// List of button rows, each represented by a list of KeyboardButton objects.
        /// </summary>
        [JsonPropertyName("keyboard")]
        public IEnumerable<IEnumerable<KeyboardButton>> Keyboard { get; set; }
        /// <summary>
        /// Optional. Requests clients to resize the keyboard vertically for optimal fit (e.g., make the keyboard smaller if there are just two rows of buttons). Defaults to false, in which case the custom keyboard is always of the same height as the app's standard keyboard.
        /// </summary>
        [JsonPropertyName("resize_keyboard")]
        public bool? ResizeKeyboard { get; set; }
        /// <summary>
        /// Optional. Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat – the user can press a special button in the input field to see the custom keyboard again. Defaults to false.
        /// </summary>
        [JsonPropertyName("one_time_keyboard")]
        public bool? OneTimeKeyboard { get; set; }
        /// <summary>
        /// Optional. The placeholder to be shown in the input field when the keyboard is active; 1-64 characters.
        /// </summary>
        [JsonPropertyName("input_field_placeholder")]
        public string InputFieldPlaceholder { get; set; }
        /// <summary>
        /// Optional. Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        [JsonPropertyName("selective")]
        public bool? Selective { get; set; }
    }
}
