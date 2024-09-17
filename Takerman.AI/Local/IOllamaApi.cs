namespace Takerman.AI.Local
{
    public interface IOllamaApi
    {
        Task<IEnumerable<object>> TextToMedia(string question, OllamaModel model);

        Task<string> TextToText(string question, OllamaModel model);
    }
}