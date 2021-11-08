using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents a game.
    /// Use <see href="https://t.me/botfather">BotFather</see> to create and edit games,
    /// their short names will act as unique identifiers.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Title of the game.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Description of the game.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// Photo that will be displayed in the game message in chats.
        /// </summary>
        [JsonPropertyName("photo")]
        public IEnumerable<PhotoSize> Photo { get; set; }
        /// <summary>
        /// Optional. Brief description of the game or high scores included in the game message.
        /// Can be automatically edited to include current high scores for the game when the bot calls <see cref="Methods.SetGameScore"/>,
        /// or manually edited using <see cref="Methods.EditMessageText"/>. 0-4096 characters.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.
        /// </summary>
        [JsonPropertyName("text_entities")]
        public IEnumerable<MessageEntity> TextEntities { get; set; }
        /// <summary>
        /// Optional. Animation that will be displayed in the game message in chats.
        /// Upload via <see href="https://t.me/botfather">BotFather</see>.
        /// </summary>
        [JsonPropertyName("animation")]
        public Animation Animation { get; set; }

        public override string ToString() => $"{nameof(Game)}[{Title}]";
    }
}
