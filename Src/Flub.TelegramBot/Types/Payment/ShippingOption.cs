using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one shipping option.
    /// </summary>
    public class ShippingOption
    {
        /// <summary>
        /// Shipping option identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Option title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// List of price portions.
        /// </summary>
        [JsonPropertyName("prices")]
        public IEnumerable<LabeledPrice> Prices { get; set; }

        public override string ToString() => $"{nameof(ShippingOption)}[{Id}, {Title}, {Prices.Count()} prices]";
    }
}
