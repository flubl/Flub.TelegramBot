using System;

namespace Flub.TelegramBot.Authentication
{
    /// <summary>
    /// Contains fields to be checked with a hash.
    /// The integrity of the fields can be verified with the <see cref="TelegramBot.Validate(IAuthenticationData, TimeSpan?, bool)"/> method.
    /// </summary>
    public interface IAuthenticationData
    {
        /// <summary>
        /// The hash to be compared.
        /// </summary>
        string AuthenticationHash { get; }
        /// <summary>
        /// Concatenation of all received fields.
        /// </summary>
        string AuthenticationFields { get; }
        /// <summary>
        /// Date of the authentication data was created.
        /// </summary>
        DateTime? AuthenticationDate { get; }
    }
}
