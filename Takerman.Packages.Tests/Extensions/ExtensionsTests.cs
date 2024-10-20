using Takerman.Extensions;

namespace Takerman.Packages.Tests.Extensions
{
    public class ExtensionsTests
    {
        [Fact]
        public async Task Should_EncryptDataWithAES_When_StringIsPassed()
        {
            var sut = "https://hooks.slack.com/services/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".EncryptString();

            var result = sut.DecryptString();

            Assert.NotNull(result);
        }
    }
}