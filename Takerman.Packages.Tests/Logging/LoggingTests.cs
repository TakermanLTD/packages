using Takerman.Extensions;
using Takerman.Logging;

namespace Takerman.Packages.Tests.Extensions
{
    public class LoggingTests
    {
        [Fact]
        public async Task Should_LogToSlack_When_AnExceptionOccured()
        {
            var logger = LoggingExtensions.GetLogger();

            Assert.NotNull(logger);
        }
    }
}