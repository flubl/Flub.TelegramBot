using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an audio file to be treated as music by the Telegram clients.
    /// </summary>
    public class Audio : Video
    {
        /// <summary>
        /// Optional. Performer of the audio as defined by sender or by audio tags.
        /// </summary>
        [JsonPropertyName("performer")]
        public string Performer { get; set; }
        /// <summary>
        /// Optional. Title of the audio as defined by sender or by audio tags.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
