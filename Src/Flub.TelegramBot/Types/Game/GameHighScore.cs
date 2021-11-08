using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents one row of the high scores table for a game.
    /// </summary>
    public class GameHighScore
    {
        /// <summary>
        /// Position in high score table for the game.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }
        /// <summary>
        /// User.
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
        /// <summary>
        /// Score.
        /// </summary>
        [JsonPropertyName("score")]
        public int? Score { get; set; }

        public override string ToString() => $"{nameof(GameHighScore)}[{User}, {Score}, #{Position}]";
    }
}
