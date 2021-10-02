using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// Type of the entity. Can be 
        /// <see cref="MessageEntryType.Mention"/> (@username), 
        /// <see cref="MessageEntryType.Hashtag"/> (#hashtag), 
        /// <see cref="MessageEntryType.Cashtag"/> ($USD), 
        /// <see cref="MessageEntryType.BotCommand"/> (/start@jobs_bot), 
        /// <see cref="MessageEntryType.Url"/> (https://telegram.org), 
        /// <see cref="MessageEntryType.Email"/> (do-not-reply@telegram.org), 
        /// <see cref="MessageEntryType.PhoneNumber"/> (+1-212-555-0123), 
        /// <see cref="MessageEntryType.Bold"/> (bold text), 
        /// <see cref="MessageEntryType.Italic"/> (italic text), 
        /// <see cref="MessageEntryType.Underline"/> (underlined text), 
        /// <see cref="MessageEntryType.Strikethrough"/> (strikethrough text), 
        /// <see cref="MessageEntryType.Code"/> (monowidth string), 
        /// <see cref="MessageEntryType.Pre"/> (monowidth block), 
        /// <see cref="MessageEntryType.TextLink"/> (for clickable text URLs), 
        /// <see cref="MessageEntryType.TextMention"/> (for users without usernames).
        /// </summary>
        [JsonPropertyName("type")]
        public MessageEntryType? Type { get; set; }
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
        /// Optional. For <see cref="MessageEntryType.TextLink"/> only, url that will be opened after user taps on the text.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        /// <summary>
        /// Optional. For <see cref="MessageEntryType.TextMention"/> only, the mentioned user.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
        /// <summary>
        /// Optional. For <see cref="MessageEntryType.Pre"/> only, the programming language of the entity text.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    /// <summary>
    /// Type of the entity.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter<MessageEntryType>))]
    public enum MessageEntryType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("mention")]
        Mention = 0x1,
        [JsonFieldValue("hashtag")]
        Hashtag = 0x2,
        [JsonFieldValue("cashtag")]
        Cashtag = 0x4,
        [JsonFieldValue("bot_command")]
        BotCommand = 0x8,
        [JsonFieldValue("url")]
        Url = 0x10,
        [JsonFieldValue("email")]
        Email = 0x20,
        [JsonFieldValue("phone_number")]
        PhoneNumber = 0x40,
        [JsonFieldValue("bold")]
        Bold = 0x80,
        [JsonFieldValue("italic")]
        Italic = 0x100,
        [JsonFieldValue("underline")]
        Underline = 0x200,
        [JsonFieldValue("strikethrough")]
        Strikethrough = 0x400,
        [JsonFieldValue("code")]
        Code = 0x800,
        [JsonFieldValue("pre")]
        Pre = 0x1000,
        [JsonFieldValue("text_link")]
        TextLink = 0x2000,
        [JsonFieldValue("text_mention")]
        TextMention = 0x4000
    }
}
