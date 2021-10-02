using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a video message (available in Telegram apps as of v.4.0).
    /// </summary>
    public class VideoNote : FileBase
    {
		/// <summary>
		/// Video width and height(diameter of the video message) as defined by sender.
		/// </summary>
		[JsonPropertyName("length")]
		public int? Length { get; set; }
		/// <summary>
		/// Duration of the video in seconds as defined by sender.
		/// </summary>
		[JsonPropertyName("duration")]
		public int? Duration { get; set; }
		/// <summary>
		/// Optional. Video thumbnail.
		/// </summary>
		[JsonPropertyName("thumb")]
		public PhotoSize Thumb { get; set; }
    }
}
