using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object contains basic information about a successful payment.
    /// </summary>
    public class SuccessfulPayment
    {
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
        public int? TotalAmount { get; set; }
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
        /// <summary>
        /// Telegram payment identifier.
        /// </summary>
        [JsonPropertyName("telegram_payment_charge_id")]
        public string TelegramPaymentChargeId { get; set; }
        /// <summary>
        /// Provider payment identifier.
        /// </summary>
        [JsonPropertyName("provider_payment_charge_id")]
        public string ProviderPaymentChargeId { get; set; }

        public override string ToString() => $"{nameof(SuccessfulPayment)}[{TotalAmount}, {Currency}, {InvoicePayload}, {TelegramPaymentChargeId}, {ProviderPaymentChargeId}]";
    }
}
