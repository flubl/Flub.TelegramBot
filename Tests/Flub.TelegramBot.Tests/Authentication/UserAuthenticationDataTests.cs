using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Flub.TelegramBot.Authentication.Tests
{
    [ExcludeFromCodeCoverage]
    public class UserAuthenticationDataTests
    {
        static readonly DateTime? dateTime = new(2021, 10, 07, 11, 22, 33, DateTimeKind.Local);
        static readonly long? dateTimeValue = new DateTimeOffset(dateTime.Value).ToUnixTimeSeconds();
        static readonly string firstName = Guid.NewGuid().ToString();
        static readonly long? userId = 1234;
        static readonly string lastName = Guid.NewGuid().ToString();
        static readonly string username = Guid.NewGuid().ToString();
        static readonly Uri photoUrl = new("http://localhost/");
        static readonly string hash = Guid.NewGuid().ToString();
        static readonly UserAuthenticationData data = new()
        {
            AuthenticationDateValue = dateTimeValue,
            FirstName = firstName,
            UserId = userId,
            LastName = lastName,
            PhotoUrl = photoUrl,
            Username = username,
            AuthenticationHash = hash
        };
        static readonly string authenticationFields =
              $"auth_date={dateTimeValue}\n"
            + $"first_name={firstName}\n"
            + $"id={userId}\n"
            + $"last_name={lastName}\n"
            + $"photo_url={photoUrl}\n"
            + $"username={username}";

        [Test]
        public void AuthenticationFieldsTest()
        {
            Assert.AreEqual(authenticationFields, data.AuthenticationFields);
        }

        [Test]
        public void IUserInterfaceTest()
        {
            IUser user = data;
            Assert.AreEqual(userId, user.Id);
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
            Assert.AreEqual(username, user.Username);
        }

        [Test]
        public void AuthenticationDateGetTest()
        {
            UserAuthenticationData data = new() { AuthenticationDateValue = dateTimeValue };
            UserAuthenticationData dataNull = new();

            Assert.AreEqual(dateTime, data.AuthenticationDate.Value.ToLocalTime());
            Assert.IsNull(dataNull.AuthenticationDate);
        }

        [Test]
        public void AuthenticationDateSetTest()
        {
            UserAuthenticationData dataNull = new() { AuthenticationDate = dateTime };
            UserAuthenticationData data = new();

            dataNull.AuthenticationDate = null;
            data.AuthenticationDate = dateTime;

            Assert.AreEqual(dateTimeValue, data.AuthenticationDateValue.Value);
            Assert.IsNull(dataNull.AuthenticationDateValue);
        }
    }
}
