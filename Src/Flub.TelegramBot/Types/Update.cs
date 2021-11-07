using Flub.Utils.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an incoming update.
    /// At most one of the optional parameters can be present in any given update.
    /// </summary>
    public class Update
    {
        /// <summary>
        /// The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially.
        /// This ID becomes especially handy if you're using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.
        /// If there are no new updates for at least a week, then identifier of the next update will be chosen randomly instead of sequentially.
        /// </summary>
        [Required]
        [JsonPropertyName("update_id")]
        public int? Id { get; set; }
        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        [JsonPropertyName("message")]
        [UpdateType(UpdateType.Message)]
        public Message Message { get; set; }
        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited.
        /// </summary>
        [JsonPropertyName("edited_message")]
        [UpdateType(UpdateType.EditedMessage)]
        public Message EditedMessage { get; set; }
        /// <summary>
        /// Optional. New incoming channel post of any kind — text, photo, sticker, etc.
        /// </summary>
        [JsonPropertyName("channel_post")]
        [UpdateType(UpdateType.ChannelPost)]
        public Message ChannelPost { get; set; }
        /// <summary>
        /// Optional. New version of a channel post that is known to the bot and was edited.
        /// </summary>
        [JsonPropertyName("edited_channel_post")]
        [UpdateType(UpdateType.EditedChannelPost)]
        public Message EditedChannelPost { get; set; }
        /// <summary>
        /// Optional. New incoming inline query.
        /// </summary>
        [JsonPropertyName("inline_query")]
        [UpdateType(UpdateType.InlineQuery)]
        public InlineQuery InlineQuery { get; set; }
        /// <summary>
        /// Optional. The result of an inline query that was chosen by a user and sent to their chat partner.
        /// Please see the documentation on the <see href="https://core.telegram.org/bots/inline#collecting-feedback">feedback collecting</see> for details
        /// on how to enable these updates for your bot.
        /// </summary>
        [JsonPropertyName("chosen_inline_result")]
        [UpdateType(UpdateType.ChosenInlineResult)]
        public ChosenInlineResult ChosenInlineResult { get; set; }
        /// <summary>
        /// Optional. New incoming callback query.
        /// </summary>
        [JsonPropertyName("callback_query")]
        [UpdateType(UpdateType.CallbackQuery)]
        public CallbackQuery CallbackQuery { get; set; }
        /// <summary>
        /// Optional. New incoming shipping query. Only for invoices with flexible price.
        /// </summary>
        [JsonPropertyName("shipping_query")]
        [UpdateType(UpdateType.ShippingQuery)]
        public ShippingQuery ShippingQuery { get; set; }
        /// <summary>
        /// Optional. New incoming pre-checkout query. Contains full information about checkout.
        /// </summary>
        [JsonPropertyName("pre_checkout_query")]
        [UpdateType(UpdateType.PreCheckoutQuery)]
        public PreCheckoutQuery PreCheckoutQuery { get; set; }
        /// <summary>
        /// Optional. New poll state. Bots receive only updates about stopped polls and polls, which are sent by the bot.
        /// </summary>
        [JsonPropertyName("poll")]
        [UpdateType(UpdateType.Poll)]
        public Poll Poll { get; set; }
        /// <summary>
        /// Optional. A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.
        /// </summary>
        [JsonPropertyName("poll_answer")]
        [UpdateType(UpdateType.PollAnswer)]
        public PollAnswer PollAnswer { get; set; }
        /// <summary>
        /// Optional. The bot's chat member status was updated in a chat. For private chats, this update is received only when the bot is blocked or unblocked by the user.
        /// </summary>
        [JsonPropertyName("my_chat_member")]
        [UpdateType(UpdateType.MyChatMember)]
        public ChatMemberUpdated MyChatMember { get; set; }
        /// <summary>
        /// Optional. A chat member's status was updated in a chat.
        /// The bot must be an administrator in the chat and must explicitly specify <see cref="UpdateType.ChatMember"/>
        /// in the list of <see cref="Methods.GetUpdates.AllowedUpdates"/> or <see cref="Methods.SetWebhook.AllowedUpdates"/> to receive these updates.
        /// </summary>
        [JsonPropertyName("chat_member")]
        [UpdateType(UpdateType.ChatMember)]
        public ChatMemberUpdated ChatMember { get; set; }

        public override string ToString() => $"{nameof(Update)}[{Id}]";

        private static readonly ImmutableDictionary<PropertyInfo, UpdateType> properties = typeof(Update).GetProperties()
            .Select(p => new KeyValuePair<PropertyInfo, UpdateType>(p, p.GetCustomAttribute<UpdateTypeAttribute>()?.Value ?? UpdateType.None))
            .Where(i => i.Value is not UpdateType.None)
            .ToImmutableDictionary(i => i.Key, i => i.Value);

        /// <summary>
        /// List of available <see cref="UpdateType"/> and its associated value in this update.
        /// </summary>
        [JsonIgnore]
        public IEnumerable<KeyValuePair<UpdateType, object>> Types => properties
            .Select(i => new KeyValuePair<UpdateType, object>(i.Value, i.Key.GetValue(this)))
            .Where(i => i.Value is not null);

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        private sealed class UpdateTypeAttribute : Attribute
        {
            public UpdateType Value { get; }

            public UpdateTypeAttribute(UpdateType value)
            {
                Value = value;
            }
        }
    }

    /// <summary>
    /// Available update types.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum UpdateType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("message")]
        Message = 0x1,
        [JsonFieldValue("edited_message")]
        EditedMessage = 0x2,
        [JsonFieldValue("channel_post")]
        ChannelPost = 0x4,
        [JsonFieldValue("edited_channel_post")]
        EditedChannelPost = 0x8,
        [JsonFieldValue("inline_query")]
        InlineQuery = 0x10,
        [JsonFieldValue("chosen_inline_result")]
        ChosenInlineResult = 0x20,
        [JsonFieldValue("callback_query")]
        CallbackQuery = 0x40,
        [JsonFieldValue("shipping_query")]
        ShippingQuery = 0x80,
        [JsonFieldValue("pre_checkout_query")]
        PreCheckoutQuery = 0x100,
        [JsonFieldValue("poll")]
        Poll = 0x200,
        [JsonFieldValue("poll_answer")]
        PollAnswer = 0x400,
        [JsonFieldValue("my_chat_member")]
        MyChatMember = 0x800,
        [JsonFieldValue("chat_member")]
        ChatMember = 0x1000
    }
}
