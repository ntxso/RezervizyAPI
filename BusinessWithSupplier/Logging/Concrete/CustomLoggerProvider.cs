using BusinessWithSupplier.Logging.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Logging.Concrete
{
    [ProviderAlias("CustomLog")]
    public sealed class CustomLoggerProvider : ILoggerProvider
    {
        private readonly IDisposable onChangeToken;
        private CustomLoggerConfiguration config;
        private readonly ConcurrentDictionary<string, LoggerPro> loggers =
            new ConcurrentDictionary<string, LoggerPro>(StringComparer.OrdinalIgnoreCase);
        private readonly ILog logger;
        public CustomLoggerProvider(IOptionsMonitor<CustomLoggerConfiguration> config, ILog logger)
        {
            this.config = config.CurrentValue;
            this.logger = logger;
            onChangeToken = config.OnChange(updatedConfig => this.config = updatedConfig);
        }

        public ILogger CreateLogger(string categoryName) =>
            loggers.GetOrAdd(categoryName, name => new LoggerPro(name, GetCurrentConfig, logger));

        private CustomLoggerConfiguration GetCurrentConfig() => config;

        public void Dispose()
        {
            loggers.Clear();
            onChangeToken.Dispose();
        }
    }
}
