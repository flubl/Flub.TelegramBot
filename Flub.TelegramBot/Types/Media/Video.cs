using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    public class Video : Document
    {
        /// <summary>
        /// Video width.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        /// <summary>
        /// Video height.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        /// <summary>
        /// Duration of the video in seconds as defined by sender.
        /// </summary>
        [JsonPropertyName("duration")]
		public int? Duration { get; set; }
    }
}
