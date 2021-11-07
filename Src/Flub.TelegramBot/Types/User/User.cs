using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// Unique identifier for this user or bot.
        /// </summary>
        [Required]
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        /// <summary>
        /// <see langword="true"/>, if this user is a bot.
        /// </summary>
        [Required]
        [JsonPropertyName("is_bot")]
        public bool? IsBot { get; set; }
        /// <summary>
        /// User's or bot's first name.
        /// </summary>
        [Required]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Optional. User's or bot's last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Optional. User's or bot's username.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }
        /// <summary>
        /// Optional. <see href="https://en.wikipedia.org/wiki/IETF_language_tag">IETF language tag</see> of the user's language.
        /// </summary>
        [JsonPropertyName("language_code")]
        public string LanguageCode { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the bot can be invited to groups. Returned only in <see cref="Methods.GetMe"/>.
        /// </summary>
        [JsonPropertyName("can_join_groups")]
        public bool? CanJoinGroups { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if <see href="https://core.telegram.org/bots#privacy-mode">privacy mode</see> is disabled for the bot.
        /// Returned only in <see cref="Methods.GetMe"/>.
        /// </summary>
        [JsonPropertyName("can_read_all_group_messages")]
        public bool? CanReadAllGroupMessages { get; set; }
        /// <summary>
        /// Optional. <see langword="true"/>, if the bot supports inline queries. Returned only in <see cref="Methods.GetMe"/>.
        /// </summary>
        [JsonPropertyName("supports_inline_queries")]
        public bool? SupportsInlineQueries { get; set; }

        public override string ToString() => $"{nameof(User)}[{Id}, {FirstName}, {(IsBot == true ? "Bot" : "User")}]";
    }
}
