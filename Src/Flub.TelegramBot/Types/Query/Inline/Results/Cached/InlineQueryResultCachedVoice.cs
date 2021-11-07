using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a voice message stored on the Telegram servers.
    /// By default, this voice message will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the voice message.
    /// </summary>
    public class InlineQueryResultCachedVoice : InlineQueryResultWithCaption
    {
        /// <summary>
        /// A valid file identifier for the voice message.
        /// </summary>
        [JsonPropertyName("voice_file_id")]
        public string VoiceFileId { get; set; }
        /// <summary>
        /// Voice message title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the voice message.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedVoice"/> class.
        /// </summary>
        public InlineQueryResultCachedVoice() : base(InlineQueryResultType.Voice) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedVoice)}[{Id}, {Title}, {VoiceFileId}]";
    }
}
