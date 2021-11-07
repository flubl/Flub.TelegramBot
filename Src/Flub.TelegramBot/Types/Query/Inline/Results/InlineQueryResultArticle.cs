using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a link to an article or web page.
    /// </summary>
    public class InlineQueryResultArticle : InlineQueryResult
    {
        /// <summary>
        /// Title of the result.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Content of the message to be sent.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }
        /// <summary>
        /// Optional. URL of the result.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if you don't want the URL to be shown in the message.
        /// </summary>
        [JsonPropertyName("hide_url")]
        public bool? HideUrl { get; set; }
        /// <summary>
        /// Optional. Short description of the result.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Optional. Url of the thumbnail for the result.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public Uri ThumbUrl { get; set; }
        /// <summary>
        /// Optional. Thumbnail width.
        /// </summary>
        [JsonPropertyName("thumb_width")]
        public int? ThumbWidth { get; set; }
        /// <summary>
        /// Optional. Thumbnail height.
        /// </summary>
        [JsonPropertyName("thumb_height")]
        public int? ThumbHeight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultArticle"/> class.
        /// </summary>
        public InlineQueryResultArticle() : base(InlineQueryResultType.Article) { }

        public override string ToString() => $"{nameof(InlineQueryResultArticle)}[{Id}, {Title}, {InputMessageContent}]";
    }
}
