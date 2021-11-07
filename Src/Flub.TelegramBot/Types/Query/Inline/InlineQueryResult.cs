using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one result of an inline query.
    /// Telegram clients currently support results of the following 20 types:
    /// <see cref="InlineQueryResultCachedAudio"/>,
    /// <see cref="InlineQueryResultCachedDocument"/>,
    /// <see cref="InlineQueryResultCachedGif"/>,
    /// <see cref="InlineQueryResultCachedMpeg4Gif"/>,
    /// <see cref="InlineQueryResultCachedPhoto"/>,
    /// <see cref="InlineQueryResultCachedSticker"/>,
    /// <see cref="InlineQueryResultCachedVideo"/>,
    /// <see cref="InlineQueryResultCachedVoice"/>,
    /// <see cref="InlineQueryResultArticle"/>,
    /// <see cref="InlineQueryResultAudio"/>,
    /// <see cref="InlineQueryResultContact"/>,
    /// <see cref="InlineQueryResultGame"/>,
    /// <see cref="InlineQueryResultDocument"/>,
    /// <see cref="InlineQueryResultGif"/>,
    /// <see cref="InlineQueryResultLocation"/>,
    /// <see cref="InlineQueryResultMpeg4Gif"/>,
    /// <see cref="InlineQueryResultPhoto"/>,
    /// <see cref="InlineQueryResultVenue"/>,
    /// <see cref="InlineQueryResultVideo"/>,
    /// <see cref="InlineQueryResultVoice"/>.
    /// </summary>
    public abstract class InlineQueryResult
    {
        /// <summary>
        /// Type of the result.
        /// </summary>
        [JsonPropertyName("type")]
        public InlineQueryResultType Type { get; }
        /// <summary>
        /// Unique identifier for this result, 1-64 Bytes.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Optional. Inline keyboard attached to the message.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResult"/> class with a specified type.
        /// </summary>
        /// <param name="type">Type of the result.</param>
        protected InlineQueryResult(InlineQueryResultType type)
        {
            Type = type;
        }

        public override string ToString() => $"{nameof(InlineQueryResult)}[{Type}, {Id}]";
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum InlineQueryResultType : int
    {
        [JsonIgnore]
        None = 0,
        [JsonFieldValue("article")]
        Article = 0x1,
        [JsonFieldValue("photo")]
        Photo = 0x2,
        [JsonFieldValue("gif")]
        Gif = 0x4,
        [JsonFieldValue("mpeg4_gif")]
        Mpeg4Gif = 0x8,
        [JsonFieldValue("video")]
        Video = 0x10,
        [JsonFieldValue("audio")]
        Audio = 0x20,
        [JsonFieldValue("voice")]
        Voice = 0x40,
        [JsonFieldValue("document")]
        Document = 0x80,
        [JsonFieldValue("location")]
        Location = 0x100,
        [JsonFieldValue("venue")]
        Venue = 0x200,
        [JsonFieldValue("contact")]
        Contact = 0x400,
        [JsonFieldValue("game")]
        Game = 0x800,
        [JsonFieldValue("sticker")]
        Sticker = 0x1000
    }
}
