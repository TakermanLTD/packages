using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Slack;
using Serilog.Exceptions;

namespace Takerman.Logging
{
    public static class LoggingExtensions
    {
        public static Serilog.ILogger TakermanLogger => new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.Slack(webhookUrl: Environment.GetEnvironmentVariable("SLACK_WEBHOOK_URL"), restrictedToMinimumLevel: LogEventLevel.Error)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentName()
                .Enrich.WithExceptionDetails()
                .CreateLogger();

        public static Serilog.ILogger AddTakermanLogging(this ILoggingBuilder builder)
        {
            builder.AddSerilog(TakermanLogger);

            return TakermanLogger;
        }

        public static Serilog.ILogger AddTakermanLogging(this IHostBuilder host)
        {
            host.UseSerilog(TakermanLogger);

            return TakermanLogger;
        }
    }
}