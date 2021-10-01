using System;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Represents errors that occur during bot request execution.
    /// </summary>
    public class TelegramBotRequestException : TelegramBotException
    {
        /// <summary>
        /// The requested method.
        /// </summary>
        public Method Method { get; set; }
        /// <summary>
        /// Information about the error.
        /// </summary>
        public Response Response { get; }
        /// <summary>
        /// Optional error code (its contents are subject to change in the future).
        /// </summary>
        public int? ErrorCode => Response.ErrorCode;
        /// <summary>
        /// Optional human-readable description of the result.
        /// </summary>
        public string Description => Response.Description;
        /// <summary>
        /// Some errors may also have an optional field 'parameters' of the type <see cref="ResponseParameters"/>, which can help to automatically handle the error.
        /// </summary>
        public ResponseParameters Parameters => Response.Parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramBotRequestException"/> class with a specified response and error message.
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="method">The requested method.</param>
        /// <param name="response">The response that describes the error.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public TelegramBotRequestException(Method method, Response response, string message, Exception innerException)
            : base(message, innerException)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));
            if (response is null)
                throw new ArgumentNullException(nameof(response));
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramBotRequestException"/> class with a specified response and error message.
        /// </summary>
        /// <param name="method">The requested method.</param>
        /// <param name="response">The response that describes the error.</param>
        /// <param name="message">The message that describes the error.</param>
        public TelegramBotRequestException(Method method, Response response, string message)
            : this(method, response, message, null)
        {

        }
    }
}
