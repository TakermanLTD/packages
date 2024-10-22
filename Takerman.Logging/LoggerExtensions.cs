using Microsoft.Extensions.Logging;

namespace Takerman.Logging
{
    public static class LoggerExtensions
    {
        public static void AddTakermanLogging(this ILoggingBuilder builder)
        {
            builder.ClearProviders();
            builder.AddConsole();
            builder.AddFilter("Microsoft", LogLevel.Warning);
            builder.AddProvider(new SlackLoggerProvider());
        }
    }
}
