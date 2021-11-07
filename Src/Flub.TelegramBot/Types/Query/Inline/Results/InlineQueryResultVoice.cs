using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a voice recording in an .OGG container encoded with OPUS.
    /// By default, this voice recording will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the the voice message.
    /// </summary>
    public class InlineQueryResultVoice : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid URL for the voice recording.
        /// </summary>
        [JsonPropertyName("voice_url")]
        public Uri VoiceUrl { get; set; }
        /// <summary>
        /// Recording title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Recording duration in seconds.
        /// </summary>
        [JsonPropertyName("voice_duration")]
        public int? VoiceDurationValue { get; set; }
        /// <summary>
        /// Optional. Recording duration.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? VoiceDuration
        {
            get => VoiceDurationValue.HasValue ? TimeSpan.FromSeconds(VoiceDurationValue.Value) : null;
            set => VoiceDurationValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
        }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the voice recording.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultVoice"/> class.
        /// </summary>
        public InlineQueryResultVoice() : base(InlineQueryResultType.Voice) { }

        public override string ToString() => $"{nameof(InlineQueryResultVoice)}[{Id}, {Title}, {VoiceUrl}]";
    }
}
