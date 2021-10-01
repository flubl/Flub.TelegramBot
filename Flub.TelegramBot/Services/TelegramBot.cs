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
        protected readonly HttpClient client;
        protected readonly string token;
        protected readonly JsonSerializerOptions options;
        protected readonly ILogger<TelegramBot> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramBot"/> class with the specified http client, bot options, json options and logger.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> to be used.</param>
        /// <param name="botOptions">The <see cref="TelegramBotOptions"/> to be configured.</param>
        /// <param name="jsonOptions">The <see cref="JsonSerializerOptions"/> to be configured.</param>
        /// <param name="logger">The <see cref="ILogger{TelegramBot}"/> to be used.</param>
        public TelegramBot(HttpClient client, IOptions<TelegramBotOptions> botOptions, IOptions<JsonSerializerOptions> jsonOptions, ILogger<TelegramBot> logger)
        {
            if (client is null)
                throw new ArgumentNullException(nameof(client));
            if (botOptions is null)
                throw new ArgumentNullException(nameof(botOptions));
            if (jsonOptions is null)
                throw new ArgumentNullException(nameof(jsonOptions));
            TelegramBotOptions config = botOptions.Value;
            this.client = client;
            this.client.BaseAddress = new Uri($"{config.API.TrimEnd('/')}/bot{token = config.Token}/");
            options = new JsonSerializerOptions(jsonOptions.Value) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
            this.logger = logger;
        }

        /// <summary>
        /// Makes a request with the specified method.
        /// </summary>
        /// <typeparam name="T">Return type of the request.</typeparam>
        /// <param name="method">The method to be requested.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>Returns the result of the request on success.</returns>
        public async Task<T> Send<T>(Method<T> method, CancellationToken cancellationToken = default) where T : class
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));
            Response<T> response = null;
            try
            {
                using HttpRequestMessage request = new(HttpMethod.Post, method.Name);
                if (method.HasFiles())
                {
                    MultipartFormDataContent content = new();
                    foreach ((string name, object value) in method.GetProperties().Where(i => i.Value is not null))
                    {
                        if (value is InputFile input)
                        {
                            if (input.IsFile)
                            {
                                StreamContent stream = new(input.File.Stream);
                                stream.Headers.ContentType = new MediaTypeHeaderValue(input.File.Type ?? MimeTypes.GetMimeType(input.File.Name));
                                content.Add(stream, name, input.File.Name);
                            }
                        }
                        else if (value is string s)
                        {
                            StringContent stringContent = new(s);
                            content.Add(stringContent, name);
                        }
                        else
                        {
                            JsonContent jsonContent = JsonContent.Create(value, value.GetType(), options: options);
                            content.Add(jsonContent, name);
                        }
                    }
                    request.Content = content;
                }
                else
                    request.Content = JsonContent.Create(method, method.GetType(), options: options);
                using HttpResponseMessage message = await client.SendAsync(request, cancellationToken);
                response = await message.Content.ReadFromJsonAsync<Response<T>>(options, cancellationToken);
                message.EnsureSuccessStatusCode();
                return response.Result;
            }
            catch (HttpRequestException exc)
            {
                if (response != null)
                    throw new TelegramBotRequestException(method, response, "Request of method was not successful.", exc);
                throw;
            }
        }
    }
}
