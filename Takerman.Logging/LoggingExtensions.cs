using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Slack;

namespace Takerman.Logging
{
    public static class LoggingExtensions
    {
        public static Serilog.ILogger TakermanLogger => new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.Slack("https://hooks.slack.com/services/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", restrictedToMinimumLevel: LogEventLevel.Error)
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