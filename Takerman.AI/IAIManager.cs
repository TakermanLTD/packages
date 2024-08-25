namespace Takerman.AI
{
    public interface IAIManager
    {
        Task<string> GetTextAnswer(string question, AIModel model);

        Task<byte[]> GetMediaAnswer(string question, AIModel model, string outputFileName);
    }
}