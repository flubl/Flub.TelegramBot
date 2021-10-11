using Flub.TelegramBot.Types;
using MimeKit;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot
{
    /// <summary>
    /// This object represents the contents of a file to be uploaded.
    /// There are three ways to send files (photos, stickers, audio, media, etc.):
    /// If the file is already stored somewhere on the Telegram servers, you don't need to reupload it: each file object has a file_id field, simply pass this file_id as a parameter instead of uploading. There are no limits for files sent this way.
    /// Provide Telegram with an HTTP URL for the file to be sent.Telegram will download and send the file. 5 MB max size for photos and 20 MB max for other types of content.
    /// Post the file using multipart/form-data in the usual way that files are uploaded via the browser. 10 MB max size for photos, 50 MB for other files.
    /// </summary>
    [JsonConverter(typeof(JsonInputFileConverter))]
    public class InputFile : IFile
    {
        /// <summary>
        /// The file to be uploaded.
        /// </summary>
        [JsonIgnore]
        public FileStream File { get; set; }
        /// <summary>
        /// HTTP url of the file to be send.
        /// </summary>
        [JsonIgnore]
        public Uri Url { get; set; }
        /// <summary>
        /// Id of a file from the telegram servers.
        /// </summary>
        [JsonIgnore]
        public string FileId { get; set; }
        /// <summary>
        /// True, if <see cref="File"/> is set and is valid.
        /// </summary>
        [JsonIgnore]
        public bool IsFile => File?.Valid ?? false;

        string IFile.Id => FileId;

        /// <summary>
        /// Ensures that only one parameter is set. Throws an <see cref="TelegramBotException"/> otherwise.
        /// </summary>
        public void EnsureSinglePropertyIsSet()
        {
            if (((IsFile ? 1 : 0) + (Url is null ? 0 : 1) + (FileId is null ? 0 : 1)) != 1)
                throw new TelegramBotException("The input file contains no or more than one properties.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputFile"/> class from the specified fileinfo and sets <see cref="File"/>.
        /// </summary>
        /// <param name="fileName">Fileinfo of the file to be uploaded.</param>
        /// <returns>Returns a new instance of the <see cref="InputFile"/></returns>
        public static InputFile FromFile(FileInfo file) => new()
        {
            File = new FileStream
            {
                Name = file.Name,
                Type = MimeTypes.GetMimeType(file.Extension),
                Stream = file.OpenRead()
            }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="InputFile"/> class from the specified file and sets <see cref="File"/>.
        /// </summary>
        /// <param name="fileName">Path to the file to be uploaded.</param>
        /// <returns>Returns a new instance of the <see cref="InputFile"/></returns>
        public static InputFile FromFile(string fileName) =>
            FromFile(new FileInfo(fileName));

        /// <summary>
        /// Initializes a new instance of the <see cref="InputFile"/> class with the <see cref="FileId"/> of the specified value.
        /// </summary>
        /// <param name="fileName">The file id of the file to be send.</param>
        /// <returns>Returns a new instance of the <see cref="InputFile"/></returns>
        public static InputFile FromFileId(string fileId) => new() { FileId = fileId };

        /// <summary>
        /// Initializes a new instance of the <see cref="InputFile"/> class with the <see cref="FileId"/> of the specified file.
        /// </summary>
        /// <param name="fileName">The file to be send.</param>
        /// <returns>Returns a new instance of the <see cref="InputFile"/></returns>
        public static InputFile FromFileId(IFile file) => FromFileId(file?.Id);

        /// <summary>
        /// Initializes a new instance of the <see cref="InputFile"/> class with the <see cref="Url"/> of the specified url.
        /// </summary>
        /// <param name="fileName">The url of the to be send.</param>
        /// <returns>Returns a new instance of the <see cref="InputFile"/></returns>
        public static InputFile FromUrl(Uri url) => new() { Url = url };

        public static implicit operator InputFile(FileInfo file) => FromFile(file);
        public static implicit operator InputFile(string fileId) => FromFileId(fileId);
        public static implicit operator InputFile(Uri url) => FromUrl(url);
        public static implicit operator InputFile(FileBase file) => FromFileId(file.Id);

        private class JsonInputFileConverter : JsonConverter<InputFile>
        {
            public override InputFile Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotSupportedException();
            }

            public override void Write(Utf8JsonWriter writer, InputFile value, JsonSerializerOptions options)
            {
                value.EnsureSinglePropertyIsSet();
                writer.WriteStringValue(value.FileId ?? value.Url?.ToString() ?? value.File?.AttachValue);
            }
        }

        /// <summary>
        /// Contains informations about a file to be uploaded.
        /// </summary>
        public class FileStream
        {
            /// <summary>
            /// Unique identifier for the upload of this file.
            /// </summary>
            [JsonIgnore]
            public Guid Id { get; } = Guid.NewGuid();
            /// <summary>
            /// Unique identifier path in form of "attack://{Id}".
            /// </summary>
            [JsonIgnore]
            public string AttachValue => $"attach://{Id}";
            /// <summary>
            /// Name of the file to be uploaded.
            /// </summary>
            [JsonIgnore]
            public string Name { get; set; }
            /// <summary>
            /// MIME type of the file to be uploaded.
            /// </summary>
            [JsonIgnore]
            public string Type { get; set; }
            /// <summary>
            /// Readable stream of the file to be uploaded.
            /// </summary>
            [JsonIgnore]
            public Stream Stream { get; set; }

            /// <summary>
            /// True, if the stream and name is set.
            /// </summary>
            [JsonIgnore]
            public bool Valid => Stream is not null && !string.IsNullOrEmpty(Name);
        }
    }
}
