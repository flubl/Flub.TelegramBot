using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Mode for parsing texts. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum ParseMode : int
    {
        [JsonIgnore]
        None = 0,
        [JsonFieldValue("HTML")]
        HTML = 0x1,
        [JsonFieldValue("Markdown")]
        Markdown = 0x2,
        [JsonFieldValue("MarkdownV2")]
        MarkdownV2 = 0x4
    }
}
