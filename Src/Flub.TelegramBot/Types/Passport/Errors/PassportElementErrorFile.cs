using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue with a document scan.
    /// The error is considered resolved when the file with the document scan changes.
    /// </summary>
    public class PassportElementErrorFile : PassportElementError
    {
        /// <summary>
        /// The section of the user's Telegram Passport which has the issue, one of <see cref="EncryptedPassportElementType.UtilityBill"/>,
        /// <see cref="EncryptedPassportElementType.BankStatement"/>, <see cref="EncryptedPassportElementType.RentalAgreement"/>,
        /// <see cref="EncryptedPassportElementType.PassportRegistration"/>, <see cref="EncryptedPassportElementType.TemporaryRegistration"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// Base64-encoded file hash.
        /// </summary>
        [JsonPropertyName("file_hash")]
        public string FileHash { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorFile"/> class.
        /// </summary>
        public PassportElementErrorFile() : base(PassportElementErrorType.File) { }

        public override string ToString() => $"{nameof(PassportElementErrorFile)}[{Type}]";
    }
}
