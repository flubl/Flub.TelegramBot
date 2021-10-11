using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace Flub.TelegramBot.Options.Tests
{
    [ExcludeFromCodeCoverage]
    public class TelegramBotOptionsTests
    {
        [Test]
        public void ValidationSucceededTest()
        {
            TelegramBotOptions options = new()
            {
                API = "http://localhost",
                Token = "123:bot"
            };
            ValidateOptionsResult result = new DataAnnotationValidateOptions<TelegramBotOptions>(string.Empty).Validate(string.Empty, options);
            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public void ValidationFailedTest()
        {
            TelegramBotOptions options = new()
            {
                API = Guid.NewGuid().ToString(),
                Token = Guid.NewGuid().ToString()
            };
            ValidateOptionsResult result = new DataAnnotationValidateOptions<TelegramBotOptions>(string.Empty).Validate(string.Empty, options);
            Assert.AreEqual(2, result.Failures.Count());
            foreach (string failure in result.Failures)
                Assert.IsTrue(Regex.IsMatch(failure, "not.*?valid"));
            Assert.IsTrue(result.Failed);
        }

        [Test]
        public void ValidationFailedRequiredTest()
        {
            TelegramBotOptions[] options = new[]
            {
                new TelegramBotOptions()
                {
                    API = null,
                    Token = null
                },
                new TelegramBotOptions()
                {
                    API = string.Empty,
                    Token = string.Empty
                }
            };
            foreach (TelegramBotOptions option in options)
            {
                ValidateOptionsResult result = new DataAnnotationValidateOptions<TelegramBotOptions>(string.Empty).Validate(string.Empty, option);
                Assert.AreEqual(2, result.Failures.Count());
                foreach (string failure in result.Failures)
                    Assert.IsTrue(Regex.IsMatch(failure, "required"));
                Assert.IsTrue(result.Failed);
            }
        }
    }
}
