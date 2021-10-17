using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send phone contacts.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendContact : SendToChatWithReplyMarkup<Message>
    {
        /// <summary>
        /// Contact's phone number.
        /// </summary>
        [Required]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Contact's first name.
        /// </summary>
        [Required]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Contact's last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Additional data about the contact in the form of a vCard, 0-2048 bytes.
        /// </summary>
        [JsonPropertyName("vcard")]
        public string Vcard { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendContact"/> class.
        /// </summary>
        public SendContact() : base("sendContact") { }
    }

    public static class SendContactExtension
    {
        private static Task<Message> SendContact(this TelegramBot bot, SendContact method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send phone contacts.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="phoneNumber">Contact's phone number.</param>
        /// <param name="firstName">Contact's first name.</param>
        /// <param name="lastName">Contact's last name.</param>
        /// <param name="vcard">Additional data about the contact in the form of a vCard, 0-2048 bytes.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessageId">If the message is a reply, ID of the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see cref="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendContact(this TelegramBot bot,
            string chatId,
            string phoneNumber,
            string firstName,
            string lastName = null,
            string vcard = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendContact(bot, new()
            {
                ChatId = chatId,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Vcard = vcard,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send phone contacts.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="phoneNumber">Contact's phone number.</param>
        /// <param name="firstName">Contact's first name.</param>
        /// <param name="lastName">Contact's last name.</param>
        /// <param name="vcard">Additional data about the contact in the form of a vCard, 0-2048 bytes.</param>
        /// <param name="disableNotification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="replyToMessage">If the message is a reply, the original message.</param>
        /// <param name="allowSendingWithoutReply">Pass <see cref="true"/>, if the message should be sent even if the specified replied-to message is not found.</param>
        /// <param name="replyMarkup">
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SendContact(this TelegramBot bot,
            IChat chat,
            string phoneNumber,
            string firstName,
            string lastName = null,
            string vcard = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendContact(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Vcard = vcard,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
