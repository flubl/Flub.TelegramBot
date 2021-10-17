using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
    /// </summary>
    public class InlineKeyboardButton
    {
        /// <summary>
        /// Label text on the button.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// Optional. HTTP or tg:// url to be opened when button is pressed.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// Optional. An HTTP URL used to automatically authorize the user.
        /// Can be used as a replacement for the <see href="https://core.telegram.org/widgets/login">Telegram Login Widget</see>.
        /// </summary>
        [JsonPropertyName("login_url")]
        public LoginUrl LoginUrl { get; set; }
        /// <summary>
        /// Optional. Data to be sent in a <see cref="CallbackQuery">callback query</see> to the bot when button is pressed, 1-64 bytes.
        /// </summary>
        [JsonPropertyName("callback_data")]
        public string CallbackData { get; set; }
        /// <summary>
        /// Optional. If set, pressing the button will prompt the user to select one of their chats,
        /// open that chat and insert the bot's username and the specified inline query in the input field.
        /// Can be empty, in which case just the bot's username will be inserted.
        /// </summary>
        [JsonPropertyName("switch_inline_query")]
        public string SwitchInlineQuery { get; set; }
        /// <summary>
        /// Optional. If set, pressing the button will insert the bot's username
        /// and the specified inline query in the current chat's input field.
        /// Can be empty, in which case only the bot's username will be inserted.
        /// </summary>
        [JsonPropertyName("switch_inline_query_current_chat")]
        public string SwitchInlineQueryCurrentChat { get; set; }
        /// <summary>
        /// Optional. Description of the game that will be launched when the user presses the button.
        /// NOTE: This type of button must always be the first button in the first row.
        /// </summary>
        [JsonPropertyName("callback_game")]
        public CallbackGame CallbackGame { get; set; }
        /// <summary>
        /// Optional. Specify <see cref="true"/>, to send a <see cref="Payments">Pay button</see>.
        /// NOTE: This type of button must always be the first button in the first row.
        /// </summary>
        [JsonPropertyName("pay")]
        public bool? Pay { get; set; }
    }
}
