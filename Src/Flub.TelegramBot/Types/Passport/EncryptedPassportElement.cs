using Flub.Utils.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Contains information about documents or other Telegram Passport elements shared with the bot by the user.
    /// </summary>
    public class EncryptedPassportElement
    {
        /// <summary>
        /// Element type.
        /// </summary>
        [JsonPropertyName("type")]
        public EncryptedPassportElementType? Type { get; set; }
        /// <summary>
        /// Optional. Base64-encoded encrypted Telegram Passport element data provided by the user,
        /// available for <see cref="EncryptedPassportElementType.PersonalDetails"/>, <see cref="EncryptedPassportElementType.Passport"/>,
        /// <see cref="EncryptedPassportElementType.DriverLicense"/>, <see cref="EncryptedPassportElementType.IdentityCard"/>,
        /// <see cref="EncryptedPassportElementType.InternalPassport"/> and <see cref="EncryptedPassportElementType.Address"/> types.
        /// Can be decrypted and verified using the accompanying <see cref="EncryptedCredentials"/>.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }
        /// <summary>
        /// Optional. User's verified phone number, available only for <see cref="EncryptedPassportElementType.PhoneNumber"/> type.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Optional. User's verified email address, available only for <see cref="EncryptedPassportElementType.Email"/> type.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
        /// <summary>
        /// Optional. List of encrypted files with documents provided by the user, available for <see cref="EncryptedPassportElementType.UtilityBill"/>,
        /// <see cref="EncryptedPassportElementType.BankStatement"/>, <see cref="EncryptedPassportElementType.RentalAgreement"/>,
        /// <see cref="EncryptedPassportElementType.PassportRegistration"/> and <see cref="EncryptedPassportElementType.TemporaryRegistration"/> types.
        /// Files can be decrypted and verified using the accompanying <see cref="EncryptedCredentials"/>.
        /// </summary>
        [JsonPropertyName("files")]
        public IEnumerable<PassportFile> Files { get; set; }
        /// <summary>
        /// Optional. Encrypted file with the front side of the document, provided by the user.
        /// Available for <see cref="EncryptedPassportElementType.Passport"/>, <see cref="EncryptedPassportElementType.DriverLicense"/>,
        /// <see cref="EncryptedPassportElementType.IdentityCard"/> and <see cref="EncryptedPassportElementType.InternalPassport"/>.
        /// The file can be decrypted and verified using the accompanying <see cref="EncryptedCredentials"/>.
        /// </summary>
        [JsonPropertyName("front_side")]
        public PassportFile FrontSide { get; set; }
        /// <summary>
        /// Optional. Encrypted file with the reverse side of the document, provided by the user.
        /// Available for <see cref="EncryptedPassportElementType.DriverLicense"/> and <see cref="EncryptedPassportElementType.IdentityCard"/>.
        /// The file can be decrypted and verified using the accompanying <see cref="EncryptedCredentials"/>.
        /// </summary>
        [JsonPropertyName("reverse_side")]
        public PassportFile ReverseSide { get; set; }
        /// <summary>
        /// Optional. Encrypted file with the selfie of the user holding a document, provided by the user;
        /// available for <see cref="EncryptedPassportElementType.Passport"/>, <see cref="EncryptedPassportElementType.DriverLicense"/>,
        /// <see cref="EncryptedPassportElementType.IdentityCard"/> and <see cref="EncryptedPassportElementType.InternalPassport"/>.
        /// The file can be decrypted and verified using the accompanying <see cref="EncryptedCredentials"/>.
        /// </summary>
        [JsonPropertyName("selfie")]
        public PassportFile Selfie { get; set; }
        /// <summary>
        /// Optional. List of encrypted files with translated versions of documents provided by the user.
        /// Available if requested for <see cref="EncryptedPassportElementType.Passport"/>, <see cref="EncryptedPassportElementType.DriverLicense"/>,
        /// <see cref="EncryptedPassportElementType.IdentityCard"/>, <see cref="EncryptedPassportElementType.InternalPassport"/>,
        /// <see cref="EncryptedPassportElementType.UtilityBill"/>, <see cref="EncryptedPassportElementType.BankStatement"/>,
        /// <see cref="EncryptedPassportElementType.RentalAgreement"/>, <see cref="EncryptedPassportElementType.PassportRegistration"/>
        /// and <see cref="EncryptedPassportElementType.TemporaryRegistration"/> types.
        /// Files can be decrypted and verified using the accompanying <see cref="EncryptedCredentials"/>.
        /// </summary>
        [JsonPropertyName("translation")]
        public IEnumerable<PassportFile> Translation { get; set; }
        /// <summary>
        /// Base64-encoded element hash for using in <see cref="PassportElementErrorUnspecified"/>.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        public override string ToString() => $"{nameof(EncryptedPassportElement)}[{Type}]";
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum EncryptedPassportElementType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("personal_details")]
        PersonalDetails = 0x1,
        [JsonFieldValue("passport")]
        Passport = 0x2,
        [JsonFieldValue("driver_license")]
        DriverLicense = 0x4,
        [JsonFieldValue("identity_card")]
        IdentityCard = 0x8,
        [JsonFieldValue("internal_passport")]
        InternalPassport = 0x10,
        [JsonFieldValue("address")]
        Address = 0x20,
        [JsonFieldValue("utility_bill")]
        UtilityBill = 0x40,
        [JsonFieldValue("bank_statement")]
        BankStatement = 0x80,
        [JsonFieldValue("rental_agreement")]
        RentalAgreement = 0x100,
        [JsonFieldValue("passport_registration")]
        PassportRegistration = 0x200,
        [JsonFieldValue("temporary_registration")]
        TemporaryRegistration = 0x400,
        [JsonFieldValue("phone_number")]
        PhoneNumber = 0x800,
        [JsonFieldValue("email")]
        Email = 0x1000
    }
}
