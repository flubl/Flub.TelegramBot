using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object contains basic information about an invoice.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Product name.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Product description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Unique bot deep-linking parameter that can be used to generate this invoice.
        /// </summary>
        [JsonPropertyName("start_parameter")]
        public string StartParameter { get; set; }
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

        public override string ToString() => $"{nameof(Invoice)}[{Title}, {Currency}, {StartParameter}]";
    }
}
