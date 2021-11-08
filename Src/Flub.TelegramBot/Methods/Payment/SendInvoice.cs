using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send invoices.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendInvoice : SendToChatWithReplyMarkup<Message>
    {
        /// <summary>
        /// Product name, 1-32 characters.
        /// </summary>
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Product description, 1-255 characters.
        /// </summary>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.
        /// </summary>
        [Required]
        [JsonPropertyName("payload")]
        public string Payload { get; set; }
        /// <summary>
        /// Payments provider token, obtained via <see href="https://t.me/botfather">Botfather</see>.
        /// </summary>
        [Required]
        [JsonPropertyName("provider_token")]
        public string ProviderToken { get; set; }
        /// <summary>
        /// Three-letter ISO 4217 currency code, see <see href="https://core.telegram.org/bots/payments#supported-currencies">more on currencies</see>.
        /// </summary>
        [Required]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.).
        /// </summary>
        [Required]
        [JsonPropertyName("prices")]
        public IEnumerable<LabeledPrice> Prices { get; set; }
        /// <summary>
        /// The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double).
        /// For example, for a maximum tip of US$ 1.45 pass max_tip_amount = 145.
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>,
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies). Defaults to 0.
        /// </summary>
        [JsonPropertyName("max_tip_amount")]
        public int? MaxTipAmount { get; set; }
        /// <summary>
        /// A list of suggested amounts of tips in the smallest units of the currency (integer, not float/double).
        /// At most 4 suggested tip amounts can be specified.
        /// The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed <see cref="MaxTipAmount"/>.
        /// </summary>
        [JsonPropertyName("suggested_tip_amounts")]
        public IEnumerable<int?> SuggestedTipAmounts { get; set; }
        /// <summary>
        /// Unique deep-linking parameter.
        /// If left empty, forwarded copies of the sent message will have a Pay button,
        /// allowing multiple users to pay directly from the forwarded message, using the same invoice.
        /// If non-empty, forwarded copies of the sent message will have a URL button with a deep link to the bot (instead of a Pay button),
        /// with the value used as the start parameter.
        /// </summary>
        [JsonPropertyName("start_parameter")]
        public string StartParameter { get; set; }
        /// <summary>
        /// A data about the invoice, which will be shared with the payment provider.
        /// A detailed description of required fields should be provided by the payment provider.
        /// </summary>
        [JsonPropertyName("provider_data")]
        public string ProviderData { get; set; }
        /// <summary>
        /// URL of the product photo for the invoice.
        /// Can be a photo of the goods or a marketing image for a service.
        /// People like it better when they see what they are paying for.
        /// </summary>
        [JsonPropertyName("photo_url")]
        public Uri PhotoUrl { get; set; }
        /// <summary>
        /// Photo size.
        /// </summary>
        [JsonPropertyName("photo_size")]
        public int? PhotoSize { get; set; }
        /// <summary>
        /// Photo width.
        /// </summary>
        [JsonPropertyName("photo_width")]
        public int? PhotoWidth { get; set; }
        /// <summary>
        /// Photo height.
        /// </summary>
        [JsonPropertyName("photo_height")]
        public int? PhotoHeight { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if you require the user's full name to complete the order.
        /// </summary>
        [JsonPropertyName("need_name")]
        public bool? NeedName { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if you require the user's phone number to complete the order.
        /// </summary>
        [JsonPropertyName("need_phone_number")]
        public bool? NeedPhoneNumber { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if you require the user's email address to complete the order.
        /// </summary>
        [JsonPropertyName("need_email")]
        public bool? NeedEmail { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if you require the user's shipping address to complete the order.
        /// </summary>
        [JsonPropertyName("need_shipping_address")]
        public bool? NeedShippingAddress { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if user's phone number should be sent to provider.
        /// </summary>
        [JsonPropertyName("send_phone_number_to_provider")]
        public bool? SendPhoneNumberToProvider { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if user's email address should be sent to provider.
        /// </summary>
        [JsonPropertyName("send_email_to_provider")]
        public bool? SendEmailToProvider { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if the final price depends on the shipping method.
        /// </summary>
        [JsonPropertyName("is_flexible")]
        public bool? IsFlexible { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendInvoice"/> class.
        /// </summary>
        public SendInvoice() : base("sendInvoice") { }
    }

    public static class SendInvoiceExtension
    {
        private static Task<Message> SendInvoice(this TelegramBot bot, SendInvoice method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send invoices.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="title">Product name, 1-32 characters.</param>
        /// <param name="description">Product description, 1-255 characters.</param>
        /// <param name="payload">Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.</param>
        /// <param name="providerToken">Payments provider token, obtained via <see href="https://t.me/botfather">Botfather</see>.</param>
        /// <param name="currency">Three-letter ISO 4217 currency code, see <see href="https://core.telegram.org/bots/payments#supported-currencies">more on currencies</see>.</param>
        /// <param name="prices">Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.).</param>
        /// <param name="maxTipAmount">
        /// The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double).
        /// For example, for a maximum tip of US$ 1.45 pass max_tip_amount = 145.
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>,
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies). Defaults to 0.
        /// </param>
        /// <param name="suggestedTipAmounts">
        /// A list of suggested amounts of tips in the smallest units of the currency (integer, not float/double).
        /// At most 4 suggested tip amounts can be specified.
        /// The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed <paramref name="maxTipAmount"/>.
        /// </param>
        /// <param name="startParameter">
        /// Unique deep-linking parameter.
        /// If left empty, forwarded copies of the sent message will have a Pay button,
        /// allowing multiple users to pay directly from the forwarded message, using the same invoice.
        /// If non-empty, forwarded copies of the sent message will have a URL button with a deep link to the bot (instead of a Pay button),
        /// with the value used as the start parameter.
        /// </param>
        /// <param name="providerData">
        /// A data about the invoice, which will be shared with the payment provider.
        /// A detailed description of required fields should be provided by the payment provider.
        /// </param>
        /// <param name="photoUrl">
        /// URL of the product photo for the invoice.
        /// Can be a photo of the goods or a marketing image for a service.
        /// People like it better when they see what they are paying for.
        /// </param>
        /// <param name="photoSize">Photo size.</param>
        /// <param name="photoWidth">Photo width.</param>
        /// <param name="photoHeight">Photo height.</param>
        /// <param name="needName">Pass <see langword="true"/>, if you require the user's full name to complete the order.</param>
        /// <param name="needPhoneNumber">Pass <see langword="true"/>, if you require the user's phone number to complete the order.</param>
        /// <param name="needEmail">Pass <see langword="true"/>, if you require the user's email address to complete the order.</param>
        /// <param name="needShippingAddress">Pass <see langword="true"/>, if you require the user's shipping address to complete the order.</param>
        /// <param name="sendPhoneNumberToProvider">Pass <see langword="true"/>, if user's phone number should be sent to provider.</param>
        /// <param name="sendEmailToProvider">Pass <see langword="true"/>, if user's email address should be sent to provider.</param>
        /// <param name="isFlexible">Pass <see langword="true"/>, if the final price depends on the shipping method.</param>
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
        public static Task<Message> SendInvoice(this TelegramBot bot,
            string chatId,
            string title,
            string description,
            string payload,
            string providerToken,
            string currency,
            IEnumerable<LabeledPrice> prices,
            int? maxTipAmount = null,
            IEnumerable<int?> suggestedTipAmounts = null,
            string startParameter = null,
            string providerData = null,
            Uri photoUrl = null,
            int? photoSize = null,
            int? photoWidth = null,
            int? photoHeight = null,
            bool? needName = null,
            bool? needPhoneNumber = null,
            bool? needEmail = null,
            bool? needShippingAddress = null,
            bool? sendPhoneNumberToProvider = null,
            bool? sendEmailToProvider = null,
            bool? isFlexible = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendInvoice(bot, new()
            {
                ChatId = chatId,
                Title = title,
                Description = description,
                Payload = payload,
                ProviderToken = providerToken,
                Currency = currency,
                Prices = prices,
                MaxTipAmount = maxTipAmount,
                SuggestedTipAmounts = suggestedTipAmounts,
                StartParameter = startParameter,
                ProviderData = providerData,
                PhotoUrl = photoUrl,
                PhotoSize = photoSize,
                PhotoWidth = photoWidth,
                PhotoHeight = photoHeight,
                NeedName = needName,
                NeedPhoneNumber = needPhoneNumber,
                NeedEmail = needEmail,
                NeedShippingAddress = needShippingAddress,
                SendPhoneNumberToProvider = sendPhoneNumberToProvider,
                SendEmailToProvider = sendEmailToProvider,
                IsFlexible = isFlexible,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send invoices.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="title">Product name, 1-32 characters.</param>
        /// <param name="description">Product description, 1-255 characters.</param>
        /// <param name="payload">Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.</param>
        /// <param name="providerToken">Payments provider token, obtained via <see href="https://t.me/botfather">Botfather</see>.</param>
        /// <param name="currency">Three-letter ISO 4217 currency code, see <see href="https://core.telegram.org/bots/payments#supported-currencies">more on currencies</see>.</param>
        /// <param name="prices">Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.).</param>
        /// <param name="maxTipAmount">
        /// The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double).
        /// For example, for a maximum tip of US$ 1.45 pass max_tip_amount = 145.
        /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>,
        /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies). Defaults to 0.
        /// </param>
        /// <param name="suggestedTipAmounts">
        /// A list of suggested amounts of tips in the smallest units of the currency (integer, not float/double).
        /// At most 4 suggested tip amounts can be specified.
        /// The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed <paramref name="maxTipAmount"/>.
        /// </param>
        /// <param name="startParameter">
        /// Unique deep-linking parameter.
        /// If left empty, forwarded copies of the sent message will have a Pay button,
        /// allowing multiple users to pay directly from the forwarded message, using the same invoice.
        /// If non-empty, forwarded copies of the sent message will have a URL button with a deep link to the bot (instead of a Pay button),
        /// with the value used as the start parameter.
        /// </param>
        /// <param name="providerData">
        /// A data about the invoice, which will be shared with the payment provider.
        /// A detailed description of required fields should be provided by the payment provider.
        /// </param>
        /// <param name="photoUrl">
        /// URL of the product photo for the invoice.
        /// Can be a photo of the goods or a marketing image for a service.
        /// People like it better when they see what they are paying for.
        /// </param>
        /// <param name="photoSize">Photo size.</param>
        /// <param name="photoWidth">Photo width.</param>
        /// <param name="photoHeight">Photo height.</param>
        /// <param name="needName">Pass <see langword="true"/>, if you require the user's full name to complete the order.</param>
        /// <param name="needPhoneNumber">Pass <see langword="true"/>, if you require the user's phone number to complete the order.</param>
        /// <param name="needEmail">Pass <see langword="true"/>, if you require the user's email address to complete the order.</param>
        /// <param name="needShippingAddress">Pass <see langword="true"/>, if you require the user's shipping address to complete the order.</param>
        /// <param name="sendPhoneNumberToProvider">Pass <see langword="true"/>, if user's phone number should be sent to provider.</param>
        /// <param name="sendEmailToProvider">Pass <see langword="true"/>, if user's email address should be sent to provider.</param>
        /// <param name="isFlexible">Pass <see langword="true"/>, if the final price depends on the shipping method.</param>
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
        public static Task<Message> SendInvoice(this TelegramBot bot,
            IChat chat,
            string title,
            string description,
            string payload,
            string providerToken,
            string currency,
            IEnumerable<LabeledPrice> prices,
            int? maxTipAmount = null,
            IEnumerable<int?> suggestedTipAmounts = null,
            string startParameter = null,
            string providerData = null,
            Uri photoUrl = null,
            int? photoSize = null,
            int? photoWidth = null,
            int? photoHeight = null,
            bool? needName = null,
            bool? needPhoneNumber = null,
            bool? needEmail = null,
            bool? needShippingAddress = null,
            bool? sendPhoneNumberToProvider = null,
            bool? sendEmailToProvider = null,
            bool? isFlexible = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendInvoice(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Title = title,
                Description = description,
                Payload = payload,
                ProviderToken = providerToken,
                Currency = currency,
                Prices = prices,
                MaxTipAmount = maxTipAmount,
                SuggestedTipAmounts = suggestedTipAmounts,
                StartParameter = startParameter,
                ProviderData = providerData,
                PhotoUrl = photoUrl,
                PhotoSize = photoSize,
                PhotoWidth = photoWidth,
                PhotoHeight = photoHeight,
                NeedName = needName,
                NeedPhoneNumber = needPhoneNumber,
                NeedEmail = needEmail,
                NeedShippingAddress = needShippingAddress,
                SendPhoneNumberToProvider = sendPhoneNumberToProvider,
                SendEmailToProvider = sendEmailToProvider,
                IsFlexible = isFlexible,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
