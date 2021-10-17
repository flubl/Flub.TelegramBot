using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a result of an inline query that was chosen by the user and sent to their chat partner.
    /// Note: It is necessary to enable <see href="https://core.telegram.org/bots/inline#collecting-feedback">inline feedback</see>
    /// via <see href="https://t.me/botfather">@Botfather</see> in order to receive these objects in updates.
    /// </summary>
    public class ChosenInlineResult : IInlineMessage
    {
        /// <summary>
        /// The unique identifier for the result that was chosen.
        /// </summary>
        [JsonPropertyName("result_id")]
        public string ResultId { get; set; }
        /// <summary>
        /// The user that chose the result.
        /// </summary>
        [JsonPropertyName("from")]
        public User From { get; set; }
        /// <summary>
        /// Optional. Sender location, only for bots that require user location.
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location { get; set; }
        /// <summary>
        /// Optional. Identifier of the sent inline message.
        /// Available only if there is an inline keyboard attached to the message.
        /// Will be also received in callback queries and can be used to edit the message.
        /// </summary>
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
        /// <summary>
        /// The query that was used to obtain the result.
        /// </summary>
        [JsonPropertyName("query")]
        public string Query { get; set; }
    }
}
