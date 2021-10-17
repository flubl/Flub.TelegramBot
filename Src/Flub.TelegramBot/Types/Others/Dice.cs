using Flub.Utils.Json;
using System;
using System.Text.Json.Serialization;

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
        public DiceType? Emoji { get; set; }
        /// <summary>
        /// Value of the dice, 1-6 for <see cref="DiceType.Dice"/> “🎲”, <see cref="DiceType.BullsEye"/> “🎯” and <see cref="DiceType.Bowling"/> “🎳” base emoji, 
        /// 1-5 for <see cref="DiceType.Basketball"/> “🏀” and <see cref="DiceType.Football"/> “⚽” base emoji, 1-64 for <see cref="DiceType.SlotMachine"/> “🎰” base emoji.
        /// </summary>
        [JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    /// <summary>
    /// Emoji on which the dice throw animation is based. Currently, must be one of “🎲”, “🎯”, “🏀”, “⚽”, “🎳”, or “🎰”.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter<DiceType>))]
    public enum DiceType : int
    {
        [JsonIgnore]
        None = 0,
        /// <summary>
        /// 🎲 Values 1-6
        /// </summary>
        [JsonFieldValue("🎲")]
        Dice = 0x1,
        /// <summary>
        /// 🎯 Values 1-6
        /// </summary>
        [JsonFieldValue("🎯")]
        BullsEye = 0x2,
        /// <summary>
        /// 🎯 Values 1-6
        /// </summary>
        [JsonFieldValue("🎳")]
        Bowling = 0x4,
        /// <summary>
        /// 🎳 Values 1-5
        /// </summary>
        [JsonFieldValue("🏀")]
        Basketball = 0x8,
        /// <summary>
        /// ⚽ Values 1-5
        /// </summary>
        [JsonFieldValue("⚽")]
        Football = 0x10,
        /// <summary>
        /// 🎰 Values 1-64
        /// </summary>
        [JsonFieldValue("🎰")]
        SlotMachine = 0x20
    }
}
