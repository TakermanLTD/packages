using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Slack;

namespace Takerman.Logging
{
    public static class LoggingExtensions
    {
        private static string webhookUrl = Environment.GetEnvironmentVariable("SLACK_EXCEPTIONS");

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

        public static Serilog.ILogger GetLogger() => new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.Slack( webhookUrl: webhookUrl, restrictedToMinimumLevel: LogEventLevel.Error)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentName()
                .Enrich.WithExceptionDetails()
                .CreateLogger();
    }
}