using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a Game.
    /// </summary>
    public class InlineQueryResultGame : InlineQueryResult
    {
        /// <summary>
        /// Short name of the game.
        /// </summary>
        [JsonPropertyName("game_short_name")]
        public string GameShortName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineQueryResultGame"/> class.
        /// </summary>
        public InlineQueryResultGame() : base(InlineQueryResultType.Game) { }

        public override string ToString() => $"{nameof(InlineQueryResultGame)}[{Id}, {GameShortName}]";
    }
}
