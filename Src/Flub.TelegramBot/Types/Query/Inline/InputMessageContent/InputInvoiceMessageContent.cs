using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the content of an invoice message to be sent as the result of an inline query.
    /// </summary>
    public class InputInvoiceMessageContent : InputMessageContent
    {
        /// <summary>
        /// Product name, 1-32 characters.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Product description, 1-255 characters.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.
        /// </summary>
        [JsonPropertyName("payload")]
        public string Payload { get; set; }
        /// <summary>
        /// Payment provider token, obtained via <see href="https://t.me/botfather">Botfather</see>.
        /// </summary>
        [JsonPropertyName("provider_token")]
        public string ProviderToken { get; set; }
        /// <summary>
        /// Three-letter ISO 4217 currency code, see <see href="https://core.telegram.org/bots/payments#supported-currencies">more on currencies</see>.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.).
        /// </summary>
        [JsonPropertyName("prices")]
        public IEnumerable<LabeledPrice> Prices { get; set; }
        /// <summary>
        /// Optional. The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double).
        /// For example, for a maximum tip of US$ 1.45 pass <see cref="MaxTipAmount"/> = 145.
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>,
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// Defaults to 0.
        /// </summary>
        [JsonPropertyName("max_tip_amount")]
        public int? MaxTipAmount { get; set; }
        /// <summary>
        /// Optional. A list of suggested amounts of tip in the smallest units of the currency (integer, not float/double).
        /// At most 4 suggested tip amounts can be specified.
        /// The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed <see cref="MaxTipAmount"/>.
        /// </summary>
        [JsonPropertyName("suggested_tip_amounts")]
        public IEnumerable<int?> SuggestedTipAmounts { get; set; }
        /// <summary>
        /// Optional. A object for data about the invoice, which will be shared with the payment provider.
        /// A detailed description of the required fields should be provided by the payment provider.
        /// </summary>
        [JsonPropertyName("provider_data")]
        public string ProviderData { get; set; }
        /// <summary>
        /// Optional. URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service.
        /// People like it better when they see what they are paying for.
        /// </summary>
        [JsonPropertyName("photo_url")]
        public Uri PhotoUrl { get; set; }
        /// <summary>
        /// Optional. Photo size.
        /// </summary>
        [JsonPropertyName("photo_size")]
        public int? PhotoSize { get; set; }
        /// <summary>
        /// Optional. Photo width.
        /// </summary>
        [JsonPropertyName("photo_width")]
        public int? PhotoWidth { get; set; }
        /// <summary>
        /// Optional. Photo height.
        /// </summary>
        [JsonPropertyName("photo_height")]
        public int? PhotoHeight { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if you require the user's full name to complete the order.
        /// </summary>
        [JsonPropertyName("need_name")]
        public bool? NeedName { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if you require the user's phone number to complete the order.
        /// </summary>
        [JsonPropertyName("need_phone_number")]
        public bool? NeedPhoneNumber { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if you require the user's email address to complete the order.
        /// </summary>
        [JsonPropertyName("need_email")]
        public bool? NeedEmail { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if you require the user's shipping address to complete the order.
        /// </summary>
        [JsonPropertyName("need_shipping_address")]
        public bool? NeedShippingAddress { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if user's phone number should be sent to provider.
        /// </summary>
        [JsonPropertyName("send_phone_number_to_provider")]
        public bool? SendPhoneNumberToProvider { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if user's email address should be sent to provider.
        /// </summary>
        [JsonPropertyName("send_email_to_provider")]
        public bool? SendEmailToProvider { get; set; }
        /// <summary>
        /// Optional. Pass <see langword="true"/>, if the final price depends on the shipping method.
        /// </summary>
        [JsonPropertyName("is_flexible")]
        public bool? IsFlexible { get; set; }

        public override string ToString() => $"{nameof(InputInvoiceMessageContent)}[{Title}, {Currency}, {Prices.Count()} prices, {Payload}, {ProviderToken}]";
    }
}
