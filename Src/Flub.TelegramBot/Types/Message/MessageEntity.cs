using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one special entity in a text message.
    /// For example, hashtags, usernames, URLs, etc.
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// Type of the entity.
        /// </summary>
        [JsonPropertyName("type")]
        public MessageEntityType? Type { get; set; }
        /// <summary>
        /// Offset in UTF-16 code units to the start of the entity.
        /// </summary>
        [JsonPropertyName("offset")]
        public int? Offset { get; set; }
        /// <summary>
        /// Length of the entity in UTF-16 code units.
        /// </summary>
        [JsonPropertyName("length")]
        public int? Length { get; set; }
        /// <summary>
        /// Optional. For <see cref="MessageEntityType.TextLink"/> only, url that will be opened after user taps on the text.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// Optional. For <see cref="MessageEntityType.TextMention"/> only, the mentioned user.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
        /// <summary>
        /// Optional. For <see cref="MessageEntityType.Pre"/> only, the programming language of the entity text.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        public override string ToString() => $"{nameof(MessageEntity)}[{Type}]";
    }

    /// <summary>
    /// Type of an entity.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum MessageEntityType : int
    {
        [JsonIgnore]
        None = 0x0,
        /// <summary>
        /// @username
        /// </summary>
        [JsonFieldValue("mention")]
        Mention = 0x1,
        /// <summary>
        /// #hashtag
        /// </summary>
        [JsonFieldValue("hashtag")]
        Hashtag = 0x2,
        /// <summary>
        /// $USD
        /// </summary>
        [JsonFieldValue("cashtag")]
        Cashtag = 0x4,
        /// <summary>
        /// /start@jobs_bot
        /// </summary>
        [JsonFieldValue("bot_command")]
        BotCommand = 0x8,
        /// <summary>
        /// https://telegram.org
        /// </summary>
        [JsonFieldValue("url")]
        Url = 0x10,
        /// <summary>
        /// do-not-reply@telegram.org
        /// </summary>
        [JsonFieldValue("email")]
        Email = 0x20,
        /// <summary>
        /// +1-212-555-0123
        /// </summary>
        [JsonFieldValue("phone_number")]
        PhoneNumber = 0x40,
        /// <summary>
        /// bold text
        /// </summary>
        [JsonFieldValue("bold")]
        Bold = 0x80,
        /// <summary>
        /// italic text
        /// </summary>
        [JsonFieldValue("italic")]
        Italic = 0x100,
        /// <summary>
        /// underlined text
        /// </summary>
        [JsonFieldValue("underline")]
        Underline = 0x200,
        /// <summary>
        /// strikethrough text
        /// </summary>
        [JsonFieldValue("strikethrough")]
        Strikethrough = 0x400,
        /// <summary>
        /// monowidth string
        /// </summary>
        [JsonFieldValue("code")]
        Code = 0x800,
        /// <summary>
        /// monowidth block
        /// </summary>
        [JsonFieldValue("pre")]
        Pre = 0x1000,
        /// <summary>
        /// for clickable text URLs
        /// </summary>
        [JsonFieldValue("text_link")]
        TextLink = 0x2000,
        /// <summary>
        /// for users without usernames
        /// </summary>
        [JsonFieldValue("text_mention")]
        TextMention = 0x4000
    }
}
