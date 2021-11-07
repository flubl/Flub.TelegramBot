using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a shipping address.
    /// </summary>
    public class ShippingAddress
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
        /// <summary>
        /// State, if applicable.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
        /// <summary>
        /// City.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }
        /// <summary>
        /// First line for the address.
        /// </summary>
        [JsonPropertyName("street_line1")]
        public string StreetLine1 { get; set; }
        /// <summary>
        /// Second line for the address.
        /// </summary>
        [JsonPropertyName("street_line2")]
        public string StreetLine2 { get; set; }
        /// <summary>
        /// Address post code.
        /// </summary>
        [JsonPropertyName("post_code")]
        public string PostCode { get; set; }

        public override string ToString() => $"{nameof(ShippingAddress)}[{CountryCode}, {State}, {StreetLine1}, {StreetLine2}, {City}, {PostCode}]";
    }
}
