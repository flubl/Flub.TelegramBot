using Flub.TelegramBot.Types;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to set the score of the specified user in a game message.
    /// On success, if the message is not an inline message, the <see cref="Message"/> is returned,
    /// otherwise <see langword="true"/> is returned.
    /// Returns an error, if the new score is not greater than the user's current score in the chat and <see cref="Force"/> is <see langword="false"/>.
    /// </summary>
    public abstract class SetGameScore<TResult> : Method<TResult>
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// New score, must be non-negative.
        /// </summary>
        [Required]
        [JsonPropertyName("score")]
        public int? Score { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters.
        /// </summary>
        [JsonPropertyName("force")]
        public bool? Force { get; set; }
        /// <summary>
        /// Pass <see langword="true"/>, if the game message should not be automatically edited to include the current scoreboard.
        /// </summary>
        [JsonPropertyName("disable_edit_message")]
        public bool? DisableEditMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetGameScore{TResult}"/> class.
        /// </summary>
        protected SetGameScore() : base("setGameScore") { }
    }

    /// <summary>
    /// Use this method to set the score of the specified user in a game message.
    /// On success, the <see cref="Message"/> is returned.
    /// Returns an error, if the new score is not greater than the user's current score in the chat and <see cref="SetGameScore{TResult}.Force"/> is <see langword="false"/>.
    /// </summary>
    public class SetGameScore : SetGameScore<Message>
    {
        /// <summary>
        /// Unique identifier for the target chat.
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long? ChatId { get; set; }
        /// <summary>
        /// Identifier of the sent message.
        /// </summary>
        [JsonPropertyName("message_id")]
        public int? MessageId { get; set; }
    }

    /// <summary>
    /// Use this method to set the score of the specified user in a game message.
    /// On success, <see langword="true"/> is returned.
    /// Returns an error, if the new score is not greater than the user's current score in the chat and <see cref="SetGameScore{TResult}.Force"/> is <see langword="false"/>.
    /// </summary>
    public class SetInlineGameScore : SetGameScore<bool?>
    {
        /// <summary>
        /// Identifier of the inline message.
        /// </summary>
        [JsonPropertyName("inline_message_id")]
        public string InlineMessageId { get; set; }
    }

    public static class SetGameScoreExtension
    {
        private static Task<TResult> SetGameScore<TResult>(this TelegramBot bot, SetGameScore<TResult> method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to set the score of the specified user in a game message.
        /// On success, the <see cref="Message"/> is returned.
        /// Returns an error, if the new score is not greater than the user's current score in the chat and <paramref name="force"/> is <see langword="false"/>.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat.</param>
        /// <param name="messageId">Identifier of the sent message.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="score">New score, must be non-negative.</param>
        /// <param name="force">Pass <see langword="true"/>, if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters.</param>
        /// <param name="disableEditMessage">Pass <see langword="true"/>, if the game message should not be automatically edited to include the current scoreboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SetGameScore(this TelegramBot bot,
            long? chatId,
            int? messageId,
            long? userId,
            int? score,
            bool? force = null,
            bool? disableEditMessage = null,
            CancellationToken cancellationToken = default) =>
            SetGameScore(bot, new SetGameScore
            {
                ChatId = chatId,
                MessageId = messageId,
                UserId = userId,
                Score = score,
                Force = force,
                DisableEditMessage = disableEditMessage
            }, cancellationToken);

        /// <summary>
        /// Use this method to set the score of the specified user in a game message.
        /// On success, the <see cref="Message"/> is returned.
        /// Returns an error, if the new score is not greater than the user's current score in the chat and <paramref name="force"/> is <see langword="false"/>.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">The target chat.</param>
        /// <param name="message">The sent message.</param>
        /// <param name="user">Target user.</param>
        /// <param name="score">New score, must be non-negative.</param>
        /// <param name="force">Pass <see langword="true"/>, if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters.</param>
        /// <param name="disableEditMessage">Pass <see langword="true"/>, if the game message should not be automatically edited to include the current scoreboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<Message> SetGameScore(this TelegramBot bot,
            IChat chat,
            IMessage message,
            IUser user,
            int? score,
            bool? force = null,
            bool? disableEditMessage = null,
            CancellationToken cancellationToken = default) =>
            SetGameScore(bot, new SetGameScore
            {
                ChatId = chat?.Id,
                MessageId = message?.Id,
                UserId = user?.Id,
                Score = score,
                Force = force,
                DisableEditMessage = disableEditMessage
            }, cancellationToken);

        /// <summary>
        /// Use this method to set the score of the specified user in a game message.
        /// On success, <see langword="true"/> is returned.
        /// Returns an error, if the new score is not greater than the user's current score in the chat and <paramref name="force"/> is <see langword="false"/>.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessageId">Identifier of the inline message.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="score">New score, must be non-negative.</param>
        /// <param name="force">Pass <see langword="true"/>, if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters.</param>
        /// <param name="disableEditMessage">Pass <see langword="true"/>, if the game message should not be automatically edited to include the current scoreboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetGameScore(this TelegramBot bot,
            string inlineMessageId,
            long? userId,
            int? score,
            bool? force = null,
            bool? disableEditMessage = null,
            CancellationToken cancellationToken = default) =>
            SetGameScore(bot, new SetInlineGameScore
            {
                InlineMessageId = inlineMessageId,
                UserId = userId,
                Score = score,
                Force = force,
                DisableEditMessage = disableEditMessage
            }, cancellationToken);

        /// <summary>
        /// Use this method to set the score of the specified user in a game message.
        /// On success, <see langword="true"/> is returned.
        /// Returns an error, if the new score is not greater than the user's current score in the chat and <paramref name="force"/> is <see langword="false"/>.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="inlineMessage">The inline message.</param>
        /// <param name="user">Target user.</param>
        /// <param name="score">New score, must be non-negative.</param>
        /// <param name="force">Pass <see langword="true"/>, if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters.</param>
        /// <param name="disableEditMessage">Pass <see langword="true"/>, if the game message should not be automatically edited to include the current scoreboard.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetGameScore(this TelegramBot bot,
            IInlineMessage inlineMessage,
            IUser user,
            int? score,
            bool? force = null,
            bool? disableEditMessage = null,
            CancellationToken cancellationToken = default) =>
            SetGameScore(bot, new SetInlineGameScore
            {
                InlineMessageId = inlineMessage?.InlineMessageId,
                UserId = user?.Id,
                Score = score,
                Force = force,
                DisableEditMessage = disableEditMessage
            }, cancellationToken);
    }
}
