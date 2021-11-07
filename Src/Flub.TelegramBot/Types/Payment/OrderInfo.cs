using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents information about an order.
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// Optional. User name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// Optional. User's phone number.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Optional. User email.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
        /// <summary>
        /// Optional. User shipping address.
        /// </summary>
        [JsonPropertyName("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        public override string ToString() => $"{nameof(OrderInfo)}[{Name}, {PhoneNumber}, {Email}, {ShippingAddress}]";
    }
}
