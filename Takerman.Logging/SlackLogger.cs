using Microsoft.Extensions.Logging;
using System.Text;
using Takerman.Extensions;

public class SlackLogger(string _name, SlackLoggerConfiguration config) : ILogger
{
    private readonly SlackLoggerConfiguration _config = config;

    public IDisposable BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) =>
        _config.LogLevels.Contains(logLevel);

    public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        if (_config.EventId == 0 || _config.EventId == eventId.Id)
        {
            var logMessage = formatter(state, exception);
            var slackMessage = $"{{\"text\": \"{logMessage}\", \"icon_emoji\": \":exclamation:\", \"attachments\": [{{ \"color\": \"danger\" }}]}}";

            using var client = new HttpClient();
            var content = new StringContent(slackMessage, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_config.WebhookUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }
}

public class SlackLoggerConfiguration
{
    public string WebhookUrl { get; set; }

    public List<LogLevel> LogLevels { get; set; } = [LogLevel.Error];

    public int EventId { get; set; } = 0;
}

public class SlackLoggerProvider : ILoggerProvider
{
    private readonly SlackLoggerConfiguration _config = new SlackLoggerConfiguration
    {
        WebhookUrl = "X+WrMEkq8umlI49yn+BmlpSd5HABImSunjgiI/0m3JRsFTHz56XXi6/qguOoaWGnzrdfMeSZc1xFi5Um2mBjChmixoLWxh7S7a0FnY0tfuQ=".DecryptString(),
        LogLevels = [LogLevel.Error, LogLevel.Critical]
    };

    public ILogger CreateLogger(string categoryName) =>
        new SlackLogger(categoryName, _config);

    public void Dispose()
    {
    }
}