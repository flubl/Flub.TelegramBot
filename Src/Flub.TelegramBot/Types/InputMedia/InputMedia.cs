using Flub.Utils.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// This object represents the content of a media message to be sent. It should be one of
    /// <see cref="InputMediaAnimation"/>,
    /// <see cref="InputMediaDocument"/>,
    /// <see cref="InputMediaAudio"/>,
    /// <see cref="InputMediaPhoto"/>,
    /// <see cref="InputMediaVideo"/>
    /// </summary>
    [JsonConverter(typeof(JsonConvertByGetTypeConverter))]
    public abstract class InputMedia : IFileContainer
    {
        /// <summary>
        /// Type of the media.
        /// </summary>
        [JsonPropertyName("type")]
        public InputMediaType Type { get; }
        /// <summary>
        /// Pass a file id as <see cref="string"/> or <see cref="File"/> to send a file that exists on the Telegram servers (recommended),
        /// pass an HTTP URL as a <see cref="Uri"/> for Telegram to get a file from the Internet, or upload a new one using <see cref="InputFile"/>.
        /// </summary>
        [JsonPropertyName("media")]
        public InputFile Media { get; set; }

        /// <summary>
        /// The files to be uploaded.
        /// </summary>
        protected virtual IEnumerable<InputFile> Files { get { yield return Media; } }

        bool IFileContainer.HasFiles => ((IFileContainer)this).Files?.Any() ?? false;
        IEnumerable<InputFile> IFileContainer.Files => Files?.Where(f => f?.IsFile ?? false);

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMedia"/> class with a specified type.
        /// </summary>
        /// <param name="type">The type of the media.</param>
        protected InputMedia(InputMediaType type)
        {
            Type = type;
        }

        public override string ToString() => $"{nameof(InputMedia)}[{Type}]";
    }

    /// <summary>
    /// Available input media types.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(JsonFieldEnumConverter))]
    public enum InputMediaType : int
    {
        [JsonInclude]
        None = 0x0,
        [JsonFieldValue("photo")]
        Photo = 0x1,
        [JsonFieldValue("video")]
        Video = 0x2,
        [JsonFieldValue("animation")]
        Animation = 0x4,
        [JsonFieldValue("audio")]
        Audio = 0x8,
        [JsonFieldValue("document")]
        Document = 0x10
    }
}
