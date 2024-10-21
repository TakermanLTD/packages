using Microsoft.Extensions.Logging;

namespace Takerman.Logging
{
    public class SlackLoggerProvider(string webhookUrl) : ILoggerProvider
    {
        private readonly string _webhookUrl = webhookUrl;

        public ILogger CreateLogger(string categoryName)
        {
            return new SlackLogger(_webhookUrl);
        }

        public void Dispose() { }
    }
}