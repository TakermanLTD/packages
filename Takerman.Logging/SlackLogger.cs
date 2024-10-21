using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using Takerman.Extensions;

namespace Takerman.Logging
{
    public class SlackLogger : ILogger
    {
        private readonly SlackLoggerHelper _slackLoggerHelper;

        public SlackLogger(string webhookUrl)
        {
            _slackLoggerHelper = new SlackLoggerHelper(webhookUrl);
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Error;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);
            _slackLoggerHelper.LogAsync($"[{logLevel}] {message}", exception?.ToString()).Wait();
        }
    }

    internal class SlackLoggerHelper
    {
        private readonly HttpClient _httpClient;
        private readonly string _webhookUrl;

        public SlackLoggerHelper(string webhookUrl)
        {
            _httpClient = new HttpClient();
            _webhookUrl = webhookUrl;
        }

        public async Task LogAsync(string message, string exception)
        {
            var payload = new
            {
                text = message,
                icon_emoji = ":warning:",  // Customize the icon here
                attachments = new[]
                {
                new
                {
                    fallback = "Exception details",
                    color = "#FF0000", // Red color for errors
                    text = exception
                }
            }
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_webhookUrl, content);
        }
    }
}