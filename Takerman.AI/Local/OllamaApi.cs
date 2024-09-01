using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Takerman.AI.Local
{
    public class OllamaApi : IOllamaApi
    {
        private const string OLLAMA_API = "http://localhost:11434";

        public Task<string> TextToMedia(string question, OllamaModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TextToText(string question, OllamaModel model)
        {
#pragma warning disable SKEXP0010
            var kernel = Kernel.CreateBuilder()
                                .AddOpenAIChatCompletion(
                                    modelId: model.GetEnumDescription(),
                                    endpoint: new Uri(OLLAMA_API),
                                    apiKey: "")
                                .Build();

            var aiChatService = kernel.GetRequiredService<IChatCompletionService>();
            var chatHistory = new ChatHistory();

            while (true)
            {
                chatHistory.Add(new ChatMessageContent(AuthorRole.User, question));

                var response = "";
                await foreach (var item in aiChatService.GetStreamingChatMessageContentsAsync(chatHistory))
                {
                    response += item.Content;
                }
                chatHistory.Add(new ChatMessageContent(AuthorRole.Assistant, response));
                return response;
            }
        }
    }
}