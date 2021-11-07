using System;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a location on a map.
    /// By default, the location will be sent by the user.
    /// Alternatively, you can use <see cref="InputMessageContent"/> to send a message with the specified content instead of the location.
    /// </summary>
    public class InlineQueryResultLocation : InlineQueryResult
    {
        /// <summary>
        /// Location latitude in degrees.
        /// </summary>
        [JsonPropertyName("latitude")]
        public float? Latitude { get; set; }
        /// <summary>
        /// Location longitude in degrees.
        /// </summary>
        [JsonPropertyName("longitude")]
        public float? Longitude { get; set; }
        /// <summary>
        /// Location title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Optional. The radius of uncertainty for the location, measured in meters; 0-1500.
        /// </summary>
        [JsonPropertyName("horizontal_accuracy")]
        public float? HorizontalAccuracy { get; set; }
        /// <summary>
        /// Optional. Period in seconds for which the location can be updated, should be between 60 and 86400.
        /// </summary>
        [JsonPropertyName("live_period")]
        public int? LivePeriodValue { get; set; }
        /// <summary>
        /// Optional. Period for which the location can be updated, should be between 60 and 86400 seconds.
        /// </summary>
        [JsonPropertyName("live_period")]
        public TimeSpan? LivePeriod
        {
            get => LivePeriodValue.HasValue ? TimeSpan.FromSeconds(LivePeriodValue.Value) : null;
            set => LivePeriodValue = value.HasValue ? (int)value.Value.TotalSeconds : null;
        }
        /// <summary>
        /// Optional. For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
        /// </summary>
        [JsonPropertyName("heading")]
        public int? Heading { get; set; }
        /// <summary>
        /// Optional. For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.
        /// </summary>
        [JsonPropertyName("proximity_alert_radius")]
        public int? ProximityAlertRadius { get; set; }
        /// <summary>
        /// Optional. Content of the message to be sent instead of the location.
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
        /// Initializes a new instance of the <see cref="InlineQueryResultLocation"/> class.
        /// </summary>
        public InlineQueryResultLocation() : base(InlineQueryResultType.Location) { }

        public override string ToString() => $"{nameof(InlineQueryResultLocation)}[{Id}, {Title}, lat: {Latitude}, lon: {Longitude}]";
    }
}
