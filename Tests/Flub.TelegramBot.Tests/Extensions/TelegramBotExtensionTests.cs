using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Extensions.Tests
{
    [ExcludeFromCodeCoverage]
    public class TelegramBotExtensionTests
    {
        class ExampleTelegramBot : TelegramBot { public ExampleTelegramBot(HttpClient client, IOptions<TelegramBotOptions> botOptions) : base(client, botOptions, null, null) { } }

        IServiceCollection services;

        [SetUp]
        public void SetUp()
        {
            services = new ServiceCollection();
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);
            writer.WriteStartObject();
            writer.WritePropertyName(TelegramBotOptions.Position);
            JsonSerializer.Serialize(writer, new TelegramBotOptions { API = "http://localhost", Token = "123:abc" });
            writer.WriteEndObject();
            writer.Flush();
            stream.Position = 0;
            services.AddSingleton<IConfiguration>(new ConfigurationBuilder().AddJsonStream(stream).Build());
        }

        [Test]
        public void AddTelegramBotTest()
        {
            var result = services.AddTelegramBot();
            ServiceProvider provider = services.BuildServiceProvider();

            Assert.AreSame(services, result);
            Assert.IsNotNull(provider.GetRequiredService<HttpClient>());
            Assert.IsNotNull(provider.GetRequiredService<IOptions<TelegramBotOptions>>());
            Assert.AreEqual(typeof(TelegramBot), provider.GetRequiredService<TelegramBot>()?.GetType());
        }

        [Test]
        public void AddTelegramBotGenericTest()
        {
            var result = services.AddTelegramBot<ExampleTelegramBot>();
            ServiceProvider provider = services.BuildServiceProvider();

            Assert.AreSame(services, result);
            Assert.IsNotNull(provider.GetRequiredService<HttpClient>());
            Assert.IsNotNull(provider.GetRequiredService<IOptions<TelegramBotOptions>>());
            Assert.AreEqual(typeof(ExampleTelegramBot), provider.GetRequiredService<ExampleTelegramBot>()?.GetType());
        }

        class Example
        {
            [JsonIgnore]
            public int Value { get; }
            public int ValueWithoutAttribute { get; }
        }

        [Test]
        public void GetJsonIgnoreConditionTest()
        {
            MemberInfo member = typeof(Example).GetProperty(nameof(Example.Value));
            MemberInfo memberWithoutAttribute = typeof(Example).GetProperty(nameof(Example.ValueWithoutAttribute));

            Assert.AreEqual(JsonIgnoreCondition.Always, member.GetJsonIgnoreCondition());
            Assert.AreEqual(JsonIgnoreCondition.Never, memberWithoutAttribute.GetJsonIgnoreCondition());

            JsonSerializerOptions options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };

            Assert.AreEqual(JsonIgnoreCondition.Always, member.GetJsonIgnoreCondition(options));
            Assert.AreEqual(JsonIgnoreCondition.WhenWritingDefault, memberWithoutAttribute.GetJsonIgnoreCondition(options));
        }

        [Test]
        public void ShouldNotIgnoreJsonIgnoreConditionTest()
        {
            int value = 1;
            int valueDefault = default;
            int? nullableValue = 1;
            int? nullableValueDefault = default;
            int? nullableValueNull = null;
            Example example = new();
            Example exampleNull = null;
            object[] items = new object[]
            {
                value, valueDefault,
                nullableValue, nullableValueDefault, nullableValueNull,
                example, exampleNull
            };

            foreach (object item in items)
            {
                Assert.IsTrue(JsonIgnoreCondition.Never.ShouldNotIgnore(item));
                Assert.IsFalse(JsonIgnoreCondition.Always.ShouldNotIgnore(item));
            }

            Assert.IsTrue(JsonIgnoreCondition.WhenWritingDefault.ShouldNotIgnore(value));
            Assert.IsTrue(JsonIgnoreCondition.WhenWritingDefault.ShouldNotIgnore(valueDefault));
            Assert.IsTrue(JsonIgnoreCondition.WhenWritingDefault.ShouldNotIgnore(nullableValue));
            Assert.IsFalse(JsonIgnoreCondition.WhenWritingDefault.ShouldNotIgnore(nullableValueDefault));
            Assert.IsFalse(JsonIgnoreCondition.WhenWritingDefault.ShouldNotIgnore(nullableValueNull));
            Assert.IsTrue(JsonIgnoreCondition.WhenWritingDefault.ShouldNotIgnore(example));
            Assert.IsFalse(JsonIgnoreCondition.WhenWritingDefault.ShouldNotIgnore(exampleNull));

            Assert.IsTrue(JsonIgnoreCondition.WhenWritingNull.ShouldNotIgnore(value));
            Assert.IsTrue(JsonIgnoreCondition.WhenWritingNull.ShouldNotIgnore(valueDefault));
            Assert.IsTrue(JsonIgnoreCondition.WhenWritingNull.ShouldNotIgnore(nullableValue));
            Assert.IsFalse(JsonIgnoreCondition.WhenWritingNull.ShouldNotIgnore(nullableValueDefault));
            Assert.IsFalse(JsonIgnoreCondition.WhenWritingNull.ShouldNotIgnore(nullableValueNull));
            Assert.IsTrue(JsonIgnoreCondition.WhenWritingNull.ShouldNotIgnore(example));
            Assert.IsFalse(JsonIgnoreCondition.WhenWritingNull.ShouldNotIgnore(exampleNull));
        }

        [Test]
        public void ShouldNotIgnoreMemberInfoTest()
        {
            MemberInfo member = typeof(Example).GetProperty(nameof(Example.Value));
            MemberInfo memberWithoutAttribute = typeof(Example).GetProperty(nameof(Example.ValueWithoutAttribute));
            JsonSerializerOptions options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };

            int value = 1;
            int valueDefault = default;
            int? nullableValue = 1;
            int? nullableValueDefault = default;
            int? nullableValueNull = null;
            Example example = new();
            Example exampleNull = null;
            object[] items = new object[]
            {
                value, valueDefault,
                nullableValue, nullableValueDefault, nullableValueNull,
                example, exampleNull
            };

            foreach (object item in items)
            {
                Assert.IsFalse(member.SouldNotBeIgnored(item));
                Assert.IsFalse(member.SouldNotBeIgnored(item, options));
                Assert.IsTrue(memberWithoutAttribute.SouldNotBeIgnored(item));
            }

            Assert.IsTrue(memberWithoutAttribute.SouldNotBeIgnored(value, options));
            Assert.IsTrue(memberWithoutAttribute.SouldNotBeIgnored(valueDefault, options));
            Assert.IsTrue(memberWithoutAttribute.SouldNotBeIgnored(nullableValue, options));
            Assert.IsFalse(memberWithoutAttribute.SouldNotBeIgnored(nullableValueDefault, options));
            Assert.IsFalse(memberWithoutAttribute.SouldNotBeIgnored(nullableValueNull, options));
            Assert.IsTrue(memberWithoutAttribute.SouldNotBeIgnored(example, options));
            Assert.IsFalse(memberWithoutAttribute.SouldNotBeIgnored(exampleNull, options));
        }
    }
}
