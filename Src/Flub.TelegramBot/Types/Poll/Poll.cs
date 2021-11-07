using Flub.Utils.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object contains information about a poll.
    /// </summary>
    public class Poll
    {
        /// <summary>
        /// Unique poll identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Poll question, 1-300 characters.
        /// </summary>
        [JsonPropertyName("question")]
        public string Question { get; set; }
        /// <summary>
        /// List of poll options.
        /// </summary>
        [JsonPropertyName("options")]
        public IEnumerable<PollOption> Options { get; set; }
        /// <summary>
        /// Total number of users that voted in the poll.
        /// </summary>
        [JsonPropertyName("total_voter_count")]
        public int? TotalVoterCount { get; set; }
        /// <summary>
        /// True, if the poll is closed.
        /// </summary>
        [JsonPropertyName("is_closed")]
        public bool? IsClosed { get; set; }
        /// <summary>
        /// True, if the poll is anonymous.
        /// </summary>
        [JsonPropertyName("is_anonymous")]
        public bool? IsAnonymous { get; set; }
        /// <summary>
        /// Poll type, currently can be "regular" or "quiz".
        /// </summary>
        [JsonPropertyName("type")]
        public PollType? Type { get; set; }
        /// <summary>
        /// True, if the poll allows multiple answers.
        /// </summary>
        [JsonPropertyName("allows_multiple_answers")]
        public bool? AllowsMultipleAnswers { get; set; }
        /// <summary>
        /// Optional. Identifier of the correct answer option. Available only for polls in the quiz mode, which are closed, or was sent (not forwarded) by the bot or to the private chat with the bot.
        /// </summary>
        [JsonPropertyName("correct_option_id")]
        public int? CorrectOptionId { get; set; }
        /// <summary>
        /// Optional. Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll, 0-200 characters.
        /// </summary>
        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }
        /// <summary>
        /// Optional. Special entities like usernames, URLs, bot commands, etc. that appear in the explanation.
        /// </summary>
        [JsonPropertyName("explanation_entities")]
        public IEnumerable<MessageEntity> ExplanationEntries { get; set; }
        /// <summary>
        /// Optional. Amount of time in seconds the poll will be active after creation.
        /// </summary>
        [JsonPropertyName("open_period")]
        public int? OpenPeriod { get; set; }
        /// <summary>
        /// Optional. Point in time (Unix timestamp) when the poll will be automatically closed.
        /// </summary>
        [JsonPropertyName("close_date")]
        public long? CloseDateValue { get; set; }
        /// <summary>
        /// Optional. Point in time when the poll will be automatically closed.
        /// </summary>
        [JsonIgnore]
        public DateTime? CloseDate
        {
            get => CloseDateValue.HasValue ? DateTimeOffset.FromUnixTimeSeconds(CloseDateValue.Value).DateTime : null;
            set => CloseDateValue = value.HasValue ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : null;
        }

        public override string ToString() => $"{nameof(Poll)}[{Id}, {Options.Count()} options, {TotalVoterCount} votes]";
    }

    /// <summary>
    /// Poll type, currently can be "regular" or "quiz".
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum PollType : int
    {
        [JsonIgnore]
        None = 0x0,
        [JsonFieldValue("regular")]
        Regular = 0x1,
        [JsonFieldValue("quiz")]
        Quiz = 0x2
    }
}
