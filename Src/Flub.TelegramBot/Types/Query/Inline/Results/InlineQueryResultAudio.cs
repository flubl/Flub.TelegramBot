using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to an MP3 audio file.
    /// By default, this audio file will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the audio.
    /// </summary>
    public class InlineQueryResultAudio : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid URL for the audio file.
        /// </summary>
        [JsonPropertyName("audio_url")]
        public Uri AudioUrl { get; set; }
        /// <summary>
        /// Title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Performer.
        /// </summary>
        [JsonPropertyName("performer")]
        public string Performer { get; set; }
        /// <summary>
        /// Optional. Audio duration in seconds.
        /// </summary>
        [JsonPropertyName("audio_duration")]
        public int? AudioDurationValue { get; set; }
        /// <summary>
        /// Optional. Audio duration.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? AudioDuration
        {
            get => AudioDurationValue.HasValue ? TimeSpan.FromSeconds(AudioDurationValue.Value) : null;
            set => AudioDurationValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
        }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the audio.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultAudio"/> class.
        /// </summary>
        public InlineQueryResultAudio() : base(InlineQueryResultType.Audio) { }

        public override string ToString() => $"{nameof(InlineQueryResultAudio)}[{Id}, {Title}, {AudioUrl}]";
    }
}
