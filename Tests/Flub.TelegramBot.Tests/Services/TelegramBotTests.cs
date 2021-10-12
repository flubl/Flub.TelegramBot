using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Services.Tests
{
    [ExcludeFromCodeCoverage]
    public class TelegramBotTests
    {
        public class Example { }

        class ExampleMethod : IMethod<string>
        {
            public string Name => exampleMethodName;
            public string NullValue => null;
            public Example Example => new();

            public IImmutableDictionary<string, object> GetProperties(JsonSerializerOptions options = null) => throw new NotImplementedException();
        }

        class ExampleWithFilesMethod : IMethod<string>, IFileContainer
        {
            public string Name => exampleWithFilesMethodName;

            public bool HasFiles => true;

            public IEnumerable<InputFile> Files
            {
                get
                {
                    yield return file1;
                    yield return file2;
                }
            }

            static IEnumerable<KeyValuePair<string, object>> Properties
            {
                get
                {
                    // string -> StringContent
                    yield return new KeyValuePair<string, object>(stringName, stringValue);
                    // InputFile -> StringContent
                    yield return new KeyValuePair<string, object>(file1Name, file1);
                    yield return new KeyValuePair<string, object>(file2Name, file2);
                    yield return new KeyValuePair<string, object>(uriName, uriValue);
                    // int -> JsonContent
                    yield return new KeyValuePair<string, object>(numberName, numberValue);
                    // others -> JsonContent
                    yield return new KeyValuePair<string, object>(exampleName, new Example());
                }
            }

            public IImmutableDictionary<string, object> GetProperties(JsonSerializerOptions options = null) => Properties.ToImmutableDictionary();
        }

        class ExampleJsonConverter : JsonConverter<Example>
        {
            public override Example Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
                JsonSerializer.Deserialize<Guid?>(ref reader) == exampleValue ? new Example() : null;

            public override void Write(Utf8JsonWriter writer, Example value, JsonSerializerOptions options) =>
                writer.WriteStringValue(exampleValue);
        }

        class ExampleTelegramBot : TelegramBot
        {
            public HttpClient Client => client;
            public string Token => token;
            public JsonSerializerOptions Options => options;
            public ILogger<TelegramBot> Logger => logger;

            public ExampleTelegramBot(HttpClient client, IOptions<TelegramBotOptions> botOptions, IOptions<JsonSerializerOptions> jsonOptions, ILogger<TelegramBot> logger)
                : base(client, botOptions, jsonOptions, logger) { }
        }

        class ExampleHttpMessageHandler : HttpMessageHandler
        {
            public Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> SendAndReceive { get; set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return SendAndReceive?.Invoke(request, cancellationToken) ?? throw new NotImplementedException();
            }
        }

        ExampleHttpMessageHandler handler;
        HttpClient httpClient;
        Mock<IOptions<TelegramBotOptions>> botOptionsMock;
        Mock<IOptions<JsonSerializerOptions>> jsonOptionsMock;
        Mock<ILogger<TelegramBot>> loggerMock;
        TelegramBot bot;
        const string api = "http://localhost/";
        const string token = "123:abc";
        static readonly TelegramBotOptions botOptions = new() { API = api, Token = token };
        static readonly TelegramBotOptions botOptionsNull = new() { API = null, Token = null };
        static readonly TelegramBotOptions botOptionsEmpty = new() { API = string.Empty, Token = string.Empty };
        static readonly TelegramBotOptions botOptionsFirstNull = new() { API = null, Token = token };
        static readonly TelegramBotOptions botOptionsSecondEmpty = new() { API = string.Empty, Token = token };
        static readonly TelegramBotOptions botOptionsSecondNull = new() { API = api, Token = null };
        static readonly TelegramBotOptions botOptionsFirstEmpty = new() { API = api, Token = string.Empty };
        static readonly JsonConverter converter = new ExampleJsonConverter();
        static readonly JsonSerializerOptions jsonOptions = new()
        {
            Converters = { converter },
            DefaultIgnoreCondition = JsonIgnoreCondition.Never
        };
        static readonly Uri baseAddress = new($"{api}bot{token}/");
        static readonly Guid exampleValue = Guid.NewGuid();
        static readonly string exampleMethodName = Guid.NewGuid().ToString();
        static readonly string exampleWithFilesMethodName = Guid.NewGuid().ToString();
        static readonly Uri exampleAddress = new($"{api}bot{token}/{exampleMethodName}");
        static readonly Uri exampleWithFilesAddress = new($"{api}bot{token}/{exampleWithFilesMethodName}");
        static readonly string exampleJson = $"{{\"Name\":\"{exampleMethodName}\",\"Example\":\"{exampleValue}\"}}";
        const string stringName = "string";
        const string file1Name = "file1";
        const string file2Name = "file2";
        const string numberName = "number";
        const string uriName = "uri";
        const string exampleName = "example";
        static readonly string stringValue = Guid.NewGuid().ToString();
        static readonly int numberValue = 0;
        static readonly Uri uriValue = new($"http://localhost/{Guid.NewGuid()}");
        static readonly string file1Content = Guid.NewGuid().ToString();
        static readonly string file2Content = Guid.NewGuid().ToString();
        static readonly string mimeType = "text/plain";
        static readonly InputFile file1 = new()
        {
            File = new InputFile.FileStream
            {
                Stream = new MemoryStream(Encoding.ASCII.GetBytes(file1Content)),
                Name = "file1.txt",
                Type = mimeType
            }
        };
        static readonly InputFile file2 = new()
        {
            File = new InputFile.FileStream
            {
                Stream = new MemoryStream(Encoding.ASCII.GetBytes(file2Content)),
                Name = "file1.txt",
                Type = null
            }
        };
        static readonly Response<string> response = new() { Ok = true, Result = Guid.NewGuid().ToString() };
        HttpResponseMessage httpResponse;

        [SetUp]
        public void SetUp()
        {
            handler = new();
            httpClient = new(handler);
            botOptionsMock = new();
            botOptionsMock.SetupGet(o => o.Value).Returns(botOptions);
            jsonOptionsMock = new();
            jsonOptionsMock.SetupGet(o => o.Value).Returns(jsonOptions);
            loggerMock = new();
            bot = new(httpClient, botOptionsMock.Object, jsonOptionsMock.Object, null);
            httpResponse = new(HttpStatusCode.OK) { Content = JsonContent.Create(response) };
        }

        [Test]
        public void ConstructorTest()
        {
            ExampleTelegramBot bot = new(httpClient, botOptionsMock.Object, jsonOptionsMock.Object, loggerMock.Object);

            Assert.AreEqual(baseAddress, bot.Client.BaseAddress);
            Assert.AreEqual(token, bot.Token);
            Assert.AreEqual(JsonIgnoreCondition.WhenWritingDefault, bot.Options.DefaultIgnoreCondition);
            Assert.Contains(converter, bot.Options.Converters.ToArray());
            Assert.NotNull(bot.Logger);
        }

        [Test]
        public void ConstructorJsonOptionsTest()
        {
            jsonOptionsMock.SetupGet(o => o.Value).Returns((JsonSerializerOptions)null);
            ExampleTelegramBot bot = new(httpClient, botOptionsMock.Object, jsonOptionsMock.Object, null);
            Assert.AreEqual(JsonIgnoreCondition.WhenWritingDefault, bot.Options.DefaultIgnoreCondition);
            bot = new(httpClient, botOptionsMock.Object, null, null);
            Assert.AreEqual(JsonIgnoreCondition.WhenWritingDefault, bot.Options.DefaultIgnoreCondition);
        }

        [Test]
        public void ConstructorThrowsArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new TelegramBot(null, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new TelegramBot(httpClient, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new TelegramBot(null, botOptionsMock.Object, null, null));
            botOptionsMock.SetupGet(o => o.Value).Returns((TelegramBotOptions)null);
            Assert.Throws<ArgumentNullException>(() => new TelegramBot(httpClient, botOptionsMock.Object, null, null));
        }

        [Test]
        public void ConstructorThrowsArgumentExceptionTest()
        {
            botOptionsMock.SetupGet(o => o.Value).Returns(botOptionsEmpty);
            Assert.Throws<ArgumentException>(() => new TelegramBot(null, botOptionsMock.Object, null, null));
            botOptionsMock.SetupGet(o => o.Value).Returns(botOptionsNull);
            Assert.Throws<ArgumentException>(() => new TelegramBot(null, botOptionsMock.Object, null, null));
            botOptionsMock.SetupGet(o => o.Value).Returns(botOptionsFirstEmpty);
            Assert.Throws<ArgumentException>(() => new TelegramBot(null, botOptionsMock.Object, null, null));
            botOptionsMock.SetupGet(o => o.Value).Returns(botOptionsFirstNull);
            Assert.Throws<ArgumentException>(() => new TelegramBot(null, botOptionsMock.Object, null, null));
            botOptionsMock.SetupGet(o => o.Value).Returns(botOptionsSecondEmpty);
            Assert.Throws<ArgumentException>(() => new TelegramBot(null, botOptionsMock.Object, null, null));
            botOptionsMock.SetupGet(o => o.Value).Returns(botOptionsSecondNull);
            Assert.Throws<ArgumentException>(() => new TelegramBot(null, botOptionsMock.Object, null, null));
        }

        [Test]
        public void SendThrowsArgumentNullExceptionTest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await bot.Send<string>(null));
        }

        [Test]
        public async Task SendAsJsonTest()
        {
            bool executed = false;
            handler.SendAndReceive = async (request, cancellationToken) =>
            {
                Assert.AreEqual(HttpMethod.Post, request.Method);
                Assert.AreEqual(exampleAddress, request.RequestUri);

                if (request.Content is JsonContent content)
                    Assert.AreEqual(exampleJson, await content.ReadAsStringAsync(cancellationToken));
                else throw new Exception();

                executed = true;
                return httpResponse;
            };

            Assert.AreEqual(response.Result, await bot.Send(new ExampleMethod()));
            Assert.IsTrue(executed);
        }

        [Test]
        public async Task SendReceiveObjectTest()
        {
            async Task Run<T>(T value, Action<T> check)
            {
                bool executed = false;
                Mock<IMethod<T>> methodMock = new();
                methodMock.SetupGet(m => m.Name).Returns(string.Empty);
                handler.SendAndReceive = (_, _) =>
                {
                    executed = true;
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = JsonContent.Create(new Response<T> { Ok = true, Result = value }, options: jsonOptions)
                    });
                };
                check(await bot.Send(methodMock.Object));
                Assert.IsTrue(executed);
            }

            await Run(new Example(), e => Assert.IsNotNull(e));
            await Run(Enumerable.Range(0, 3).Select(_ => new Example()).ToArray(), l => Assert.IsEmpty(l.Where(e => e is null)));
        }

        [Test]
        public async Task SendAsMultipartTest()
        {
            bool executed = false;
            handler.SendAndReceive = async (request, cancellationToken) =>
            {
                Assert.AreEqual(HttpMethod.Post, request.Method);
                Assert.AreEqual(exampleWithFilesAddress, request.RequestUri);

                if (request.Content is MultipartFormDataContent contents)
                {
                    foreach (HttpContent content in contents)
                    {
                        string name = content?.Headers?.ContentDisposition?.Name;
                        string value = await content.ReadAsStringAsync(cancellationToken);
                        switch (content?.Headers?.ContentType?.MediaType)
                        {
                            case "text/plain":
                                switch (name)
                                {
                                    case stringName:
                                        Assert.AreEqual(stringValue, value);
                                        break;
                                    case file1Name:
                                        Assert.AreEqual(file1.File.AttachValue, value);
                                        break;
                                    case file2Name:
                                        Assert.AreEqual(file2.File.AttachValue, value);
                                        break;
                                    case uriName:
                                        Assert.AreEqual(uriValue.ToString(), value);
                                        break;
                                    default:
                                        InputFile file = null;
                                        string fileContent = null;
                                        if (name == file1.File.Id.ToString())
                                        {
                                            file = file1;
                                            fileContent = file1Content;
                                        }
                                        else if (name == file2.File.Id.ToString())
                                        {
                                            file = file2;
                                            fileContent = file2Content;
                                        }
                                        else throw new Exception();
                                        Assert.AreEqual(file.File.Name, content.Headers.ContentDisposition.FileName);
                                        Assert.AreEqual(fileContent, value);
                                        break;
                                }
                                break;
                            case "application/json":
                                if (content is JsonContent json)
                                {
                                    switch (name)
                                    {
                                        case numberName:
                                            Assert.AreEqual($"{numberValue}", value);
                                            break;
                                        case exampleName:
                                            Assert.AreEqual($"\"{exampleValue}\"", value);
                                            break;
                                        default: throw new Exception();
                                    }
                                }
                                else throw new Exception();
                                break;
                            default: throw new Exception();
                        }
                    }
                }
                else throw new Exception();

                executed = true;
                return httpResponse;
            };

            Assert.AreEqual(response.Result, await bot.Send(new ExampleWithFilesMethod()));
            Assert.IsTrue(executed);
        }

        [Test]
        public void SendThrowsHttpRequestExceptionTest()
        {
            handler.SendAndReceive = (_, _) => throw new HttpRequestException();
            Mock<IMethod<string>> methodMock = new();
            methodMock.SetupGet(m => m.Name).Returns(string.Empty);

            Assert.ThrowsAsync<HttpRequestException>(async () => await bot.Send(methodMock.Object));
        }

        [Test]
        public void SendThrowsTelegramBotRequestExceptionTest()
        {
            bool executed = false;
            Mock<IMethod<string>> methodMock = new();
            methodMock.SetupGet(m => m.Name).Returns(string.Empty);
            IMethod<string> method = methodMock.Object;
            handler.SendAndReceive = (_, _) =>
            {
                executed = true;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = JsonContent.Create(response) });
            };

            Assert.ThrowsAsync<TelegramBotRequestException>(async () =>
            {
                try { await bot.Send(method); }
                catch (TelegramBotRequestException exc)
                {
                    Assert.AreSame(method, exc.Method);
                    if (exc.Response is Response<string> r)
                        Assert.AreEqual(response.Result, r.Result);
                    else
                        throw new Exception();
                    throw;
                }
            });
            Assert.IsTrue(executed);
        }
    }
}
