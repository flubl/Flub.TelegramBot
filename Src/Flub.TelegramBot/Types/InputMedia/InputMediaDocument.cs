using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a general file to be sent.
    /// </summary>
    public class InputMediaDocument : InputMediaWithThumb
    {
        /// <summary>
        /// Optional. Disables automatic server-side content type detection for files uploaded. Always true, if the document is sent as part of an album.
        /// </summary>
        [JsonPropertyName("disable_content_type_detection")]
        public bool? DisableContentTypeDetection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaDocument"/> class.
        /// </summary>
        public InputMediaDocument()
            : base(InputMediaType.Document)
        {

        }
    }
}
