using Takerman.AI.HuggingChat;
using Takerman.AI.Local;

public class Program
{
    private static HuggingChatApi _huggingChat = new();
    private static OllamaApi _ollamaChat = new();

    private static async Task Main(string[] args)
    {
        await TestOllamaChat();

        Console.ReadLine();
    }

    private static async Task TestOllamaChat()
    {
        var question = "Please can you analyse the code in the location C:\\Users\\Administrator\\source\\repos\\app-dating\\Takerman.Dating.Server on this computer and list me all security vulnarabilities and code improvements that I can make?";
        var result = await _ollamaChat.TextToText(question, OllamaModel.Codelamma7b);

        Console.WriteLine(result);
    }

    private static async Task TestHuggingFace()
    {
        var i = 0;
        while (i < 3)
        {
            try
            {
                var text = await _huggingChat.TextToText("Please tell me interesting fact about toxic father or toxic brother.", HuggingChatModel.Gemma7B);
                Console.WriteLine(text);
                Console.WriteLine();

                var image = await _huggingChat.TextToMedia("Thumbnail for a speed dating website for a date from 23 to 30 years old ", HuggingChatModel.Flux);
                File.WriteAllBytes($"C:\\image{i}.png", image);
                Console.WriteLine($"Generated image number {i}");
                i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
            }
        }
    }
}