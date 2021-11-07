using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to an MP3 audio file stored on the Telegram servers.
    /// By default, this audio file will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the audio.
    /// </summary>
    public class InlineQueryResultCachedAudio : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid file identifier for the audio file.
        /// </summary>
        [JsonPropertyName("audio_file_id")]
        public string AudioFileId { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the audio.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedAudio"/> class.
        /// </summary>
        public InlineQueryResultCachedAudio() : base(InlineQueryResultType.Audio) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedAudio)}[{Id}, {AudioFileId}]";
    }
}
