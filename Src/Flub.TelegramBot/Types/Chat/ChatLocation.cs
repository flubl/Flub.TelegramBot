using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a location to which a chat is connected.
    /// </summary>
    public class ChatLocation
    {
        /// <summary>
        /// The location to which the supergroup is connected. Can't be a live location.
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location { get; set; }
        /// <summary>
        /// Location address; 1-64 characters, as defined by the chat owner.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        public override string ToString() => $"{nameof(ChatLocation)}[{Location}, {Address}]";
    }
}
