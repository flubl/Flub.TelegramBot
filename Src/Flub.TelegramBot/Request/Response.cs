using System.Text.Json.Serialization;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Response from a request to the Telegram Bot API
    /// </summary>
    public abstract class Response
    {
        /// <summary>
        /// <see langword="true"/>, if the request was successful.
        /// </summary>
        [JsonPropertyName("ok")]
        public bool? Ok { get; set; }
        /// <summary>
        /// Optional error code (its contents are subject to change in the future).
        /// </summary>
        [JsonPropertyName("error_code")]
        public int? ErrorCode { get; set; }
        /// <summary>
        /// Optional human-readable description of the result.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Some errors may also have an optional field 'parameters' of the type <see cref="ResponseParameters"/>, which can help to automatically handle the error.
        /// </summary>
        [JsonPropertyName("parameters")]
        public ResponseParameters Parameters { get; set; }

        public override string ToString() => $"{nameof(Response)}[{(Ok == true ? "Ok" : $"{ErrorCode}: {Description}")}]";
    }

    /// <summary>
    /// Response from a request to the Telegram Bot API with the specified result type.
    /// </summary>
    /// <typeparam name="TResult">The type of result.</typeparam>
    public class Response<TResult> : Response
    {
        /// <summary>
        /// Result of a successful request.
        /// </summary>
        [JsonPropertyName("result")]
        public TResult Result { get; set; }
    }
}
