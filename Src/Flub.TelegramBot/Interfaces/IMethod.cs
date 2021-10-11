using System.Collections.Immutable;
using System.Text.Json;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Telegram Bot API Method.
    /// </summary>
    public interface IMethod
    {
        /// <summary>
        /// The name of the request method.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Returns all properties with it's name and value to be uploaded.
        /// </summary>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/> to check if a property should be ignored.</param>
        /// <returns>Returns a <see cref="IImmutableDictionary{string, object}"/> with all values to be uploaded.</returns>
        IImmutableDictionary<string, object> GetProperties(JsonSerializerOptions options = null);
    }

    /// <summary>
    /// Base request method with the specified <see cref="Response{TResult}.Result"/> type.
    /// </summary>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    public interface IMethod<TResult> : IMethod
    {

    }
}
