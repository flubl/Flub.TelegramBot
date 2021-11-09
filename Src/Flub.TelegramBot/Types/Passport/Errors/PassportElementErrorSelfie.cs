using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue with the selfie with a document.
    /// The error is considered resolved when the file with the selfie changes.
    /// </summary>
    public class PassportElementErrorSelfie : PassportElementError
    {
        /// <summary>
        /// The section of the user's Telegram Passport which has the issue,
        /// one of <see cref="EncryptedPassportElementType.Passport"/>, <see cref="EncryptedPassportElementType.DriverLicense"/>,
        /// <see cref="EncryptedPassportElementType.IdentityCard"/>, <see cref="EncryptedPassportElementType.InternalPassport"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// Base64-encoded hash of the file with the selfie.
        /// </summary>
        [JsonPropertyName("file_hash")]
        public string FileHash { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorSelfie"/> class.
        /// </summary>
        public PassportElementErrorSelfie() : base(PassportElementErrorType.Selfie) { }

        public override string ToString() => $"{nameof(PassportElementErrorSelfie)}[{Type}]";
    }
}
