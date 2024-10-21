using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using Takerman.Extensions;

namespace Takerman.Logging
{
    public class SlackLogger : ILogger
    {
        private readonly SlackLoggerHelper _slackLoggerHelper;

        public SlackLogger()
        {
            _slackLoggerHelper = new SlackLoggerHelper();
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);
            _slackLoggerHelper.LogAsync($"[{logLevel}] {message}").Wait();
        }
    }

    public class SlackLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new SlackLogger();
        }

        public void Dispose()
        { }
    }

    internal class SlackLoggerHelper
    {
        private readonly HttpClient _httpClient;
        private readonly string _webhookUrl = "X+WrMEkq8umlI49yn+BmlpSd5HABImSunjgiI/0m3JRsFTHz56XXi6/qguOoaWGnzrdfMeSZc1xFi5Um2mBjChmixoLWxh7S7a0FnY0tfuQ=".DecryptString();

        public SlackLoggerHelper()
        {
            _httpClient = new HttpClient();
        }

        public async Task LogAsync(string message)
        {
            var payload = new
            {
                text = message
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_webhookUrl, content);
        }
    }
}