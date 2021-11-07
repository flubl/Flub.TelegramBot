using Flub.TelegramBot.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Flub.TelegramBot
{
    public partial class TelegramBot
    {
        /// <summary>
        /// Computes a hash over the data with the bot token as key.
        /// </summary>
        /// <param name="authenticationData">The data to be hashed.</param>
        /// <returns>Returns the string representation in hex of the computed hash.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string ComputeHash(IAuthenticationData authenticationData)
        {
            if (authenticationData is null)
                throw new ArgumentNullException(nameof(authenticationData));
            using SHA256 sha = SHA256.Create();
            using HMACSHA256 hmac = new(sha.ComputeHash(Encoding.UTF8.GetBytes(token)));
            return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(authenticationData.AuthenticationFields)));
        }

        /// <summary>
        /// Validates the speficied data.
        /// </summary>
        /// <param name="authenticationData">The data to be validated.</param>
        /// <param name="validTimeSpan">
        /// The valid timespan between the <see cref="IAuthenticationData.AuthenticationDate"/> and <see cref="DateTime.Now"/>.
        /// If <see langword="null"/>, the date will be ignored.
        /// </param>
        /// <param name="throwExceptionOnFailure">True to throw a exception if validation fails.</param>
        /// <returns>Returns <see langword="true"/> if the validation was successful.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TelegramBotException"></exception>
        public bool Validate(IAuthenticationData authenticationData, TimeSpan? validTimeSpan = null, bool throwExceptionOnFailure = true)
        {
            if (!string.Equals(ComputeHash(authenticationData), authenticationData.AuthenticationHash, StringComparison.OrdinalIgnoreCase) || 
                validTimeSpan.HasValue && (!authenticationData.AuthenticationDate.HasValue || DateTime.Now.Subtract(authenticationData.AuthenticationDate.Value) > validTimeSpan))
            {
                logger?.LogCritical("Invalid authorization");
                if (throwExceptionOnFailure)
                    throw new TelegramBotException("Invalid authorization.");
                return false;
            }
            logger?.LogCritical("Valid authorization");
            return true;
        }
    }
}
