using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue with a list of scans.
    /// The error is considered resolved when the list of files containing the scans changes.
    /// </summary>
    public class PassportElementErrorFiles : PassportElementError
    {
        /// <summary>
        /// The section of the user's Telegram Passport which has the issue, one of <see cref="EncryptedPassportElementType.UtilityBill"/>,
        /// <see cref="EncryptedPassportElementType.BankStatement"/>, <see cref="EncryptedPassportElementType.RentalAgreement"/>,
        /// <see cref="EncryptedPassportElementType.PassportRegistration"/>, <see cref="EncryptedPassportElementType.TemporaryRegistration"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// List of base64-encoded file hashes.
        /// </summary>
        [JsonPropertyName("file_hashes")]
        public IEnumerable<string> FileHashes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorFiles"/> class.
        /// </summary>
        public PassportElementErrorFiles() : base(PassportElementErrorType.Files) { }

        public override string ToString() => $"{nameof(PassportElementErrorFiles)}[{Type}]";
    }
}
