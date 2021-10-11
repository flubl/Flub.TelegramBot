using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Extension methods for adding the <see cref="TelegramBot"/> Service.
    /// </summary>
    public static class TelegramBotExtension
    {
        /// <summary>
        /// Adds a scoped service of <see cref="TelegramBot"/> to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddTelegramBot(this IServiceCollection services) =>
            AddTelegramBot<TelegramBot>(services);

        /// <summary>
        /// Adds a scoped service of the type specified in <typeparamref name="TTelegramBot"/> to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TTelegramBot">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddTelegramBot<TTelegramBot>(this IServiceCollection services) where TTelegramBot : TelegramBot
        {
            services.AddOptions<TelegramBotOptions>().BindConfiguration(TelegramBotOptions.Position).ValidateDataAnnotations();
            services.AddHttpClient();
            services.AddScoped<TTelegramBot>();
            return services;
        }

        /// <summary>
        /// Gets the <see cref="JsonIgnoreCondition"/> of the <see cref="MemberInfo"/> defined by a <see cref="JsonIgnoreAttribute"/>.
        /// If not set gets the <see cref="JsonSerializerOptions.DefaultIgnoreCondition"/> from the specified <paramref name="options"/>.
        /// If no <paramref name="options"/> specified gets the <paramref name="defaultCondition"/> (Defaults to <see cref="JsonIgnoreCondition.Never"/>).
        /// </summary>
        /// <param name="element">The <see cref="MemberInfo"/> to get a <see cref="JsonIgnoreAttribute"/> from.</param>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/> to get <see cref="JsonSerializerOptions.DefaultIgnoreCondition"/> from.</param>
        /// <param name="defaultCondition">The default <see cref="JsonIgnoreCondition"/> used if no condition is specified.</param>
        /// <returns>Returns the first present <see cref="JsonIgnoreCondition"/>.</returns>
        public static JsonIgnoreCondition GetJsonIgnoreCondition(this MemberInfo element, JsonSerializerOptions options = null,
            JsonIgnoreCondition defaultCondition = JsonIgnoreCondition.Never) =>
            element.GetCustomAttribute<JsonIgnoreAttribute>()?.Condition ?? options?.DefaultIgnoreCondition ?? defaultCondition;

        /// <summary>
        /// Determinds if the specified <paramref name="value"/> should not be ignored.
        /// </summary>
        /// <param name="condition">The <see cref="JsonIgnoreCondition"/> if the <paramref name="value"/> should be ignored.</param>
        /// <param name="value">The value to be checked with the <paramref name="condition"/>.</param>
        /// <returns>Returns <see cref="true"/> if the value should not be ignored.</returns>
        public static bool ShouldNotIgnore(this JsonIgnoreCondition condition, object value) => condition == JsonIgnoreCondition.Never
            || (condition == JsonIgnoreCondition.WhenWritingDefault && !Equals(value, default))
            || (condition == JsonIgnoreCondition.WhenWritingNull && !Equals(value, null));

        /// <summary>
        /// Gets the <see cref="JsonIgnoreCondition"/> and determinds if the speficied <paramref name="value"/> should not be ignored.
        /// </summary>
        /// <param name="element">The <see cref="MemberInfo"/> to get a <see cref="JsonIgnoreAttribute"/> from.</param>
        /// <param name="value">The value to be checkd with the condition.</param>
        /// <param name="options">Optional <see cref="JsonSerializerOptions"/> to get a condition from.</param>
        /// <param name="defaultCondition">The default <see cref="JsonIgnoreCondition"/> used if no condition is specified.</param>
        /// <returns>Returns <see cref="true"/> if the value should not be ignored.</returns>
        public static bool SouldNotBeIgnored(this MemberInfo element, object value, JsonSerializerOptions options = null, JsonIgnoreCondition defaultCondition = JsonIgnoreCondition.Never) =>
            ShouldNotIgnore(GetJsonIgnoreCondition(element, options, defaultCondition), value);

    }
}
