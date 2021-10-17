using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Basic send method for uploading a file with a thumb image.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public abstract class SendMediaWithThumb<TResult> : SendMedia<TResult>
    {
        /// <summary>
        /// Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side.
        /// The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320.
        /// Thumbnails can't be reused and can be only uploaded as a new file.
        /// </summary>
        [JsonPropertyName("thumb")]
        public InputFile Thumb { get; set; }

        protected override IEnumerable<InputFile> Files => base.Files?.Append(Thumb) ?? Enumerable.Empty<InputFile>().DefaultIfEmpty(Thumb);

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMediaWithThumb{TResult}"/> class with a specified request method.
        /// </summary>
        /// <param name="name">The name of the request method.</param>
        protected SendMediaWithThumb(string name) : base(name) { }
    }
}
