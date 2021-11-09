using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue with the translated version of a document.
    /// The error is considered resolved when a file with the document translation change.
    /// </summary>
    public class PassportElementErrorTranslationFiles : PassportElementError
    {
        /// <summary>
        /// Type of element of the user's Telegram Passport which has the issue, one of <see cref="EncryptedPassportElementType.passport"/>,
        /// <see cref="EncryptedPassportElementType.driver_license"/>, <see cref="EncryptedPassportElementType.identity_card"/>,
        /// <see cref="EncryptedPassportElementType.internal_passport"/>, <see cref="EncryptedPassportElementType.utility_bill"/>,
        /// <see cref="EncryptedPassportElementType.bank_statement"/>, <see cref="EncryptedPassportElementType.rental_agreement"/>,
        /// <see cref="EncryptedPassportElementType.passport_registration"/>, <see cref="EncryptedPassportElementType.temporary_registration"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// List of base64-encoded file hashes.
        /// </summary>
        [JsonPropertyName("file_hashes")]
        public IEnumerable<string> FileHashes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorTranslationFiles"/> class.
        /// </summary>
        public PassportElementErrorTranslationFiles() : base(PassportElementErrorType.TranslationFiles) { }

        public override string ToString() => $"{nameof(PassportElementErrorTranslationFiles)}[{Type}]";
    }
}
