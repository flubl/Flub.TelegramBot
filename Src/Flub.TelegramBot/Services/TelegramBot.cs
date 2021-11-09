using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Represents a bot to interact with the Telegram Bot API.
    /// </summary>
    public partial class TelegramBot
    {
        /// <summary>
        /// The implemented <see href="https://core.telegram.org/bots/api#recent-changes">Telegram Bot API Version</see>.
        /// </summary>
        public const string TELEGRAM_BOT_API_VERSION = "5.4";

        /// <summary>
        /// The <see cref="HttpClient"/> to be used for http requests.
        /// </summary>
        protected readonly HttpClient client;
        /// <summary>
        /// The bot token.
        /// </summary>
        protected readonly string token;
        /// <summary>
        /// The <see cref="JsonSerializerOptions"/> to be configured.
        /// </summary>
        protected readonly JsonSerializerOptions options;
        /// <summary>
        /// The <see cref="ILogger{TelegramBot}"/> to be used.
        /// </summary>
        protected readonly ILogger<TelegramBot> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramBot"/> class with the specified http client, bot options, json options and logger.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to be used for http requests.</param>
        /// <param name="botOptions">The <see cref="TelegramBotOptions"/> to be configured.</param>
        /// <param name="jsonOptions">The <see cref="JsonSerializerOptions"/> to be configured.</param>
        /// <param name="logger">The <see cref="ILogger{TelegramBot}"/> to be used.</param>
        public TelegramBot(HttpClient client, IOptions<TelegramBotOptions> botOptions, IOptions<JsonSerializerOptions> jsonOptions, ILogger<TelegramBot> logger)
        {
            TelegramBotOptions config = botOptions?.Value ?? throw new ArgumentNullException(nameof(botOptions));
            if (string.IsNullOrEmpty(botOptions?.Value?.API) || string.IsNullOrEmpty(botOptions?.Value?.Token))
                throw new ArgumentException("One or more option values are not set.", nameof(botOptions));
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.client.BaseAddress = new($"{config.API.TrimEnd('/')}/bot{token = config.Token}/");
            options = jsonOptions?.Value is JsonSerializerOptions value ? new(value) : new();
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            this.logger = logger;
            this.logger?.LogInformation($"{GetType()} created with Telegram Bot API {TELEGRAM_BOT_API_VERSION}");
        }

        /// <summary>
        /// Makes a request with the specified method.
        /// </summary>
        /// <typeparam name="TResult">Return type of the request.</typeparam>
        /// <param name="method">The method to be requested.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>Returns the result of the request on success.</returns>
        public async Task<TResult> Send<TResult>(IMethod<TResult> method, CancellationToken cancellationToken = default)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));
            Response<TResult> response = null;
            try
            {
                using HttpRequestMessage request = new(HttpMethod.Post, method.Name);
                if (method is IFileContainer container && container.HasFiles)
                {
                    MultipartFormDataContent contents = new();
                    foreach (InputFile input in container.Files.Where(i => i?.IsFile ?? false))
                        contents.Add(
                            new StreamContent(input.File.Stream)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue(input.File.Type ?? MimeTypes.GetMimeType(input.File.Name)) }
                            },
                            input.File.Id.ToString(),
                            input.File.Name);
                    foreach ((string name, HttpContent value) in method.GetProperties()
                        .Where(i => i.Value is not null)
                        .ToDictionary(i => i.Key, i => (HttpContent)(
                            i.Value is string s ? new StringContent(s) :
                            i.Value is InputFile input ? new StringContent(input.File.AttachValue) :
                            i.Value is Uri uri ? new StringContent(uri.ToString()) :
                            JsonContent.Create(i.Value, i.Value.GetType(), options: options))))
                        contents.Add(value, name);
                    request.Content = contents;
                }
                else
                    request.Content = JsonContent.Create(method, method.GetType(), options: options);
                logger?.LogInformation($"Sending Request: {method.Name}, {request.Method}, {request.Content.Headers.ContentType}");
                using HttpResponseMessage message = await client.SendAsync(request, cancellationToken);
                logger?.LogInformation($"Response Received: {method.Name}, {(int)message.StatusCode} {message.StatusCode}");
                response = await message.Content.ReadFromJsonAsync<Response<TResult>>(options, cancellationToken);
                message.EnsureSuccessStatusCode();
                return response.Result;
            }
            catch (HttpRequestException exc)
            {
                logger?.LogError(exc, $"Request Failed: {method.Name}, {response?.Description}");
                if (response != null)
                    throw new TelegramBotRequestException(method, response, "Request of method was not successful.", exc);
                throw;
            }
        }
    }
}
