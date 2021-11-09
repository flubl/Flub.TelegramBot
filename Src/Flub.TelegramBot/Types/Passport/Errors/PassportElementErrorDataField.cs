using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an issue in one of the data fields that was provided by the user.
    /// The error is considered resolved when the field's value changes.
    /// </summary>
    public class PassportElementErrorDataField : PassportElementError
    {
        /// <summary>
        /// The section of the user's Telegram Passport which has the error, one of
        /// <see cref="EncryptedPassportElementType.PersonalDetails"/>, <see cref="EncryptedPassportElementType.Passport"/>,
        /// <see cref="EncryptedPassportElementType.DriverLicense"/>, <see cref="EncryptedPassportElementType.IdentityCard"/>,
        /// <see cref="EncryptedPassportElementType.InternalPassport"/>, <see cref="EncryptedPassportElementType.Address"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// Name of the data field which has the error.
        /// </summary>
        [JsonPropertyName("field_name")]
        public string FieldName { get; set; }
        /// <summary>
        /// Base64-encoded data hash.
        /// </summary>
        [JsonPropertyName("data_hash")]
        public string DataHash { get; set; }

        public PassportElementErrorDataField() : base(PassportElementErrorType.Data) { }

        public override string ToString() => $"{nameof(PassportElementErrorDataField)}[{Type}, {FieldName}]";
    }
}
