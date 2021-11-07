using System.Text.Json.Serialization;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Contains information about why a request was unsuccessful.
    /// </summary>
    public class ResponseParameters
    {
        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier.
        /// </summary>
        [JsonPropertyName("migrate_to_chat_id")]
        public int? MigrateToChatId { get; set; }
        /// <summary>
        /// Optional. In case of exceeding flood control, the number of seconds left to wait before the request can be repeated.
        /// </summary>
        [JsonPropertyName("retry_after")]
        public int? RetryAfter { get; set; }

        public override string ToString() => nameof(ResponseParameters);
    }
}
