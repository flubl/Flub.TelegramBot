using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Contains information about Telegram Passport data shared with the bot by the user.
    /// </summary>
    public class PassportData
    {
        /// <summary>
        /// List with information about documents and other Telegram Passport elements that was shared with the bot.
        /// </summary>
        [JsonPropertyName("data")]
        public IEnumerable<EncryptedPassportElement> Data { get; set; }
        /// <summary>
        /// Encrypted credentials required to decrypt the data.
        /// </summary>
        [JsonPropertyName("credentials")]
        public EncryptedCredentials Credentials { get; set; }

        public override string ToString() => $"{nameof(PassportData)}[{Data.Count()} elements, {Credentials}]";
    }
}
