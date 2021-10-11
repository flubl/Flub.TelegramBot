using Flub.TelegramBot.Types;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Flub.TelegramBot.Request.Tests
{
    [ExcludeFromCodeCoverage]
    public class InputFileTests : IDisposable
    {
        static readonly Stream fileStream = new MemoryStream();
        static readonly string fileName = $"{Guid.NewGuid()}.txt";
        static readonly string fileType = "text/plain";
        static readonly string fileId = Guid.NewGuid().ToString();
        static readonly Uri url = new("http://localhost");

        public InputFileTests()
        {
            System.IO.File.Create(fileName).Close();
        }

        public void Dispose()
        {
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
        }

        [Test]
        public void ValidAndIsFileTest()
        {
            InputFile.FileStream stream = new();
            InputFile file = new() { File = stream };
            Assert.IsFalse(stream.Valid);
            Assert.IsFalse(file.IsFile);
            stream.Stream = fileStream;
            Assert.IsFalse(stream.Valid);
            Assert.IsFalse(file.IsFile);
            stream.Name = string.Empty;
            Assert.IsFalse(stream.Valid);
            Assert.IsFalse(file.IsFile);
            stream.Name = fileName;
            Assert.IsTrue(stream.Valid);
            Assert.IsTrue(file.IsFile);
            file.File = null;
            Assert.IsFalse(file.IsFile);
            stream.Stream = null;
            Assert.IsFalse(stream.Valid);
            Assert.IsFalse(file.IsFile);
        }

        [TestCase(100)]
        public void FileIdUnique(int count)
        {
            Assert.AreEqual(count, Enumerable.Range(0, count).Select(_ => new InputFile.FileStream().Id).Distinct().Count());
        }

        [Test]
        public void EnsureSinglePropertyIsSetTest()
        {
            InputFile.FileStream stream = new() { Stream = fileStream, Name = fileName };
            InputFile file = new();

            Assert.Throws<TelegramBotException>(() => file.EnsureSinglePropertyIsSet());
            file.File = stream;
            Assert.DoesNotThrow(() => file.EnsureSinglePropertyIsSet());
            file.FileId = fileId;
            Assert.Throws<TelegramBotException>(() => file.EnsureSinglePropertyIsSet());
            file.File = null;
            Assert.DoesNotThrow(() => file.EnsureSinglePropertyIsSet());
            file.Url = url;
            Assert.Throws<TelegramBotException>(() => file.EnsureSinglePropertyIsSet());
            file.FileId = null;
            Assert.DoesNotThrow(() => file.EnsureSinglePropertyIsSet());
            file.File = stream;
            Assert.Throws<TelegramBotException>(() => file.EnsureSinglePropertyIsSet());
            file.FileId = fileId;
            Assert.Throws<TelegramBotException>(() => file.EnsureSinglePropertyIsSet());
        }

        [Test]
        public void FromFileTest()
        {
            InputFile[] files = new InputFile[]
            {
                InputFile.FromFile(new FileInfo(fileName)),
                InputFile.FromFile(fileName),
                new FileInfo(fileName)
            };
            foreach (InputFile file in files)
            {
                Assert.AreEqual(fileName, file.File.Name);
                Assert.AreEqual(fileType, file.File.Type);
                Assert.NotNull(file.File.Stream);
                Assert.IsTrue(file.IsFile);
                Assert.IsTrue(file.File.Valid);
                Assert.AreEqual($"attach://{file.File.Id}", file.File.AttachValue);
                Assert.DoesNotThrow(() => file.EnsureSinglePropertyIsSet());
            }
        }

        class ExampleFileBase : FileBase { }

        [Test]
        public void FromFileIdTest()
        {
            Mock<IFile> fileMock = new();
            fileMock.SetupGet(f => f.Id).Returns(fileId);

            InputFile[] files = new InputFile[]
            {
                InputFile.FromFileId(fileId),
                fileId,
                InputFile.FromFileId(fileMock.Object),
                new ExampleFileBase { Id = fileId }
            };
            foreach (InputFile file in files)
            {
                Assert.AreEqual(fileId, file.FileId);
                Assert.DoesNotThrow(() => file.EnsureSinglePropertyIsSet());
            }
        }

        [Test]
        public void FromUrlTest()
        {
            InputFile[] files = new InputFile[]
            {
                InputFile.FromUrl(url),
                url
            };
            foreach (InputFile file in files)
            {
                Assert.AreEqual(url, file.Url);
                Assert.DoesNotThrow(() => file.EnsureSinglePropertyIsSet());
            }
        }

        [Test]
        public void JsonInputFileConverterReadThrowsNotSupportedExceptionTest()
        {
            Assert.Throws<NotSupportedException>(() => JsonSerializer.Deserialize("{}", typeof(InputFile)));
        }

        [Test]
        public void JsonInputFileConverterWriteTest()
        {
            InputFile.FileStream file = new() { Stream = new MemoryStream(), Name = fileName };
            Assert.AreEqual($"\"{file.AttachValue}\"", JsonSerializer.Serialize(new InputFile { File = file }));
            Assert.AreEqual($"\"{fileId}\"", JsonSerializer.Serialize(new InputFile { FileId = fileId }));
            Assert.AreEqual($"\"{url}\"", JsonSerializer.Serialize(new InputFile { Url = url }));
            Assert.Throws<TelegramBotException>(() => JsonSerializer.Serialize(new InputFile { FileId = fileId, Url = url }));
        }
    }
}
