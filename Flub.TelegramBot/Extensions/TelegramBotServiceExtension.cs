using Microsoft.Extensions.DependencyInjection;

namespace Flub.TelegramBot
{
    /// <summary>
    /// Extension methods for adding the <see cref="TelegramBot"/> Service.
    /// </summary>
    public static class TelegramBotServiceExtension
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
    }
}
