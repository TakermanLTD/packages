using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Slack;
using Takerman.Extensions;

namespace Takerman.Logging
{
    public static class LoggingExtensions
    {
        private static readonly string aes_string = "X+WrMEkq8umlI49yn+BmlpSd5HABImSunjgiI/0m3JRnAHq32AlnSGqE1Bd/eg11/bLHMVB2i8czW7XDrsXcluYtvwpY1i5wZiMBTrMgSvA=";

        public static Serilog.ILogger TakermanLogger => new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning)
                .WriteTo.Slack(aes_string.DecryptString(), restrictedToMinimumLevel: LogEventLevel.Error)
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