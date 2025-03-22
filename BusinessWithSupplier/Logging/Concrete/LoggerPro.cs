using BusinessWithSupplier.Logging.Abstract;
using CoreNT.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using static BusinessWithSupplier.Logging.Concrete.CustomLoggerConfiguration;

namespace BusinessWithSupplier.Logging.Concrete
{
    public class LoggerPro : ILogger
    {
        private readonly string name;
        private readonly Func<CustomLoggerConfiguration> getCurrentConfig;
        private readonly ILog logger;

        public LoggerPro(string name, Func<CustomLoggerConfiguration> getCurrentConfig, ILog logger) =>
       (this.name, this.getCurrentConfig, this.logger) = (name, getCurrentConfig, logger);

        public IDisposable BeginScope<TState>(TState state)
        {
            return default!;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return getCurrentConfig().LogLevels.ContainsKey(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            CustomLoggerConfiguration config = getCurrentConfig();

            if (config.EventId == 0 || config.EventId == eventId.Id)
            {
                string log;
                switch (config.LogLevels[logLevel])
                {
                    case LogFormat.Short:
                        Console.WriteLine(log = $"{name}: {formatter(state, exception)}");
                        logger.Log(new LogEntity { LogText = log, LogLevel = (int)logLevel, SupplierId = eventId.Id });
                        break;
                    case LogFormat.Long:
                        Console.WriteLine(log = $"[{eventId.Id,2}: {logLevel,-12}] {name} - {formatter(state, exception)}");
                        logger.Log(new LogEntity { LogText = log, LogLevel = (int)logLevel });
                        break;
                    default:
                        // No-op
                        break;
                }
            }
        }
    }

    public class CustomLoggerConfiguration
    {
        public int EventId { get; set; }

        public Dictionary<LogLevel, LogFormat> LogLevels { get; set; } =
            new Dictionary<LogLevel, LogFormat>()
            {
                [LogLevel.Information] = LogFormat.Short,
                [LogLevel.Warning] = LogFormat.Short,
                [LogLevel.Error] = LogFormat.Long
            };

        public enum LogFormat
        {
            Short,
            Long
        }
    }
}
