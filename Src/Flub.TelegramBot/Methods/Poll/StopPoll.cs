using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to stop a poll which was sent by the bot.
    /// On success, the stopped <see cref="Poll"/> is returned.
    /// </summary>
    public class StopPoll : Method<Poll>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername).
        /// </summary>
        [Required]
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; }
        /// <summary>
        /// Identifier of the original message with the poll.
        /// </summary>
        [Required]
        [JsonPropertyName("message_id")]
        public long? MessageId { get; set; }
        /// <summary>
        /// A <see cref="InlineKeyboardMarkup"/> object for a new message inline keyboard.
        /// </summary>
        [JsonPropertyName("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StopPoll"/> class.
        /// </summary>
        public StopPoll() : base("stopPoll") { }
    }

    public static class StopPollExtension
    {
        private static Task<Poll> StopPoll(this TelegramBot bot, StopPoll method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to stop a poll which was sent by the bot.
        /// On success, the stopped <see cref="Poll"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="messageId">Identifier of the original message with the poll.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new message inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Poll> StopPoll(this TelegramBot bot,
            string chatId,
            long? messageId,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            StopPoll(bot, new()
            {
                ChatId = chatId,
                MessageId = messageId,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to stop a poll which was sent by the bot.
        /// On success, the stopped <see cref="Poll"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The original message with the poll.</param>
        /// <param name="replyMarkup">A <see cref="InlineKeyboardMarkup"/> object for a new message inline keyboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Poll> StopPoll(this TelegramBot bot,
            IChat chat,
            IMessage message,
            InlineKeyboardMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            StopPoll(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                MessageId = message?.Id,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
