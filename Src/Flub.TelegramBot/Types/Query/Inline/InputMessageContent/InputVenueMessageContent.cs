﻿using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents the content of a venue message to be sent as the result of an inline query.
    /// </summary>
    public class InputVenueMessageContent : InputMessageContent
    {
        /// <summary>
        /// Latitude of the venue in degrees.
        /// </summary>
        [JsonPropertyName("latitude")]
        public float? Latitude { get; set; }
        /// <summary>
        /// Longitude of the venue in degrees.
        /// </summary>
        [JsonPropertyName("longitude")]
        public float? Longitude { get; set; }
        /// <summary>
        /// Name of the venue.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Address of the venue.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
        /// <summary>
        /// Optional. Foursquare identifier of the venue, if known.
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

        public override string ToString() => $"{nameof(InputVenueMessageContent)}[{Title}, {Address}, lat: {Latitude}, lon: {Longitude}]";
    }
}
