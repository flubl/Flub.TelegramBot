using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents type of a poll, which is allowed to be created and sent when the corresponding button is pressed.
    /// </summary>
    public class KeyboardButtonPollType
    {
        /// <summary>
        /// Optional. If <see cref="PollType.Quiz"/> is passed, the user will be allowed to create only polls in the quiz mode.
        /// If <see cref="PollType.Regular"/> is passed, only regular polls will be allowed. 
        /// Otherwise, the user will be allowed to create a poll of any type.
        /// </summary>
        [JsonPropertyName("type")]
        public PollType Type { get; set; }

        public override string ToString() => $"{nameof(KeyboardButtonPollType)}[{Type}]";
    }
}
