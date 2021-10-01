﻿using System;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Represents errors that occur during bot execution.
    /// </summary>
    public class TelegramBotException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramBotException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TelegramBotException(string message)
            : this(message, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramBotException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public TelegramBotException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
