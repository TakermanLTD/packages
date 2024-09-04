using Takerman.AI.HuggingChat;

namespace Takerman.Packages.Tests.AI
{
    public class HuggingChatTests
    {
        private static HuggingChatApi _huggingChat = new();

        [Fact(Skip = "Until better way for the build is found")]
        public async Task Should_GenerateTextAnswer_When_RequestingWithText()
        {
            Directory.CreateDirectory(@"C:\publications");

            var i = 0;
            while (i < 10)
            {
                try
                {
                    var text = await _huggingChat.TextToText("Please write an engaging article about toxic father and toxic brother. The article should be at least 7 minutes of reading long and should be better than the last one.", HuggingChatModel.Mixtral7B);
                    await File.WriteAllTextAsync($@"C:\publications\toxicfatherandbrother{i + 1}.txt", text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                }
            }

            Assert.True(true);
        }

        [Fact(Skip = "Until better way for the build is found")]
        public async Task Should_GeneratePicturesAnswer_When_RequestingWithText()
        {
            Directory.CreateDirectory(@"C:\anime");

            var i = 0;
            while (i < 10)
            {
                try
                {
                    var image = await _huggingChat.TextToMedia("Create possible the best anime character, that could be potentially one of the best anime characters ever. The picture should be better than the last one and the person should be visible in full height, full size of the person from top to the bottom.", HuggingChatModel.Flux);
                    await File.WriteAllBytesAsync($@"C:\anime\image{i}.png", image);
                    i++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                }

                Console.WriteLine($"finished {i}");
            }

            Assert.True(true);
        }
    }
}