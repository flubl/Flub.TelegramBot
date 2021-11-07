using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send point on the map.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendLocation : SendToChatWithReplyMarkup<Message>
    {
        /// <summary>
        /// Latitude of the location.
        /// </summary>
        [Required]
        [JsonPropertyName("latitude")]
        public float? Latitude { get; set; }
        /// <summary>
        /// Longitude of the location.
        /// </summary>
        [Required]
        [JsonPropertyName("longitude")]
        public float? Longitude { get; set; }
        /// <summary>
        /// The radius of uncertainty for the location, measured in meters; 0-1500.
        /// </summary>
        [JsonPropertyName("horizontal_accuracy")]
        public float? HorizontalAccuracy { get; set; }
        /// <summary>
        /// Period in seconds for which the location will be updated (see <see href="https://telegram.org/blog/live-locations">Live Locations</see>),
        /// should be between 60 and 86400.
        /// </summary>
        [JsonPropertyName("live_period")]
        public int? LivePeriod { get; set; }
        /// <summary>
        /// For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
        /// </summary>
        [JsonPropertyName("heading")]
        public int? Heading { get; set; }
        /// <summary>
        /// For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters.
        /// Must be between 1 and 100000 if specified.
        /// </summary>
        [JsonPropertyName("proximity_alert_radius")]
        public int? ProximityAlertRadius { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendLocation"/> class.
        /// </summary>
        public SendLocation() : base("sendLocation") { }
    }

    public static class SendLocationExtension
    {
        private static Task<Message> SendLocation(this TelegramBot bot, SendLocation method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send point on the map.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="latitude">Latitude of the location.</param>
        /// <param name="longitude">Longitude of the location.</param>
        /// <param name="horizontalAccuracy">The radius of uncertainty for the location, measured in meters; 0-1500.</param>
        /// <param name="livePeriod">
        /// Period in seconds for which the location will be updated (see <see href="https://telegram.org/blog/live-locations">Live Locations</see>),
        /// should be between 60 and 86400.
        /// </param>
        /// <param name="heading">For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.</param>
        /// <param name="proximityAlertRadius">
        /// For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters.
        /// Must be between 1 and 100000 if specified.
        /// </param>
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
        public static Task<Message> SendLocation(this TelegramBot bot,
            string chatId,
            float? latitude,
            float? longitude,
            float? horizontalAccuracy = null,
            int? livePeriod = null,
            int? heading = null,
            int? proximityAlertRadius = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendLocation(bot, new()
            {
                ChatId = chatId,
                Latitude = latitude,
                Longitude = longitude,
                HorizontalAccuracy = horizontalAccuracy,
                LivePeriod = livePeriod,
                Heading = heading,
                ProximityAlertRadius = proximityAlertRadius,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send point on the map.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="latitude">Latitude of the location.</param>
        /// <param name="longitude">Longitude of the location.</param>
        /// <param name="horizontalAccuracy">The radius of uncertainty for the location, measured in meters; 0-1500.</param>
        /// <param name="livePeriod">
        /// Period in seconds for which the location will be updated (see <see href="https://telegram.org/blog/live-locations">Live Locations</see>),
        /// should be between 60 and 86400.
        /// </param>
        /// <param name="heading">For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.</param>
        /// <param name="proximityAlertRadius">
        /// For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters.
        /// Must be between 1 and 100000 if specified.
        /// </param>
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
        public static Task<Message> SendLocation(this TelegramBot bot,
            IChat chat,
            float? latitude,
            float? longitude,
            float? horizontalAccuracy = null,
            int? livePeriod = null,
            int? heading = null,
            int? proximityAlertRadius = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendLocation(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Latitude = latitude,
                Longitude = longitude,
                HorizontalAccuracy = horizontalAccuracy,
                LivePeriod = livePeriod,
                Heading = heading,
                ProximityAlertRadius = proximityAlertRadius,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
