using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to edit animation, audio, document, photo, or video messages.
    /// If a message is part of a message album, then it can be edited only to an audio for audio albums,
    /// only to a document for document albums and to a photo or a video otherwise.
    /// When an inline message is edited, a new file can't be uploaded; use a previously uploaded file via its <see cref="InputFile.FileId"/> or specify a URL.
    /// On success, if the edited message is not an inline message, the edited <see cref="Message"/> is returned, otherwise <see langword="true"/> is returned.
    /// </summary>
    public class EditMessageMedia<TResult> : MethodUpload<TResult>
    {
        /// <summary>
        /// A <see cref="InputMedia"/> object for a new media content of the message.
        /// </summary>
        [Required]
        [JsonPropertyName("media")]
        public InputMedia Media { get; set; }
        /// <summary>
        /// A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        protected override IEnumerable<InputFile> Files => Media is IFileContainer container ? container.Files : null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditMessageMedia{TResult}"/> class.
        /// </summary>
        public EditMessageMedia() : base("editMessageMedia") { }
    }

    /// <summary>
    /// Use this method to edit animation, audio, document, photo, or video messages.
    /// If a message is part of a message album, then it can be edited only to an audio for audio albums,
    /// only to a document for document albums and to a photo or a video otherwise.
    /// When an inline message is edited, a new file can't be uploaded; use a previously uploaded file via its <see cref="InputFile.FileId"/> or specify a URL.
    /// On success, the edited <see cref="Message"/> is returned.
    /// </summary>
    public class EditMessageMedia : EditMessageMedia<Message>
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
        public long? MessageId { get; set; }
    }

    /// <summary>
    /// Use this method to edit animation, audio, document, photo, or video messages.
    /// If a message is part of a message album, then it can be edited only to an audio for audio albums,
    /// only to a document for document albums and to a photo or a video otherwise.
    /// When an inline message is edited, a new file can't be uploaded; use a previously uploaded file via its <see cref="InputFile.FileId"/> or specify a URL.
    /// On success, <see langword="true"/> is returned.
    /// </summary>
    public class EditInlineMessageMedia : EditMessageMedia<bool?>
    {
        /// <summary>
        /// Identifier of the inline message.
        /// </summary>
        [Required]
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
    }

    public static class EditMessageMediaExtension
    {
        private static Task<TResult> EditMessageMedia<TResult>(this TelegramBot bot, EditMessageMedia<TResult> method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to edit animation, audio, document, photo, or video messages.
        /// If a message is part of a message album, then it can be edited only to an audio for audio albums,
        /// only to a document for document albums and to a photo or a video otherwise.
        /// When an inline message is edited, a new file can't be uploaded; use a previously uploaded file via its <see cref="InputFile.FileId"/> or specify a URL.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the message to edit.</param>
        /// <param name="media">A <see cref="InputMedia"/> object for a new media content of the message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageMedia(this TelegramBot bot,
            string chatId,
            long? messageId,
            InputMedia media,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageMedia(bot, new EditMessageMedia
            {
                ChatId = chatId,
                MessageId = messageId,
                Media = media,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit animation, audio, document, photo, or video messages.
        /// If a message is part of a message album, then it can be edited only to an audio for audio albums,
        /// only to a document for document albums and to a photo or a video otherwise.
        /// When an inline message is edited, a new file can't be uploaded; use a previously uploaded file via its <see cref="InputFile.FileId"/> or specify a URL.
        /// On success, the edited <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The message to edit.</param>
        /// <param name="media">A <see cref="InputMedia"/> object for a new media content of the message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> EditMessageMedia(this TelegramBot bot,
            IChat chat,
            IMessage message,
            InputMedia media,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageMedia(bot, new EditMessageMedia
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                Media = media,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit animation, audio, document, photo, or video messages.
        /// If a message is part of a message album, then it can be edited only to an audio for audio albums,
        /// only to a document for document albums and to a photo or a video otherwise.
        /// When an inline message is edited, a new file can't be uploaded; use a previously uploaded file via its <see cref="InputFile.FileId"/> or specify a URL.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessageId">Identifier of the inline message.</param>
        /// <param name="media">A <see cref="InputMedia"/> object for a new media content of the message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageMedia(this TelegramBot bot,
            string inlineMessageId,
            InputMedia media,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageMedia(bot, new EditInlineMessageMedia
            {
                InlineMessageId = inlineMessageId,
                Media = media,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to edit animation, audio, document, photo, or video messages.
        /// If a message is part of a message album, then it can be edited only to an audio for audio albums,
        /// only to a document for document albums and to a photo or a video otherwise.
        /// When an inline message is edited, a new file can't be uploaded; use a previously uploaded file via its <see cref="InputFile.FileId"/> or specify a URL.
        /// On success, <see langword="true"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="media">A <see cref="InputMedia"/> object for a new media content of the message.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> EditMessageMedia(this TelegramBot bot,
            IInlineMessage inlineMessage,
            InputMedia media,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            EditMessageMedia(bot, new EditInlineMessageMedia
            {
                InlineMessageId = inlineMessage?.InlineMessageId,
                Media = media,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
