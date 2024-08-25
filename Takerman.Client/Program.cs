using Takerman.AI;
using Takerman.AI.Config;

for (int i = 0; i < 3; i++)
{
    var text = await HuggingChatHelper.GetTextResultAsync("Please tell me interesting fact about toxic father or toxic brother.", ModelType.Gemma7B);
    Console.WriteLine(text);

    var image = await HuggingChatHelper.GetTextToMediaResultAsync("Can you make a caricature of famouse politician this year?", ModelType.DreamLikeArt);
    File.WriteAllBytes($"C:\\image{i}.png", image);
}

Console.ReadLine();