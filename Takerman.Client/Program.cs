using Takerman.AI;
using Takerman.AI.Config;

var i = 0;
while (i < 3)
{
    try
    {
        var text = await HuggingChatHelper.GetTextResultAsync("Please tell me interesting fact about toxic father or toxic brother.", ModelType.Gemma7B);
        Console.WriteLine(text);
        Console.WriteLine();

        var image = await HuggingChatHelper.GetResultAsync("A Character from the demon slayers corp drawin in the style which the naruto anime is drawn", ModelType.Flux);
        File.WriteAllBytes($"C:\\image{i}.png", image);
        Console.WriteLine($"Generated image number {i}");
        i++;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
    }
}

Console.ReadLine();