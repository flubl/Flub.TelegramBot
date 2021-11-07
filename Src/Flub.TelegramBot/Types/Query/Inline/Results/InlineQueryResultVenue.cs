using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a venue.
    /// By default, the venue will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the venue.
    /// </summary>
    public class InlineQueryResultVenue : InlineQueryResult
    {
        /// <summary>
        /// Latitude of the venue location in degrees.
        /// </summary>
        [JsonPropertyName("latitude")]
        public float? Latitude { get; set; }
        /// <summary>
        /// Longitude of the venue location in degrees.
        /// </summary>
        [JsonPropertyName("longitude")]
        public float? Longitude { get; set; }
        /// <summary>
        /// Title of the venue.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Address of the venue.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
        /// <summary>
        /// Optional. Foursquare identifier of the venue if known.
        /// </summary>
        [JsonPropertyName("foursquare_id")]
        public string FoursquareId { get; set; }
        /// <summary>
        /// Optional. Foursquare type of the venue, if known. (For example, "arts_entertainment/default", "arts_entertainment/aquarium" or "food/icecream".).
        /// </summary>
        [JsonPropertyName("foursquare_type")]
        public string FoursquareType { get; set; }
        /// <summary>
        /// Optional. Google Places identifier of the venue.
        /// </summary>
        [JsonPropertyName("google_place_id")]
        public string GooglePlaceId { get; set; }
        /// <summary>
        /// Optional. Google Places type of the venue. (See <see href="https://developers.google.com/places/web-service/supported_types">supported types</see>.).
        /// </summary>
        [JsonPropertyName("google_place_type")]
        public string GooglePlaceType { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the venue.
        /// </summary>
        [JsonPropertyName("input_message_content")]
        public InputMessageContent InputMessageContent { get; set; }
        /// <summary>
        /// Optional. Url of the thumbnail for the result.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public Uri ThumbUrl { get; set; }
        /// <summary>
        /// Optional. Thumbnail width.
        /// </summary>
        [JsonPropertyName("thumb_width")]
        public int? ThumbWidth { get; set; }
        /// <summary>
        /// Optional. Thumbnail height.
        /// </summary>
        [JsonPropertyName("thumb_height")]
        public int? ThumbHeight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultVenue"/> class.
        /// </summary>
        public InlineQueryResultVenue() : base(InlineQueryResultType.Venue) { }

        public override string ToString() => $"{nameof(InlineQueryResultVenue)}[{Id}, {Title}, {Address}, lat: {Latitude}, lon: {Longitude}]";
    }
}
