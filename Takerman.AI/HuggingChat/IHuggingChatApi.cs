namespace Takerman.AI.HuggingChat
{
    public interface IHuggingChatApi : IChatApi
    {
        Task<string> TextToText(string question, HuggingChatModel model);

        Task<string> TextToMedia(string question, HuggingChatModel model);
    }
}