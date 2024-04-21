using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json;
using Takerman.Mixer.Services.Configuration;
using Takerman.Mixer.Services.Dtos;

namespace Takerman.Mixer.Services.Providers
{
    public interface IJamendoProvider
    {
    }

    public class JamendoProvider(IOptions<JamendoConfig> _jamendoOptions, IOptions<CommonConfig> _options) : BaseProvider, IJamendoProvider
    {
        private readonly HttpClient _client = new()
        {
            BaseAddress = new Uri(_jamendoOptions.Value.ClientUrl)
        };

        public async Task Download(string search)
        {
            var apiUrl = $"/tracks/?client_id={_jamendoOptions.Value.ClientId}&format=json&limit={_jamendoOptions.Value.Limit}&&namesearch={search}";

            var response = await _client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var root = JsonSerializer.Deserialize<JamendoRootObject>(responseBody, options);
            var tracks = root.results.Where(x => !string.IsNullOrEmpty(x.audiodownload)).OrderBy((item) => new Random().Next()).Take(_options.Value.NumOfClips).ToList();

            using var webClient = new WebClient();

            for (int i = 0; i < _options.Value.NumOfClips; i++)
            {
                var track = tracks[i];
                var trackName = "track_" + i + ".mp3";
                var songLocation = Path.Combine(_options.Value.MixLocation, trackName);
                webClient.DownloadFile(track.audiodownload, songLocation);
            }
        }

        public string GetGenreApiUrl(string? genre = null)
        {
            if (genre == null)
            {
                var genres = new List<string>() {
                    "pop",
                    "rock",
                    "electronic",
                    "hiphop",
                    "jazz",
                    "indie",
                    "filmscore",
                    "classical",
                    "chillout",
                    "ambient",
                    "folk",
                    "metal",
                    "latin",
                    "rnb",
                    "reggae",
                    "punk",
                    "country",
                    "house",
                    "blues"
                };
                var randomNumber = new Random();
                var randomIndex = randomNumber.Next(genres.Count);
                genre = genres[randomIndex];
            }
            var apiUrl = $"/tracks/?client_id={_jamendoOptions.Value.ClientId}&format=json&limit={_jamendoOptions.Value.Limit}&tags={genre}";
            return apiUrl;
        }
    }
}