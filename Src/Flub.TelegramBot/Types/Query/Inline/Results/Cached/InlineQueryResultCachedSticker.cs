using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to a sticker stored on the Telegram servers.
    /// By default, this sticker will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the sticker.
    /// </summary>
    public class InlineQueryResultCachedSticker : InlineQueryResult
    {
        /// <summary>
        /// A valid file identifier of the sticker.
        /// </summary>
        [JsonPropertyName("sticker_file_id")]
        public string StickerFileId { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the sticker.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultCachedSticker"/> class.
        /// </summary>
        public InlineQueryResultCachedSticker() : base(InlineQueryResultType.Sticker) { }

        public override string ToString() => $"{nameof(InlineQueryResultCachedSticker)}[{Id}, {StickerFileId}]";
    }
}
