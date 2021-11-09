using Flub.TelegramBot.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Flub.TelegramBot.Methods
{
    /// <summary>
    /// Informs a user that some of the Telegram Passport elements they provided contains errors.
    /// The user will not be able to re-submit their Passport to you until the errors are fixed (the contents of the field for which you returned the error must change).
    /// Returns <see langword="true"/> on success.
    /// </summary>
    public class SetPassportDataErrors : Method<bool?>
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        [Required]
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
        /// <summary>
        /// A list describing the errors.
        /// </summary>
        [Required]
        [JsonPropertyName("errors")]
        public IEnumerable<PassportElementError> Errors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPassportDataErrors"/> class.
        /// </summary>
        public SetPassportDataErrors() : base("setPassportDataErrors") { }
    }

    public static class SetPassportDataErrorsExtension
    {
        private static Task<bool?> SetPassportDataErrors(this TelegramBot bot, SetPassportDataErrors method, CancellationToken cancellationToken = default) =>
            bot.Send(method, cancellationToken);

        /// <summary>
        /// Informs a user that some of the Telegram Passport elements they provided contains errors.
        /// The user will not be able to re-submit their Passport to you until the errors are fixed (the contents of the field for which you returned the error must change).
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="errors">A list describing the errors.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetPassportDataErrors(this TelegramBot bot,
            long? userId,
            IEnumerable<PassportElementError> errors,
            CancellationToken cancellationToken = default) =>
            SetPassportDataErrors(bot, new()
            {
                UserId = userId,
                Errors = errors
            }, cancellationToken);

        /// <summary>
        /// Informs a user that some of the Telegram Passport elements they provided contains errors.
        /// The user will not be able to re-submit their Passport to you until the errors are fixed (the contents of the field for which you returned the error must change).
        /// Returns <see langword="true"/> on success.
        /// </summary>
        /// <param name="bot">The bot to send the request with.</param>
        /// <param name="user">Target user.</param>
        /// <param name="errors">A list describing the errors.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public static Task<bool?> SetPassportDataErrors(this TelegramBot bot,
            IUser user,
            IEnumerable<PassportElementError> errors,
            CancellationToken cancellationToken = default) =>
            SetPassportDataErrors(bot, new()
            {
                UserId = user?.Id,
                Errors = errors
            }, cancellationToken);
    }
}
