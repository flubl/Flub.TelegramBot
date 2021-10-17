using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see>
    /// that appears right next to the message it belongs to.
    /// </summary>
    public class InlineKeyboardMarkup : ReplyMarkup
    {
        /// <summary>
        /// List of button rows, each represented by a list of <see cref="InlineKeyboardButton"/> objects.
        /// </summary>
        [JsonPropertyName("inline_keyboard")]
        public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard { get; set; }
    }
}
