using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Takerman.Publishing.Platforms.Pexels
{
    public class PexelsConfig : PlatformConfig
    {
    }

    public interface IPexelsProvider
    {
    }

    public class PexelsPlatform : BasePlatform, IPexelsProvider
    {
        private readonly IOptions<PexelsConfig> _pexelsOptions;

        public PexelsPlatform(IOptions<PexelsConfig> pexelsOptions)
        {
            _pexelsOptions = pexelsOptions;
            Platform = Platform.Pexels;
        }

        public async Task Download(string search, int imagesCount, string location)
        {
            var urls = await GetUrls(search);

            var imageUrls = urls.OrderBy((item) => new Random().Next()).Take(imagesCount).ToList();
            using var client = new HttpClient();
            for (int i = 0; i < imageUrls.Count; i++)
            {
                var imageUrl = imageUrls[i];
                using var response = await client.GetAsync(imageUrl);
                using var contentStream = await response.Content.ReadAsStreamAsync();
                using var fileStream = new FileStream(Path.Combine(location, "image_" + i + ".jpg"), FileMode.Create, FileAccess.Write, FileShare.None);
                await contentStream.CopyToAsync(fileStream);
            }
        }

        public async Task<IEnumerable<string>> GetUrls(string search)
        {
            var apiUrl = $"https://api.pexels.com/v1/search?query={search}&per_page={_pexelsOptions.Value.Limit}&orientation=landscape&size=medium";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", _pexelsOptions.Value.ClientId);

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<PexelsResponse>(responseBody, options).Photos.Where(x => x.Width % 2 == 0 && x.Height % 2 == 0).ToList();
            if (result != null)
                return result.ConvertAll(photo => photo.Src.Portrait);
            else
                return [];
        }
    }
}