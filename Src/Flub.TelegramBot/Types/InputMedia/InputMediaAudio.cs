using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents an audio file to be treated as music to be sent.
    /// </summary>
    public class InputMediaAudio : InputMediaWithThumb
    {
        /// <summary>
        /// Optional. Duration of the audio in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
        /// <summary>
        /// Optional. Performer of the audio.
        /// </summary>
        [JsonPropertyName("performer")]
        public string Performer { get; set; }
        /// <summary>
        /// Optional. Title of the audio.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaAudio"/> class.
        /// </summary>
        public InputMediaAudio()
            : base(InputMediaType.Audio)
        {

        }
    }
}
