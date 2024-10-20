using Takerman.AI.Local;

namespace Takerman.Packages.Tests.AI
{
    public class OllamaTests
    {
        private static OllamaApi _ollamaChat = new();

        [Fact(Skip = "Prod")]
        public async Task Should_GenerateMediaAnswer_When_RequestingWithText()
        {
            var question = @"Please make trendy stamp for t-shirt for Anime as Kimetsu no Yaiba.";
            var result = await _ollamaChat.TextToMedia(question, OllamaModel.Flux7b);

            Assert.NotNull(result);
        }

        [Fact(Skip = "Until better way for the build is found")]
        public async Task Should_GenerateTextAnswer_When_RequestingWithText()
        {
            var question = @"Please can you analyse the code in the location C:\dev\app-dating\Takerman.Dating.Server on this computer and list me all security vulnarabilities and code improvements that I can make?";
            var result = await _ollamaChat.TextToText(question, OllamaModel.Codelamma7b);

            Assert.NotNull(result);
        }
    }
}