using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue with the front side of a document.
    /// The error is considered resolved when the file with the front side of the document changes.
    /// </summary>
    public class PassportElementErrorFrontSide : PassportElementError
    {
        /// <summary>
        /// The section of the user's Telegram Passport which has the issue,
        /// one of <see cref="EncryptedPassportElementType.Passport"/>, <see cref="EncryptedPassportElementType.DriverLicense"/>,
        /// <see cref="EncryptedPassportElementType.IdentityCard"/>, <see cref="EncryptedPassportElementType.InternalPassport"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// Base64-encoded hash of the file with the front side of the document.
        /// </summary>
        [JsonPropertyName("file_hash")]
        public string FileHash { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorFrontSide"/> class.
        /// </summary>
        public PassportElementErrorFrontSide() : base(PassportElementErrorType.FrontSide) { }

        public override string ToString() => $"{nameof(PassportElementErrorFrontSide)}[{Type}]";
    }
}
