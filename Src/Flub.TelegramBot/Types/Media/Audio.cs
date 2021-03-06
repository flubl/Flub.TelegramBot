using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an audio file to be treated as music by the Telegram clients.
    /// </summary>
    public class Audio : Document
    {
        /// <summary>
        /// Duration of the audio in seconds as defined by sender.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
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

        public override string ToString() => $"{nameof(Audio)}[{Duration}s, {Id}]";
    }
}
