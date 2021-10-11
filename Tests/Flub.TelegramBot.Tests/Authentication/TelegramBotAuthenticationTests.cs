using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Flub.TelegramBot.Authentication.Tests
{
    [ExcludeFromCodeCoverage]
    public class TelegramBotAuthenticationTests
    {
        static readonly string token = "123:abc";
        static readonly TimeSpan? timeSpan = TimeSpan.FromMinutes(5);
        static readonly string data = "data";
        static readonly string hash = "5E9B4265028DD9DEF0A30B5C1F2FEC25A2BA0F29F52C162CABAAE94DAE9CE5B0";
        static readonly string hashLowerCase = "5e9b4265028dd9def0a30b5c1f2fec25a2ba0f29f52c162cabaae94dae9ce5b0";

        Mock<IAuthenticationData> authDataMock;
        TelegramBot bot;

        [SetUp]
        public void SetUp()
        {
            bot = TelegramBot.Create(new TelegramBotOptions() { API = "http://localhost/", Token = token });

            authDataMock = new Mock<IAuthenticationData>();
            authDataMock.SetupGet(d => d.AuthenticationDate).Returns(() => DateTime.Now.Subtract(TimeSpan.FromMinutes(4)));
            authDataMock.SetupGet(d => d.AuthenticationFields).Returns(data);
            authDataMock.SetupGet(d => d.AuthenticationHash).Returns(hash);
        }

        [Test]
        public void ComputeHashTest()
        {
            Assert.AreEqual(hash, bot.ComputeHash(authDataMock.Object));
        }

        [Test]
        public void ComputeHashThrowsArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => bot.ComputeHash(null));
        }

        [Test]
        public void ValidateSuccessTest()
        {
            Assert.IsTrue(bot.Validate(authDataMock.Object));

            authDataMock.SetupGet(d => d.AuthenticationDate).Returns((DateTime?)null);
            Assert.IsTrue(bot.Validate(authDataMock.Object));
        }

        [Test]
        public void ValidateLowerCaseHashSuccessTest()
        {
            authDataMock.SetupGet(d => d.AuthenticationHash).Returns(hashLowerCase);

            Assert.IsTrue(bot.Validate(authDataMock.Object));
        }

        [Test]
        public void ValidateWithTimeSpanSuccess()
        {
            Assert.IsTrue(bot.Validate(authDataMock.Object, timeSpan));
        }

        [Test]
        public void ValidateFailTest()
        {
            TelegramBot otherBot = TelegramBot.Create(new TelegramBotOptions { API = "http://localhost", Token = "321:cba" });
            Assert.Throws<TelegramBotException>(() => otherBot.Validate(authDataMock.Object));

            authDataMock.SetupGet(d => d.AuthenticationFields).Returns(string.Empty);
            Assert.Throws<TelegramBotException>(() => bot.Validate(authDataMock.Object));
        }

        [Test]
        public void ValidateWithTimeSpanFail()
        {
            authDataMock.SetupGet(d => d.AuthenticationDate).Returns(() => DateTime.Now.Subtract(timeSpan.Value + TimeSpan.FromSeconds(2)));
            Assert.Throws<TelegramBotException>(() => bot.Validate(authDataMock.Object, timeSpan));

            authDataMock.SetupGet(d => d.AuthenticationDate).Returns((DateTime?)null);
            Assert.Throws<TelegramBotException>(() => bot.Validate(authDataMock.Object, timeSpan));
        }

        [Test]
        public void ValidateFailWithoutExceptionTest()
        {
            authDataMock.SetupGet(d => d.AuthenticationDate).Returns(() => DateTime.Now.Subtract(timeSpan.Value + TimeSpan.FromSeconds(2)));
            Assert.IsFalse(bot.Validate(authDataMock.Object, timeSpan, false));

            authDataMock.SetupGet(d => d.AuthenticationDate).Returns((DateTime?)null);
            Assert.IsFalse(bot.Validate(authDataMock.Object, timeSpan, false));

            TelegramBot otherBot = TelegramBot.Create(new TelegramBotOptions { API = "http://localhost", Token = "321:cba" });
            Assert.IsFalse(otherBot.Validate(authDataMock.Object, throwExceptionOnFailure: false));

            authDataMock.SetupGet(d => d.AuthenticationFields).Returns(string.Empty);
            Assert.IsFalse(bot.Validate(authDataMock.Object, throwExceptionOnFailure: false));
        }
    }
}
