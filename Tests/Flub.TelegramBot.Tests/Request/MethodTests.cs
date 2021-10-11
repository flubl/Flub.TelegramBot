using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace Flub.TelegramBot.Request.Tests
{
    [ExcludeFromCodeCoverage]
    public class MethodTests
    {
        class Example { }

        static readonly string method = Guid.NewGuid().ToString();
        static readonly Example value = new();
        static readonly Example valueNull = null;
        static readonly int number = 1;
        static readonly int numberDefault = default;
        static readonly int? nullableNumber = 1;
        static readonly int? nullableNumberDefault = default;
        static readonly int? nullableNumberNull = null;

        class ExampleMethod : Method<string>
        {
            public Example Value => value;
            public Example ValueNull => valueNull;
            public int Number => number;
            public int NumberDefault => numberDefault;
            public int? NullableNumber => nullableNumber;
            public int? NullableNumberDefault => nullableNumberDefault;
            public int? NullableNumberNull => nullableNumberNull;

            [JsonIgnore]
            public Example ValueIgnored => value;
            [JsonIgnore]
            public Example ValueNullIgnored => valueNull;
            [JsonIgnore]
            public int NumberIgnored => number;
            [JsonIgnore]
            public int NumberDefaultIgnored => numberDefault;
            [JsonIgnore]
            public int? NullableNumberIgnored => nullableNumber;
            [JsonIgnore]
            public int? NullableNumberDefaultIgnored => nullableNumberDefault;
            [JsonIgnore]
            public int? NullableNumberNullIgnored => nullableNumberNull;

            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public Example ValueIgnoredNever => value;
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public Example ValueNullIgnoredNever => valueNull;
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public int NumberIgnoredNever => number;
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public int NumberDefaultIgnoredNever => numberDefault;
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public int? NullableNumberIgnoredNever => nullableNumber;
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public int? NullableNumberDefaultIgnoredNever => nullableNumberDefault;
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public int? NullableNumberNullIgnoredNever => nullableNumberNull;

            public ExampleMethod() : base(method) { }
        }

        static readonly KeyValuePair<string, object>[] propertiesIgnoredNever = new KeyValuePair<string, object>[]
        {
            new(nameof(ExampleMethod.ValueIgnoredNever), value),
            new(nameof(ExampleMethod.ValueNullIgnoredNever), valueNull),
            new(nameof(ExampleMethod.NumberIgnoredNever), number),
            new(nameof(ExampleMethod.NumberDefaultIgnoredNever), numberDefault),
            new(nameof(ExampleMethod.NullableNumberIgnoredNever), nullableNumber),
            new(nameof(ExampleMethod.NullableNumberDefaultIgnoredNever), nullableNumberDefault),
            new(nameof(ExampleMethod.NullableNumberNullIgnoredNever), nullableNumberNull)
        };
        static readonly KeyValuePair<string, object>[] expectedProperties = new KeyValuePair<string, object>[]
        {
            new("method", method),
            new(nameof(ExampleMethod.Value), value),
            new(nameof(ExampleMethod.ValueNull), valueNull),
            new(nameof(ExampleMethod.Number), number),
            new(nameof(ExampleMethod.NumberDefault), numberDefault),
            new(nameof(ExampleMethod.NullableNumber), nullableNumber),
            new(nameof(ExampleMethod.NullableNumberDefault), nullableNumberDefault),
            new(nameof(ExampleMethod.NullableNumberNull), nullableNumberNull),
        }.Concat(propertiesIgnoredNever).ToArray();
        static readonly KeyValuePair<string, object>[] expectedPropertiesWithOptions = new KeyValuePair<string, object>[]
        {
            new("method", method),
            new(nameof(ExampleMethod.Value), value),
            new(nameof(ExampleMethod.Number), number),
            new(nameof(ExampleMethod.NumberDefault), numberDefault),
            new(nameof(ExampleMethod.NullableNumber), nullableNumber),
        }.Concat(propertiesIgnoredNever).ToArray();

        [Test]
        public void GetPropertiesTest()
        {
            static bool HasMissing<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> expected, IEnumerable<KeyValuePair<TKey, TValue>> actual) =>
                expected.GroupJoin(actual, e => e.Key, a => a.Key, (e, a) => Equals(e.Value, a.Single().Value)).Any(i => !i);

            Assert.IsFalse(HasMissing(expectedProperties, new ExampleMethod().GetProperties()));
            Assert.IsFalse(HasMissing(expectedPropertiesWithOptions, new ExampleMethod().GetProperties(new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault })));
        }

        class ExampleMethodUpload : MethodUpload<string>
        {
            protected override IEnumerable<InputFile> Files
            {
                get
                {
                    yield return file;
                    yield return fileNull;
                    yield return fileNotFile;
                }
            }

            public ExampleMethodUpload() : base(method) { }
        }

        class ExampleMethodUploadNoFiles : MethodUpload<string>
        {
            protected override IEnumerable<InputFile> Files
            {
                get
                {
                    yield return fileNull;
                    yield return fileNotFile;
                }
            }

            public ExampleMethodUploadNoFiles() : base(method) { }
        }

        class ExampleMethodUploadNull : MethodUpload<string>
        {
            protected override IEnumerable<InputFile> Files => null;

            public ExampleMethodUploadNull() : base(method) { }
        }

        class ExampleMethodUploadEmpty : MethodUpload<string>
        {
            protected override IEnumerable<InputFile> Files => Enumerable.Empty<InputFile>();

            public ExampleMethodUploadEmpty() : base(method) { }
        }

        static readonly string fileName = $"{Guid.NewGuid()}.txt";
        static readonly Stream fileStream = new MemoryStream();
        static readonly InputFile file = new() { File = new() { Name = fileName, Stream = fileStream } };
        static readonly InputFile fileNull = null;
        static readonly InputFile fileNotFile = new();

        [Test]
        public void IFileContainerInterfaceTest()
        {
            IFileContainer container = new ExampleMethodUpload();
            Assert.IsTrue(container.HasFiles);
            Assert.AreSame(file, container.Files.Single());
        }

        [Test]
        public void IFileContainerInterfaceNoFilesTest()
        {
            IFileContainer container = new ExampleMethodUploadNoFiles();
            Assert.IsFalse(container.HasFiles);
            Assert.IsEmpty(container.Files);
        }

        [Test]
        public void IFileContainerInterfaceNullTest()
        {
            IFileContainer container = new ExampleMethodUploadNull();
            Assert.IsFalse(container.HasFiles);
            Assert.IsNull(container.Files);
        }

        [Test]
        public void IFileContainerInterfaceEmptyTest()
        {
            IFileContainer container = new ExampleMethodUploadEmpty();
            Assert.IsFalse(container.HasFiles);
            Assert.IsEmpty(container.Files);
        }
    }
}
