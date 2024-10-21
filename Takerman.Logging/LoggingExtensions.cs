using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Slack;
using Takerman.Extensions;

namespace Takerman.Logging
{
    public static class LoggingExtensions
    {
        public static Serilog.ILogger AddTakermanLogging(this ILoggingBuilder builder)
        {
            var logger = GetLogger();
            builder.AddSerilog(logger);

            return logger;
        }

        public static Serilog.ILogger AddTakermanLogging(this IHostBuilder host)
        {
            var logger = GetLogger();
            host.UseSerilog(logger);

            return logger;
        }

        public static Serilog.ILogger GetLogger()
        {
            var webhook = "X+WrMEkq8umlI49yn+BmlpSd5HABImSunjgiI/0m3JRsFTHz56XXi6/qguOoaWGnzrdfMeSZc1xFi5Um2mBjChmixoLWxh7S7a0FnY0tfuQ=".DecryptString();
            return new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.Slack(webhookUrl: webhook, restrictedToMinimumLevel: LogEventLevel.Error)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentName()
                .Enrich.WithExceptionDetails()
                .CreateLogger();
        }
    }
}