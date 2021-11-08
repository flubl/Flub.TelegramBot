using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to get data for high score tables.
    /// Will return the score of the specified user and several of their neighbors in a game.
    /// On success, returns an array of <see cref="GameHighScore"/> objects.
    /// </summary>
    public class GetGameHighScores : Method<GameHighScore[]>
    {
        /// <summary>
        /// Target user id.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// Required if <see cref="InlineMessageId"/> is not specified. Unique identifier for the target chat.
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long? ChatId { get; set; }
        /// <summary>
        /// Required if <see cref="InlineMessageId"/> is not specified. Identifier of the sent message.
        /// </summary>
        [JsonPropertyName("message_id")]
        public int? MessageId { get; set; }
        /// <summary>
        /// Required if <see cref="ChatId"/> and <see cref="MessageId"/> are not specified. Identifier of the inline message.
        /// </summary>
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetGameHighScores"/> class.
        /// </summary>
        public GetGameHighScores() : base("getGameHighScores") { }
    }

    public static class GetGameHighScoresExtension
    {
        private static Task<GameHighScore[]> GetGameHighScores(this TelegramBot bot, GetGameHighScores method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to get data for high score tables.
        /// Will return the score of the specified user and several of their neighbors in a game.
        /// On success, returns an array of <see cref="GameHighScore"/> objects.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="userId">Target user id.</param>
        /// <param name="chatId">Required if <paramref name="inlineMessageId"/> is not specified. Unique identifier for the target chat.</param>
        /// <param name="messageId">Required if <paramref name="inlineMessageId"/> is not specified. Identifier of the sent message.</param>
        /// <param name="inlineMessageId">Required if <paramref name="chatId"/> and <paramref name="messageId"/> are not specified. Identifier of the inline message.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<GameHighScore[]> GetGameHighScores(this TelegramBot bot,
            long? userId,
            long? chatId = null,
            int? messageId = null,
            string inlineMessageId = null,
            CancellationToken cancellationToken = default) =>
            GetGameHighScores(bot, new()
            {
                UserId = userId,
                ChatId = chatId,
                MessageId = messageId,
                InlineMessageId = inlineMessageId
            }, cancellationToken);

        /// <summary>
        /// Use this method to get data for high score tables.
        /// Will return the score of the specified user and several of their neighbors in a game.
        /// On success, returns an array of <see cref="GameHighScore"/> objects.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Target user.</param>
        /// <param name="chat">Required if <paramref name="inlineMessage"/> is not specified. The target chat.</param>
        /// <param name="message">Required if <paramref name="inlineMessage"/> is not specified. The sent message.</param>
        /// <param name="inlineMessage">Required if <paramref name="chat"/> and <paramref name="message"/> are not specified. The inline message.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<GameHighScore[]> GetGameHighScores(this TelegramBot bot,
            IUser user,
            IChat chat = null,
            IMessage message = null,
            IInlineMessage inlineMessage = null,
            CancellationToken cancellationToken = default) =>
            GetGameHighScores(bot, new()
            {
                UserId = user?.Id,
                ChatId = chat?.Id,
                MessageId = message?.Id,
                InlineMessageId = inlineMessage?.InlineMessageId
            }, cancellationToken);

        /// <summary>
        /// Use this method to get data for high score tables.
        /// Will return the score of the specified user and several of their neighbors in a game.
        /// On success, returns an array of <see cref="GameHighScore"/> objects.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Target user.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The sent message.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<GameHighScore[]> GetGameHighScores(this TelegramBot bot,
            IUser user,
            IChat chat = null,
            IMessage message = null,
            CancellationToken cancellationToken = default) =>
            GetGameHighScores(bot, new()
            {
                UserId = user?.Id,
                ChatId = chat?.Id,
                MessageId = message?.Id
            }, cancellationToken);

        /// <summary>
        /// Use this method to get data for high score tables.
        /// Will return the score of the specified user and several of their neighbors in a game.
        /// On success, returns an array of <see cref="GameHighScore"/> objects.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Target user.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<GameHighScore[]> GetGameHighScores(this TelegramBot bot,
            IUser user,
            IInlineMessage inlineMessage = null,
            CancellationToken cancellationToken = default) =>
            GetGameHighScores(bot, new()
            {
                UserId = user?.Id,
                InlineMessageId = inlineMessage?.InlineMessageId
            }, cancellationToken);
    }
}
