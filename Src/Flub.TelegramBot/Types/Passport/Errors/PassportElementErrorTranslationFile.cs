using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue with one of the files that constitute the translation of a document.
    /// The error is considered resolved when the file changes.
    /// </summary>
    public class PassportElementErrorTranslationFile : PassportElementError
    {
        /// <summary>
        /// Type of element of the user's Telegram Passport which has the issue, one of <see cref="EncryptedPassportElementType.passport"/>,
        /// <see cref="EncryptedPassportElementType.driver_license"/>, <see cref="EncryptedPassportElementType.identity_card"/>,
        /// <see cref="EncryptedPassportElementType.internal_passport"/>, <see cref="EncryptedPassportElementType.utility_bill"/>,
        /// <see cref="EncryptedPassportElementType.bank_statement"/>, <see cref="EncryptedPassportElementType.rental_agreement"/>,
        /// <see cref="EncryptedPassportElementType.passport_registration"/>, <see cref="EncryptedPassportElementType.temporary_registration"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// Base64-encoded file hash.
        /// </summary>
        [JsonPropertyName("file_hash")]
        public string FileHash { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorTranslationFile"/> class.
        /// </summary>
        public PassportElementErrorTranslationFile() : base(PassportElementErrorType.TranslationFile) { }

        public override string ToString() => $"{nameof(PassportElementErrorTranslationFile)}[{Type}]";
    }
}
