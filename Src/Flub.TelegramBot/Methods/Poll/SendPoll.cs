using Flub.TelegramBot.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Use this method to send a native poll.
    /// On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    public class SendPoll : SendToChatWithReplyMarkup<Message>
    {
        /// <summary>
        /// Poll question, 1-300 characters.
        /// </summary>
        [Required]
        [JsonPropertyName("question")]
        public string Question { get; set; }
        /// <summary>
        /// A list of answer options, 2-10 strings 1-100 characters each.
        /// </summary>
        [Required]
        [JsonPropertyName("options")]
        public IEnumerable<string> Options { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the poll needs to be anonymous, defaults to <see langword="true"/>.
        /// </summary>
        [JsonPropertyName("is_anonymous")]
        public bool? IsAnonymous { get; set; }
        /// <summary>
        /// Poll type, <see cref="PollType.Quiz"/> or <see cref="PollType.Regular"/>, defaults to <see cref="PollType.Regular"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public PollType? Type { get; set; }
        /// <summary>
        /// <see langword="true"/>, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to <see langword="false"/>.
        /// </summary>
        [JsonPropertyName("allows_multiple_answers")]
        public bool? AllowsMultipleAnswers { get; set; }
        /// <summary>
        /// 0-based identifier of the correct answer option, required for polls in quiz mode.
        /// </summary>
        [JsonPropertyName("correct_option_id")]
        public int? CorrectOptionId { get; set; }
        /// <summary>
        /// Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll,
        /// 0-200 characters with at most 2 line feeds after entities parsing.
        /// </summary>
        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }
        /// <summary>
        /// Mode for parsing entities in the explanation. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
        /// </summary>
        [JsonPropertyName("explanation_parse_mode")]
        public ParseMode? ExplanationParseMode { get; set; }
        /// <summary>
        /// A list of special entities that appear in the poll explanation, which can be specified instead of <see cref="ExplanationParseMode"/>.
        /// </summary>
        [JsonPropertyName("explanation_entities")]
        public IEnumerable<MessageEntity> ExplanationEntities { get; set; }
        /// <summary>
        /// Amount of time in seconds the poll will be active after creation, 5-600. Can't be used together with <see cref="CloseDateValue"/> or <see cref="CloseDate"/>.
        /// </summary>
        [JsonPropertyName("open_period")]
        public long? OpenPeriodValue { get; set; }
        /// <summary>
        /// Amount of time the poll will be active after creation, 5-600 seconds. Can't be used together with <see cref="CloseDateValue"/> or <see cref="CloseDate"/>.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? OpenPeriod
        {
            get => OpenPeriodValue.HasValue ? TimeSpan.FromSeconds(OpenPeriodValue.Value) : null;
            set => OpenPeriodValue = value.HasValue ? (long?)value.Value.TotalSeconds : null;
        }
        /// <summary>
        /// Point in time (Unix timestamp) when the poll will be automatically closed.
        /// Must be at least 5 and no more than 600 seconds in the future.
        /// Can't be used together with <see cref="OpenPeriodValue"/> or <see cref="OpenPeriod"/>.
        /// </summary>
        [JsonPropertyName("close_date")]
        public long? CloseDateValue { get; set; }
        /// <summary>
        /// Point in time when the poll will be automatically closed.
        /// Must be at least 5 and no more than 600 seconds in the future.
        /// Can't be used together with <see cref="OpenPeriodValue"/> or <see cref="OpenPeriod"/>.
        /// </summary>
        [JsonIgnore]
        public DateTime? CloseDate
        {
            get => CloseDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(CloseDateValue.Value).DateTime : null;
            set => CloseDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }
        /// <summary>
        /// Pass <see langword="true"/>, if the poll needs to be immediately closed. This can be useful for poll preview.
        /// </summary>
        [JsonPropertyName("is_closed")]
        public bool? IsClosed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendPoll"/> class.
        /// </summary>
        public SendPoll() : base("sendPoll") { }
    }

    public static class SendPollExtension
    {
        private static Task<Message> SendPoll(this TelegramBot bot, SendPoll method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Use this method to send a native poll.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="question">Poll question, 1-300 characters.</param>
        /// <param name="options">A list of answer options, 2-10 strings 1-100 characters each.</param>
        /// <param name="isAnonymous"><see langword="true"/>, if the poll needs to be anonymous, defaults to <see langword="true"/>.</param>
        /// <param name="type">Poll type, <see cref="PollType.Quiz"/> or <see cref="PollType.Regular"/>, defaults to <see cref="PollType.Regular"/>.</param>
        /// <param name="allowsMultipleAnswers"><see langword="true"/>, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to <see langword="false"/>.</param>
        /// <param name="correctOptionId">0-based identifier of the correct answer option, required for polls in quiz mode.</param>
        /// <param name="explanation">
        /// Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll,
        /// 0-200 characters with at most 2 line feeds after entities parsing.
        /// </param>
        /// <param name="explanationParseMode">Mode for parsing entities in the explanation. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="explanationEntities">A list of special entities that appear in the poll explanation, which can be specified instead of <paramref name="explanationParseMode"/>.</param>
        /// <param name="openPeriod">Amount of time in seconds the poll will be active after creation, 5-600. Can't be used together with <paramref name="closeDate"/>.</param>
        /// <param name="closeDate">
        /// Point in time (Unix timestamp) when the poll will be automatically closed.
        /// Must be at least 5 and no more than 600 seconds in the future.
        /// Can't be used together with <paramref name="openPeriod"/>.
        /// </param>
        /// <param name="isClosed">Pass <see langword="true"/>, if the poll needs to be immediately closed. This can be useful for poll preview.</param>
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
        public static Task<Message> SendPoll(this TelegramBot bot,
            string chatId,
            string question,
            IEnumerable<string> options,
            bool? isAnonymous = null,
            PollType? type = null,
            bool? allowsMultipleAnswers = null,
            int? correctOptionId = null,
            string explanation = null,
            ParseMode? explanationParseMode = null,
            IEnumerable<MessageEntity> explanationEntities = null,
            long? openPeriod = null,
            long? closeDate = null,
            bool? isClosed = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendPoll(bot, new()
            {
                ChatId = chatId,
                Question = question,
                Options = options,
                IsAnonymous = isAnonymous,
                Type = type,
                AllowsMultipleAnswers = allowsMultipleAnswers,
                CorrectOptionId = correctOptionId,
                Explanation = explanation,
                ExplanationParseMode = explanationParseMode,
                ExplanationEntities = explanationEntities,
                OpenPeriodValue = openPeriod,
                CloseDateValue = closeDate,
                IsClosed = isClosed,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send a native poll.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="question">Poll question, 1-300 characters.</param>
        /// <param name="options">A list of answer options, 2-10 strings 1-100 characters each.</param>
        /// <param name="isAnonymous"><see langword="true"/>, if the poll needs to be anonymous, defaults to <see langword="true"/>.</param>
        /// <param name="type">Poll type, <see cref="PollType.Quiz"/> or <see cref="PollType.Regular"/>, defaults to <see cref="PollType.Regular"/>.</param>
        /// <param name="allowsMultipleAnswers"><see langword="true"/>, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to <see langword="false"/>.</param>
        /// <param name="correctOptionId">0-based identifier of the correct answer option, required for polls in quiz mode.</param>
        /// <param name="explanation">
        /// Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll,
        /// 0-200 characters with at most 2 line feeds after entities parsing.
        /// </param>
        /// <param name="explanationParseMode">Mode for parsing entities in the explanation. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="explanationEntities">A list of special entities that appear in the poll explanation, which can be specified instead of <paramref name="explanationParseMode"/>.</param>
        /// <param name="openPeriod">Amount of time the poll will be active after creation, 5-600 seconds. Can't be used together with <paramref name="closeDate"/>.</param>
        /// <param name="closeDate">
        /// Point in time when the poll will be automatically closed.
        /// Must be at least 5 and no more than 600 seconds in the future.
        /// Can't be used together with <paramref name="openPeriod"/>.
        /// </param>
        /// <param name="isClosed">Pass <see langword="true"/>, if the poll needs to be immediately closed. This can be useful for poll preview.</param>
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
        public static Task<Message> SendPoll(this TelegramBot bot,
            string chatId,
            string question,
            IEnumerable<string> options,
            bool? isAnonymous = null,
            PollType? type = null,
            bool? allowsMultipleAnswers = null,
            int? correctOptionId = null,
            string explanation = null,
            ParseMode? explanationParseMode = null,
            IEnumerable<MessageEntity> explanationEntities = null,
            TimeSpan? openPeriod = null,
            DateTime? closeDate = null,
            bool? isClosed = null,
            bool? disableNotification = null,
            int? replyToMessageId = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendPoll(bot, new()
            {
                ChatId = chatId,
                Question = question,
                Options = options,
                IsAnonymous = isAnonymous,
                Type = type,
                AllowsMultipleAnswers = allowsMultipleAnswers,
                CorrectOptionId = correctOptionId,
                Explanation = explanation,
                ExplanationParseMode = explanationParseMode,
                ExplanationEntities = explanationEntities,
                OpenPeriod = openPeriod,
                CloseDate = closeDate,
                IsClosed = isClosed,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);

        /// <summary>
        /// Use this method to send a native poll.
        /// On success, the sent <see cref="Message"/> is returned.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="chat">Unique identifier for the target chat or username of the target channel (in the format @channelusername).</param>
        /// <param name="question">Poll question, 1-300 characters.</param>
        /// <param name="options">A list of answer options, 2-10 strings 1-100 characters each.</param>
        /// <param name="isAnonymous"><see langword="true"/>, if the poll needs to be anonymous, defaults to <see langword="true"/>.</param>
        /// <param name="type">Poll type, <see cref="PollType.Quiz"/> or <see cref="PollType.Regular"/>, defaults to <see cref="PollType.Regular"/>.</param>
        /// <param name="allowsMultipleAnswers"><see langword="true"/>, if the poll allows multiple answers, ignored for polls in quiz mode, defaults to <see langword="false"/>.</param>
        /// <param name="correctOptionId">0-based identifier of the correct answer option, required for polls in quiz mode.</param>
        /// <param name="explanation">
        /// Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll,
        /// 0-200 characters with at most 2 line feeds after entities parsing.
        /// </param>
        /// <param name="explanationParseMode">Mode for parsing entities in the explanation. See <see href="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.</param>
        /// <param name="explanationEntities">A list of special entities that appear in the poll explanation, which can be specified instead of <paramref name="explanationParseMode"/>.</param>
        /// <param name="openPeriod">Amount of time the poll will be active after creation, 5-600 seconds. Can't be used together with <paramref name="closeDate"/>.</param>
        /// <param name="closeDate">
        /// Point in time when the poll will be automatically closed.
        /// Must be at least 5 and no more than 600 seconds in the future.
        /// Can't be used together with <paramref name="openPeriod"/>.
        /// </param>
        /// <param name="isClosed">Pass <see langword="true"/>, if the poll needs to be immediately closed. This can be useful for poll preview.</param>
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
        public static Task<Message> SendPoll(this TelegramBot bot,
            IChat chat,
            string question,
            IEnumerable<string> options,
            bool? isAnonymous = null,
            PollType? type = null,
            bool? allowsMultipleAnswers = null,
            int? correctOptionId = null,
            string explanation = null,
            ParseMode? explanationParseMode = null,
            IEnumerable<MessageEntity> explanationEntities = null,
            TimeSpan? openPeriod = null,
            DateTime? closeDate = null,
            bool? isClosed = null,
            bool? disableNotification = null,
            IMessage replyToMessage = null,
            bool? allowSendingWithoutReply = null,
            ReplyMarkup replyMarkup = null,
            CancellationToken cancellationToken = default) =>
            SendPoll(bot, new()
            {
                ChatId = chat?.Id?.ToString(),
                Question = question,
                Options = options,
                IsAnonymous = isAnonymous,
                Type = type,
                AllowsMultipleAnswers = allowsMultipleAnswers,
                CorrectOptionId = correctOptionId,
                Explanation = explanation,
                ExplanationParseMode = explanationParseMode,
                ExplanationEntities = explanationEntities,
                OpenPeriod = openPeriod,
                CloseDate = closeDate,
                IsClosed = isClosed,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessage?.Id,
                AllowSendingWithoutReply = allowSendingWithoutReply,
                ReplyMarkup = replyMarkup
            }, cancellationToken);
    }
}
