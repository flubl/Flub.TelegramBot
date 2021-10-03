using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Types
{
    /// <summary>
    /// Represents a media with thumb to be sent.
    /// </summary>
    public abstract class InputMediaWithThumb : InputMediaPhoto
    {
        /// <summary>
        /// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320. Ignored if the file is not uploaded using multipart/form-data. Thumbnails can't be reused and can be only uploaded as a new file.
        /// </summary>
        [JsonPropertyName("thumb")]
        public InputFile Thumb { get; set; }

        /// <summary>
        /// The files to be uploaded.
        /// </summary>
        protected override IEnumerable<InputFile> Files
        {
            get
            {
                foreach (var item in base.Files.Where(f => f is not null))
                    yield return item;
                if (Thumb?.IsFile ?? false)
                    yield return Thumb;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputMediaWithThumb"/> class with a specified type.
        /// </summary>
        /// <param name="type">The type of the media.</param>
        protected InputMediaWithThumb(InputMediaType type)
            : base(type)
        {

        }
    }
}
