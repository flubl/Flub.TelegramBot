using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one result of an inline query.
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
        /// Initializes a new instance of the <see cref="InlineQueryResult"/> class with a specified type.
        /// </summary>
        /// <param name="type">Type of the result.</param>
        protected InlineQueryResult(InlineQueryResultType type)
        {
            Type = type;
        }
    }

    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter<InlineQueryResultType>))]
    public enum InlineQueryResultType : int
    {
        [JsonIgnore]
        None = 0
    }
}
