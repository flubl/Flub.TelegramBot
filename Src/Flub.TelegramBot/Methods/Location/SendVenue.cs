using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send information about a venue.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendVenue : SendToChatWithReplyMarkup<Message>
    {
        /// <summary>
        /// Latitude of the venue.
        /// </summary>
        [Required]
        [JsonPropertyName("latitude")]
        public float? Latitude { get; set; }
        /// <summary>
        /// Longitude of the venue.
        /// </summary>
		[Required]
        [JsonPropertyName("longitude")]
        public float? Longitude { get; set; }
        /// <summary>
        /// Name of the venue.
        /// </summary>
		[Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Address of the venue.
        /// </summary>
		[Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }
        /// <summary>
        /// Foursquare identifier of the venue.
        /// </summary>
        [JsonPropertyName("foursquare_id")]
        public string FoursquareId { get; set; }
        /// <summary>
        /// Foursquare type of the venue, if known.
        /// (For example, "arts_entertainment/default", "arts_entertainment/aquarium" or "food/icecream".)
        /// </summary>
        [JsonPropertyName("foursquare_type")]
        public string FoursquareType { get; set; }
        /// <summary>
        /// Google Places identifier of the venue.
        /// </summary>
        [JsonPropertyName("google_place_id")]
        public string GooglePlaceId { get; set; }
        /// <summary>
        /// Google Places type of the venue. (See <see href="https://developers.google.com/places/web-service/supported_types">supported types</see>.).
        /// </summary>
        [JsonPropertyName("google_place_type")]
        public string GooglePlaceType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendVenue"/> class.
        /// </summary>
        public SendVenue() : base("sendVenue") { }
    }

    public static class SendVenueExtension
    {
        private static Task<Message> SendVenue(this TelegramBot bot, SendVenue method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send information about a venue.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="latitude">Latitude of the venue.</param>
        /// <param name="longitude">Longitude of the venue.</param>
        /// <param name="title">Name of the venue.</param>
        /// <param name="address">Address of the venue.</param>
        /// <param name="foursquareId">Foursquare identifier of the venue.</param>
        /// <param name="foursquareType">
        /// Foursquare type of the venue, if known.
        /// (For example, "arts_entertainment/default", "arts_entertainment/aquarium" or "food/icecream".)
        /// </param>
        /// <param name="googlePlaceId">Google Places identifier of the venue.</param>
        /// <param name="googlePlaceType">Google Places type of the venue. (See <see href="https://developers.google.com/places/web-service/supported_types">supported types</see>.).</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendVenue(this TelegramBot bot,
            string chatId,
            float? latitude,
            float? longitude,
            string title,
            string address,
            string foursquareId = null,
            string foursquareType = null,
            string googlePlaceId = null,
            string googlePlaceType = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendVenue(bot, new()
            {
                ChatId = chatId,
                Latitude = latitude,
                Longitude = longitude,
                Title = title,
                Address = address,
                FoursquareId = foursquareId,
                FoursquareType = foursquareType,
                GooglePlaceId = googlePlaceId,
                GooglePlaceType = googlePlaceType,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send information about a venue.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="latitude">Latitude of the venue.</param>
        /// <param name="longitude">Longitude of the venue.</param>
        /// <param name="title">Name of the venue.</param>
        /// <param name="address">Address of the venue.</param>
        /// <param name="foursquareId">Foursquare identifier of the venue.</param>
        /// <param name="foursquareType">
        /// Foursquare type of the venue, if known.
        /// (For example, "arts_entertainment/default", "arts_entertainment/aquarium" or "food/icecream".)
        /// </param>
        /// <param name="googlePlaceId">Google Places identifier of the venue.</param>
        /// <param name="googlePlaceType">Google Places type of the venue. (See <see href="https://developers.google.com/places/web-service/supported_types">supported types</see>.).</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessage">If the message is a reply, the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendVenue(this TelegramBot bot,
            IChat chat,
            float? latitude,
            float? longitude,
            string title,
            string address,
            string foursquareId = null,
            string foursquareType = null,
            string googlePlaceId = null,
            string googlePlaceType = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendVenue(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Latitude = latitude,
                Longitude = longitude,
                Title = title,
                Address = address,
                FoursquareId = foursquareId,
                FoursquareType = foursquareType,
                GooglePlaceId = googlePlaceId,
                GooglePlaceType = googlePlaceType,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
