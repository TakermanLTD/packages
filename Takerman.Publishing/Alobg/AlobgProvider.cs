namespace Takerman.Publishing.Alobg
{
    public class AlobgConfig : BaseConfig
    {
    }

    public interface IAlobgProvider
    {
    }

    public class AlobgProvider : BaseProvider, IAlobgProvider
    {
        private static async Task ProcessRepositoriesAsync()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}