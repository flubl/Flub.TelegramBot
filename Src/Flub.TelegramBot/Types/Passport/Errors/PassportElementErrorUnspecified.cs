using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue in an unspecified place.
    /// The error is considered resolved when new data is added.
    /// </summary>
    public class PassportElementErrorUnspecified : PassportElementError
    {
        /// <summary>
        /// Type of element of the user's Telegram Passport which has the issue.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// Base64-encoded element hash.
        /// </summary>
        [JsonPropertyName("element_hash")]
        public string ElementHash { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorUnspecified"/> class.
        /// </summary>
        public PassportElementErrorUnspecified() : base(PassportElementErrorType.Unspecified) { }

        public override string ToString() => $"{nameof(PassportElementErrorUnspecified)}[{Type}]";
    }
}
