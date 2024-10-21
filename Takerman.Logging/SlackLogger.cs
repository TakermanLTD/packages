
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Takerman.Logging
{
    public class SlackLogger : ILogger
    {
        private readonly string _webhookUrl;
        private readonly HttpClient _httpClient;

        public SlackLogger(string webhookUrl, HttpClient httpClient)
        {
            _webhookUrl = webhookUrl;
            _httpClient = httpClient;
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
            LogToSlackAsync($"[{logLevel}] {message}", exception?.ToString()).Wait();
        }

        private async Task LogToSlackAsync(string message, string exception)
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

    public class SlackLoggerProvider : ILoggerProvider
    {
        private readonly string _webhookUrl;
        private readonly HttpClient _httpClient;

        public SlackLoggerProvider(string webhookUrl, HttpClient httpClient)
        {
            _webhookUrl = webhookUrl;
            _httpClient = httpClient;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SlackLogger(_webhookUrl, _httpClient);
        }

        public void Dispose() { }
    }

}