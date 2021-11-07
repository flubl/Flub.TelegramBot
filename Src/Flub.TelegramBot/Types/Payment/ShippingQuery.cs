using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object contains information about an incoming shipping query.
    /// </summary>
    public class ShippingQuery
    {
        /// <summary>
        /// Unique query identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// User who sent the query.
        /// </summary>
        [JsonPropertyName("from")]
        public User From { get; set; }
        /// <summary>
        /// Bot specified invoice payload.
        /// </summary>
        [JsonPropertyName("invoice_payload")]
        public string InvoicePayload { get; set; }
        /// <summary>
        /// User specified shipping address.
        /// </summary>
        [JsonPropertyName("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        public override string ToString() => $"{nameof(ShippingQuery)}[{Id}, {From}, {InvoicePayload}, {ShippingAddress}]";
    }
}
