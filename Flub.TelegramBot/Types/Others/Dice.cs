﻿using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents an animated emoji that displays a random value.
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// Emoji on which the dice throw animation is based.
        /// </summary>
        [JsonPropertyName("emoji")]
        public string Emoji { get; set; }
        /// <summary>
        /// Value of the dice, 1-6 for “🎲”, “🎯” and “🎳” base emoji, 1-5 for “🏀” and “⚽” base emoji, 1-64 for “🎰” base emoji.
        /// </summary>
        [JsonPropertyName("value")]
        public int? Value { get; set; }
    }
}
