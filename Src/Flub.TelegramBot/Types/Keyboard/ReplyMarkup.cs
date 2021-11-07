using Flub.Utils.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Additional interface options. A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see>, <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see>, instructions to remove reply keyboard or to force a reply from the user.
    /// </summary>
    [JsonConverter(typeof(JsonConvertByGetTypeConverter))]
    public abstract class ReplyMarkup
    {
    }
}
