using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Flub.TelegramBot
{
    public partial class TelegramBot
    {
        /// <summary>
        /// Initializes a new instance of <typeparamref name="TTelegramBot"/> with the specified bot options and action used to configure the services.
        /// </summary>
        /// <typeparam name="TTelegramBot">The type of the bot.</typeparam>
        /// <param name="botOptions">The <see cref="TelegramBotOptions"/> to be configured.</param>
        /// <param name="configure">The action used to configure the services.</param>
        /// <returns>Returns the configured <typeparamref name="TTelegramBot"/>.</returns>
        public static TTelegramBot Create<TTelegramBot>(TelegramBotOptions botOptions,
            Action<IConfigurationBuilder, IServiceCollection> configure) where TTelegramBot : TelegramBot
        {
            // validate telegram bot options
            if (botOptions is not null && new DataAnnotationValidateOptions<TelegramBotOptions>(string.Empty)
                .Validate(string.Empty, botOptions) is ValidateOptionsResult result && result.Failed)
                throw new OptionsValidationException(string.Empty, botOptions.GetType(), result.Failures);

            ConfigurationBuilder builder = new();

            ServiceCollection services = new();
            services.AddTelegramBot<TTelegramBot>();
            if (botOptions is not null)
                services.AddSingleton(Options.Create(botOptions));
            configure?.Invoke(builder, services);
            services.AddSingleton<IConfiguration>(builder.Build());

            return services.BuildServiceProvider().GetRequiredService<TTelegramBot>();
        }

        /// <summary>
        /// Initializes a new instance of <typeparamref name="TTelegramBot"/> with the specified bot options.
        /// </summary>
        /// <typeparam name="TTelegramBot">The type of the bot.</typeparam>
        /// <param name="botOptions">The <see cref="TelegramBotOptions"/> to be configured.</param>
        /// <returns>Returns the configured <typeparamref name="TTelegramBot"/>.</returns>
        public static TTelegramBot Create<TTelegramBot>(TelegramBotOptions botOptions) where TTelegramBot : TelegramBot =>
            Create<TTelegramBot>(botOptions, null);

        /// <summary>
        /// Initializes a new instance of <typeparamref name="TTelegramBot"/> with the specified action used to configure the services.
        /// </summary>
        /// <typeparam name="TTelegramBot">The type of the bot.</typeparam>
        /// <param name="configure">The action used to configure the services.</param>
        /// <returns>Returns the configured <typeparamref name="TTelegramBot"/>.</returns>
        public static TTelegramBot Create<TTelegramBot>(Action<IConfigurationBuilder, IServiceCollection> configure) where TTelegramBot : TelegramBot =>
            Create<TTelegramBot>(null, configure);

        /// <summary>
        /// Initializes a new instance of <see cref="TelegramBot"/> with the specified bot options and action used to configure the services.
        /// </summary>
        /// <param name="botOptions">The <see cref="TelegramBotOptions"/> to be configured.</param>
        /// <param name="configure">The action used to configure the services.</param>
        /// <returns>Returns the configured <see cref="TelegramBot"/>.</returns>
        public static TelegramBot Create(TelegramBotOptions botOptions,
            Action<IConfigurationBuilder, IServiceCollection> configure) =>
            Create<TelegramBot>(botOptions, configure);

        /// <summary>
        /// Initializes a new instance of <see cref="TelegramBot"/> with the specified bot options.
        /// </summary>
        /// <param name="botOptions">The <see cref="TelegramBotOptions"/> to be configured.</param>
        /// <returns>Returns the configured <see cref="TelegramBot"/>.</returns>
        public static TelegramBot Create(TelegramBotOptions botOptions) =>
            Create<TelegramBot>(botOptions, null);

        /// <summary>
        /// Initializes a new instance of <see cref="TelegramBot"/> with the specified action used to configure the services.
        /// </summary>
        /// <param name="configure">The action used to configure the services.</param>
        /// <returns>Returns the configured <see cref="TelegramBot"/>.</returns>
        public static TelegramBot Create(Action<IConfigurationBuilder, IServiceCollection> configure) =>
            Create<TelegramBot>(null, configure);
    }
}
