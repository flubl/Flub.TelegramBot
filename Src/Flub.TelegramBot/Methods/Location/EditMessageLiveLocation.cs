using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to edit live location messages.
    /// A location can be edited until its <see cref="Location.LivePeriod"/> expires or editing is explicitly disabled by a call to <see cref="StopMessageLiveLocation"/>.
    /// On success, if the edited message is not an inline message, the edited <see cref="Message"/> is returned, otherwise <see langword="true"/> is returned.
    /// </summary>
    public abstract class EditMessageLiveLocation<TResult> : Method<TResult>
    {
        /// <summary>
        /// Latitude of new location.
        /// </summary>
        [Required]
        [JsonPropertyName("latitude")]
        public float? Latitude { get; set; }
        /// <summary>
        /// Longitude of new location.
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
        /// Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
        /// </summary>
        [JsonPropertyName("heading")]
        public int? Heading { get; set; }
        /// <summary>
        /// Maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.
        /// </summary>
        [JsonPropertyName("proximity_alert_radius")]
        public int? ProximityAlertRadius { get; set; }
        /// <summary>
        /// A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditMessageLiveLocation{TResult}"/> class.
        /// </summary>
        protected EditMessageLiveLocation() : base("editMessageLiveLocation") { }
    }

    /// <summary>
    /// Use this method to edit live location messages.
    /// A location can be edited until its <see cref="Location.LivePeriod"/> expires or editing is explicitly disabled by a call to <see cref="StopMessageLiveLocation"/>.
    /// On success, the edited <see cref="Message"/> is returned.
    /// </summary>
    public class EditMessageLiveLocation : EditMessageLiveLocation<Message>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Identifier of the message to edit.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public int? MessageId { get; set; }
    }

    /// <summary>
    /// Use this method to edit live location messages.
    /// A location can be edited until its <see cref="Location.LivePeriod"/> expires or editing is explicitly disabled by a call to <see cref="StopMessageLiveLocation"/>.
    /// On success, <see langword="true"/> is returned.
    /// </summary>
    public class EditInlineMessageLiveLocation : EditMessageLiveLocation<bool?>
    {
        /// <summary>
        /// Identifier of the inline message.
        /// </summary>
        [Required]
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
    }

    public static class EditMessageLiveLocationExtension
    {
        private static Task<TResult> EditMessageLiveLocation<TResult>(this TelegramBot bot, EditMessageLiveLocation<TResult> method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to edit live location messages.
        /// A location can be edited until its <see cref="Location.LivePeriod"/> expires or editing is explicitly disabled by a call to <see cref="StopMessageLiveLocation"/>.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the message to edit.</param>
        /// <param name="latitude">Latitude of new location.</param>
        /// <param name="longitude">Longitude of new location.</param>
        /// <param name="horizontalAccuracy">The radius of uncertainty for the location, measured in meters; 0-1500.</param>
        /// <param name="heading">Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.</param>
        /// <param name="proximityAlertRadius">Maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageLiveLocation(this TelegramBot bot,
            string chatId,
            int? messageId,
            float? latitude,
            float? longitude,
            float? horizontalAccuracy = null,
            int? heading = null,
            int? proximityAlertRadius = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageLiveLocation(bot, new EditMessageLiveLocation
            {
                ChatId = chatId,
                MessageId = messageId,
                Latitude = latitude,
                Longitude = longitude,
                HorizontalAccuracy = horizontalAccuracy,
                Heading = heading,
                ProximityAlertRadius = proximityAlertRadius,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit live location messages.
        /// A location can be edited until its <see cref="Location.LivePeriod"/> expires or editing is explicitly disabled by a call to <see cref="StopMessageLiveLocation"/>.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to edit.</param>
        /// <param name="latitude">Latitude of new location.</param>
        /// <param name="longitude">Longitude of new location.</param>
        /// <param name="horizontalAccuracy">The radius of uncertainty for the location, measured in meters; 0-1500.</param>
        /// <param name="heading">Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.</param>
        /// <param name="proximityAlertRadius">Maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageLiveLocation(this TelegramBot bot,
            IChat chat,
            IMessage message,
            float? latitude,
            float? longitude,
            float? horizontalAccuracy = null,
            int? heading = null,
            int? proximityAlertRadius = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageLiveLocation(bot, new EditMessageLiveLocation
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                Latitude = latitude,
                Longitude = longitude,
                HorizontalAccuracy = horizontalAccuracy,
                Heading = heading,
                ProximityAlertRadius = proximityAlertRadius,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit live location messages.
        /// A location can be edited until its <see cref="Location.LivePeriod"/> expires or editing is explicitly disabled by a call to <see cref="StopMessageLiveLocation"/>.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessageId">Identifier of the inline message.</param>
        /// <param name="latitude">Latitude of new location.</param>
        /// <param name="longitude">Longitude of new location.</param>
        /// <param name="horizontalAccuracy">The radius of uncertainty for the location, measured in meters; 0-1500.</param>
        /// <param name="heading">Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.</param>
        /// <param name="proximityAlertRadius">Maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageLiveLocation(this TelegramBot bot,
            string inlineMessageId,
            float? latitude,
            float? longitude,
            float? horizontalAccuracy = null,
            int? heading = null,
            int? proximityAlertRadius = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageLiveLocation(bot, new EditInlineMessageLiveLocation
            {
                InlineMessageId = inlineMessageId,
                Latitude = latitude,
                Longitude = longitude,
                HorizontalAccuracy = horizontalAccuracy,
                Heading = heading,
                ProximityAlertRadius = proximityAlertRadius,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit live location messages.
        /// A location can be edited until its <see cref="Location.LivePeriod"/> expires or editing is explicitly disabled by a call to <see cref="StopMessageLiveLocation"/>.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="latitude">Latitude of new location.</param>
        /// <param name="longitude">Longitude of new location.</param>
        /// <param name="horizontalAccuracy">The radius of uncertainty for the location, measured in meters; 0-1500.</param>
        /// <param name="heading">Direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.</param>
        /// <param name="proximityAlertRadius">Maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageLiveLocation(this TelegramBot bot,
            IInlineMessage inlineMessage,
            float? latitude,
            float? longitude,
            float? horizontalAccuracy = null,
            int? heading = null,
            int? proximityAlertRadius = null,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageLiveLocation(bot, new EditInlineMessageLiveLocation
            {
                InlineMessageId = inlineMessage?.InlineMessageId,
                Latitude = latitude,
                Longitude = longitude,
                HorizontalAccuracy = horizontalAccuracy,
                Heading = heading,
                ProximityAlertRadius = proximityAlertRadius,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
