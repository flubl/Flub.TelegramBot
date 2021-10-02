using Flub.TelegramBot.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Flub.TelegramBot
{
    public partial class TelegramBot
    {
        /// <summary>
        /// Validates the speficied data.
        /// </summary>
        /// <param name="authorizationData">The data to be validated.</param>
        /// <param name="throwExceptionOnFailure">True to throw a exception if validation fails.</param>
        /// <returns>Returns true if the validation was successful.</returns>
        public bool ValidateAuthorizationData(AuthorizationData authorizationData, bool throwExceptionOnFailure = true)
        {
            if (authorizationData is null)
                throw new ArgumentNullException(nameof(authorizationData));
            using SHA256 sha = SHA256.Create();
            byte[] key = sha.ComputeHash(Encoding.UTF8.GetBytes(token));
            using HMACSHA256 hmac = new(key);
            string hash = Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(authorizationData.DataCheckString)));
            if (hash != authorizationData.Hash)
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
