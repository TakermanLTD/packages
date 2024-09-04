using Takerman.AI.Local;

namespace Takerman.Packages.Tests.AI
{
    public class OllamaTests
    {
        private static OllamaApi _ollamaChat = new();

        [Fact]
        public async Task Should_GenerateTextAnswer_When_RequestingWithText()
        {
            var question = @"Please can you analyse the code in the location C:\dev\app-dating\Takerman.Dating.Server on this computer and list me all security vulnarabilities and code improvements that I can make?";
            var result = await _ollamaChat.TextToText(question, OllamaModel.Codelamma7b);

            Assert.NotNull(result);
        }
    }
}