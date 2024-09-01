namespace Takerman.AI.Local
{
    public interface IOllamaApi
    {
        Task<string> TextToText(string question, OllamaModel model);

        Task<string> TextToMedia(string question, OllamaModel model);
    }
}