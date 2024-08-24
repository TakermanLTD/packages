using Takerman.AI;

var ai = new AIManager();
var result = await ai.GetAnswer("Can I get merried if I am 33 years old?", AIModel.Mixtral7Bversion1);

Console.WriteLine(result);
Console.ReadLine();