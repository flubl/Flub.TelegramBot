using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
	/// <summary>
	/// This object represents a voice note.
	/// </summary>
	public class Voice : FileBase
    {
		/// <summary>
		/// Duration of the audio in seconds as defined by sender.
		/// </summary>
		[JsonPropertyName("duration")]
		public int? Duration { get; set; }
		/// <summary>
		/// Optional. MIME type of the file as defined by sender.
		/// </summary>
		[JsonPropertyName("mime_type")]
		public string MimeType { get; set; }

		public override string ToString() => $"{nameof(Voice)}[{Duration}s, {Id}]";
	}
}
