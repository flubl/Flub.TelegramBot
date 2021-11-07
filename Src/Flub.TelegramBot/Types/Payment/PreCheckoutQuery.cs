using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object contains information about an incoming pre-checkout query.
    /// </summary>
    public class PreCheckoutQuery
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
        /// Three-letter ISO 4217 <see href="https://core.telegram.org/bots/payments#supported-currencies">currency</see> code.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Total price in the smallest units of the currency (integer, not float/double).
        /// For example, for a price of US$ 1.45 pass amount = 145.
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>,
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        [JsonPropertyName("total_amount")]
        public long? TotalAmount { get; set; }
        /// <summary>
        /// Bot specified invoice payload.
        /// </summary>
        [JsonPropertyName("invoice_payload")]
        public string InvoicePayload { get; set; }
        /// <summary>
        /// Optional. Identifier of the shipping option chosen by the user.
        /// </summary>
        [JsonPropertyName("shipping_option_id")]
        public string ShippingOptionId { get; set; }
        /// <summary>
        /// Optional. Order info provided by the user.
        /// </summary>
        [JsonPropertyName("order_info")]
        public OrderInfo OrderInfo { get; set; }

        public override string ToString() => $"{nameof(PreCheckoutQuery)}[{Id}, {From}, {TotalAmount}, {Currency}, {InvoicePayload}]";
    }
}
