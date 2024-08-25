using Microsoft.Extensions.Logging;
using Takerman.AI;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");

var ai = new AIManager(logger);

var result = await ai.GetTextAnswer("Can I get merried if I am 33 years old?", AIModel.Mixtral7B);

var image = await ai.GetMediaAnswer("Can you make a picture of Joe Binden?", AIModel.DreamLikeArt, "image.png");

Console.WriteLine(image);
Console.ReadLine();