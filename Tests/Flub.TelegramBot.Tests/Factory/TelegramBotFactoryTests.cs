using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Flub.TelegramBot.Factory.Tests
{
    [ExcludeFromCodeCoverage]
    public class TelegramBotFactoryTests
    {
        class ExampleTelegramBot : TelegramBot
        {
            public ExampleTelegramBot(HttpClient client, IOptions<TelegramBotOptions> botOptions, IOptions<JsonSerializerOptions> jsonOptions, ILogger<ExampleTelegramBot> logger)
                : base(client, botOptions, jsonOptions, logger)
            {

            }
        }

        const string api = "http://localhost";
        const string token = "123:abc";
        static readonly string optionsJson =
            $"{{\"{TelegramBotOptions.Position}\":{{\"{nameof(TelegramBotOptions.API)}\":\"{api}\",\"{nameof(TelegramBotOptions.Token)}\":\"{token}\"}}}}";
        static readonly string optionsJsonEmpty =
            $"{{\"{TelegramBotOptions.Position}\":{{\"{nameof(TelegramBotOptions.API)}\":\"\",\"{nameof(TelegramBotOptions.Token)}\":\"\"}}}}";

        [Test]
        public void CreateByBotOptionsTest()
        {
            TelegramBotOptions botOptions = new() { API = api, Token = token };
            TelegramBotOptions botOptionsNull = null;
            TelegramBotOptions botOptionsNullValues = new();
            TelegramBotOptions botOptionsEmpty = new() { API = string.Empty, Token = string.Empty };

            Assert.AreEqual(typeof(TelegramBot), TelegramBot.Create(botOptions)?.GetType());
            Assert.AreEqual(typeof(ExampleTelegramBot), TelegramBot.Create<ExampleTelegramBot>(botOptions)?.GetType());
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create(botOptionsNull));
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create<ExampleTelegramBot>(botOptionsNull));
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create(botOptionsNullValues));
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create<ExampleTelegramBot>(botOptionsNullValues));
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create(botOptionsEmpty));
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create<ExampleTelegramBot>(botOptionsEmpty));

            void configureByService(IConfigurationBuilder _, IServiceCollection services) =>
                services.AddSingleton(Microsoft.Extensions.Options.Options.Create(botOptions));
            void configureByServiceInvalid(IConfigurationBuilder _, IServiceCollection services) =>
                services.AddSingleton(Microsoft.Extensions.Options.Options.Create(botOptionsEmpty));

            static void configureByConfig(IConfigurationBuilder config, IServiceCollection _) =>
                config.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(optionsJson)));
            static void configureByConfigInvalid(IConfigurationBuilder config, IServiceCollection _) =>
                config.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(optionsJsonEmpty)));

            Assert.AreEqual(typeof(TelegramBot), TelegramBot.Create(configureByService)?.GetType());
            Assert.AreEqual(typeof(ExampleTelegramBot), TelegramBot.Create<ExampleTelegramBot>(configureByService)?.GetType());
            Assert.Throws<ArgumentException>(() => TelegramBot.Create(configureByServiceInvalid));
            Assert.Throws<ArgumentException>(() => TelegramBot.Create<ExampleTelegramBot>(configureByServiceInvalid));
            Assert.AreEqual(typeof(TelegramBot), TelegramBot.Create(configureByConfig)?.GetType());
            Assert.AreEqual(typeof(ExampleTelegramBot), TelegramBot.Create<ExampleTelegramBot>(configureByConfig)?.GetType());
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create(configureByConfigInvalid));
            Assert.Throws<OptionsValidationException>(() => TelegramBot.Create<ExampleTelegramBot>(configureByConfigInvalid));

            Assert.AreEqual(typeof(TelegramBot), TelegramBot.Create(botOptions, configureByService)?.GetType());
            Assert.AreEqual(typeof(ExampleTelegramBot), TelegramBot.Create<ExampleTelegramBot>(botOptions, configureByService)?.GetType());
            Assert.Throws<ArgumentException>(() => TelegramBot.Create(botOptions, configureByServiceInvalid));
            Assert.Throws<ArgumentException>(() => TelegramBot.Create<ExampleTelegramBot>(botOptions, configureByServiceInvalid));
            Assert.AreEqual(typeof(TelegramBot), TelegramBot.Create(botOptions, configureByConfig)?.GetType());
            Assert.AreEqual(typeof(ExampleTelegramBot), TelegramBot.Create<ExampleTelegramBot>(botOptions, configureByConfig)?.GetType());
            Assert.AreEqual(typeof(TelegramBot), TelegramBot.Create(botOptions, configureByConfigInvalid)?.GetType());
            Assert.AreEqual(typeof(ExampleTelegramBot), TelegramBot.Create<ExampleTelegramBot>(botOptions, configureByConfigInvalid)?.GetType());
        }
    }
}
