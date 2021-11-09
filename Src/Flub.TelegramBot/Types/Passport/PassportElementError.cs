using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an error in the Telegram Passport element which was submitted that should be resolved by the user. It should be one of:
    /// <see cref="PassportElementErrorDataField"/>,
    /// <see cref="PassportElementErrorFrontSide"/>,
    /// <see cref="PassportElementErrorReverseSide"/>,
    /// <see cref="PassportElementErrorSelfie"/>,
    /// <see cref="PassportElementErrorFile"/>,
    /// <see cref="PassportElementErrorFiles"/>,
    /// <see cref="PassportElementErrorTranslationFile"/>,
    /// <see cref="PassportElementErrorTranslationFiles"/>,
    /// <see cref="PassportElementErrorUnspecified"/>.
    /// </summary>
    public abstract class PassportElementError
    {
        /// <summary>
        /// Error source.
        /// </summary>
        [JsonPropertyName("source")]
        public PassportElementErrorType? Source { get; }
        /// <summary>
        /// Error message.
        /// </summary>
        [JsonPropertyName("message")]
        public string ErrorMessage { get; set; }

        protected PassportElementError(PassportElementErrorType source)
        {
            Source = source;
        }

        public override string ToString() => $"{nameof(EncryptedPassportElement)}[{Source}]";
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum PassportElementErrorType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("data")]
        Data = 0x1,
        [JsonFieldValue("front_side")]
        FrontSide = 0x2,
        [JsonFieldValue("reverse_side")]
        ReverseSide = 0x4,
        [JsonFieldValue("selfie")]
        Selfie = 0x8,
        [JsonFieldValue("file")]
        File = 0x10,
        [JsonFieldValue("files")]
        Files = 0x20,
        [JsonFieldValue("translation_file")]
        TranslationFile = 0x40,
        [JsonFieldValue("translation_files")]
        TranslationFiles = 0x80,
        [JsonFieldValue("unspecified")]
        Unspecified = 0x100
    }
}
