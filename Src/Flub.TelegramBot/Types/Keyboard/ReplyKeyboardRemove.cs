using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will remove the current custom keyboard and display the default letter-keyboard.
    /// By default, custom keyboards are displayed until a new keyboard is sent by a bot.
    /// An exception is made for one-time keyboards that are hidden immediately after the user presses a button (see <see cref="ReplyKeyboardMarkup"/>).
    /// </summary>
    public class ReplyKeyboardRemove : ReplyMarkup
    {
        /// <summary>
        /// Requests clients to remove the custom keyboard (user will not be able to summon this keyboard;
        /// if you want to hide the keyboard from sight but keep it accessible, use <see cref="ReplyKeyboardMarkup.OneTimeKeyboard"/> in <see cref="ReplyKeyboardMarkup"/>).
        /// </summary>
        [JsonPropertyName("remove_keyboard")]
        public bool? RemoveKeyboard { get; } = true;
        /// <summary>
        /// Optional. Use this parameter if you want to remove the keyboard for specific users only.
        /// Targets:
        /// 1) users that are @mentioned in the text of the <see cref="Message"/> object;
        /// 2) if the bot's message is a reply (has <see cref="Message.ReplyToMessage"/>), sender of the original message.
        /// </summary>
        [JsonPropertyName("selective")]
        public bool? Selective { get; set; }

        public override string ToString() => nameof(ReplyKeyboardRemove);
    }
}
