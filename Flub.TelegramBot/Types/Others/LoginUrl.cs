using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a parameter of the inline keyboard button used to automatically authorize a user. Serves as a great replacement for the <see href="https://core.telegram.org/widgets/login">Telegram Login Widget</see> when the user is coming from Telegram.
    /// </summary>
    public class LoginUrl
    {
        /// <summary>
        /// An HTTP URL to be opened with user authorization data added to the query string when the button is pressed. If the user refuses to provide authorization data, the original URL without information about the user will be opened. The data added is the same as described in <see href="https://core.telegram.org/widgets/login#receiving-authorization-data">Receiving authorization data</see>.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// Optional. New text of the button in forwarded messages.
        /// </summary>
        [JsonPropertyName("forward_text")]
        public string ForwardText { get; set; }
        /// <summary>
        /// Optional. Username of a bot, which will be used for user authorization. If not specified, the current bot's username will be assumed. The url's domain must be the same as the domain linked with the bot. See <see href="https://core.telegram.org/widgets/login#linking-your-domain-to-the-bot">Linking your domain to the bot</see> for more details.
        /// </summary>
        [JsonPropertyName("bot_username")]
        public string BotUsername { get; set; }
        /// <summary>
        /// Optional. Pass True to request the permission for your bot to send messages to the user.
        /// </summary>
        [JsonPropertyName("request_write_access")]
        public bool? RequestWriteAccess { get; set; }
    }
}
