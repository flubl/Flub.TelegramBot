using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    public class Video : Document
    {
		/// <summary>
		/// Duration of the document in seconds as defined by sender.
		/// </summary>
		[JsonPropertyName("duration")]
		public int? Duration { get; set; }
    }
}
