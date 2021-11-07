using Flub.TelegramBot.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Basic send method for uploading a file.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class SendMedia<TResult> : MethodUpload<TResult>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Caption, 0-1024 characters after entities parsing.
        /// </summary>
        [JsonPropertyName("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// Mode for parsing entities in the caption. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("parse_mode")]
        public ParseMode? ParseMode { get; set; }
        /// <summary>
        /// List of special entities that appear in the caption, which can be specified instead of <see cref="ParseMode"/>.
        /// </summary>
        [JsonPropertyName("caption_entities")]
        public IEnumerable<MessageEntity> CaptionEntities { get; set; }
        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        [JsonPropertyName("disable_notification")]
        public bool? DisableNotification { get; set; }
        /// <summary>
        /// If the message is a reply, ID of the original message.
        /// </summary>
        [JsonPropertyName("reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if the message should be sent even if the specified replied-to message is not found.
        /// </summary>
        [JsonPropertyName("allow_sending_without_reply")]
        public bool? AllowSendingWithoutReply { get; set; }
        /// <summary>
        /// Additional interface options.
        /// A object for an <see href="https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating">inline keyboard</see> (<see cref="InlineKeyboardMarkup"/>),
        /// <see href="https://core.telegram.org/bots#keyboards">custom reply keyboard</see> (<see cref="ReplyKeyboardMarkup"/>),
        /// instructions to remove reply keyboard (<see cref="ReplyKeyboardRemove"/>) or to force a reply from the user (<see cref="ForceReply"/>).
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public ReplyMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// File to send. Pass a file id as <see cref="string"/> or <see cref="Types.File"/> to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </summary>
        public abstract InputFile File { get; set; }

        protected override IEnumerable<InputFile> Files { get { yield return File; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMedia{TResult}"/> class with a specified request method.
        /// </summary>
        /// <param name="name">The name of the request method.</param>
        protected SendMedia(string name) : base(name) { }
    }
}
