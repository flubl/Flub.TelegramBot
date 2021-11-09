using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue with the reverse side of a document.
    /// The error is considered resolved when the file with reverse side of the document changes.
    /// </summary>
    public class PassportElementErrorReverseSide : PassportElementError
    {
        /// <summary>
        /// The section of the user's Telegram Passport which has the issue,
        /// one of <see cref="EncryptedPassportElementType.DriverLicense"/>, <see cref="EncryptedPassportElementType.IdentityCard"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// Base64-encoded hash of the file with the reverse side of the document.
        /// </summary>
        [JsonPropertyName("file_hash")]
        public string FileHash { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PassportElementErrorReverseSide"/> class.
        /// </summary>
        public PassportElementErrorReverseSide() : base(PassportElementErrorType.ReverseSide) { }

        public override string ToString() => $"{nameof(PassportElementErrorReverseSide)}[{Type}]";
    }
}
