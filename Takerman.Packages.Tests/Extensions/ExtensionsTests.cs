using Takerman.Extensions;

namespace Takerman.Packages.Tests.Extensions
{
    public class ExtensionsTests
    {
        [Fact(Skip = "Prod")]
        public async Task Should_EncryptDataWithAES_When_StringIsPassed()
        {
            var sut = "test".EncryptString();

            var result = sut.DecryptString();

            Assert.NotNull(result);
        }

        [Fact]
        public void Should_GetEnvironmentVariable_When_VariableIsSet()
        {
            var webhook = Environment.GetEnvironmentVariable("SLACK_WEBHOOK_URL");

            Assert.NotNull(webhook);
        }
    }
}