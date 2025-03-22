using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace BusinessWithSupplier.Logging.Concrete
{
    public static class CustomLoggerExtensions
    {
        public static ILoggingBuilder AddCustomLogger(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, CustomLoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions
                <CustomLoggerConfiguration, CustomLoggerProvider>(builder.Services);

            return builder;
        }
    }
}
