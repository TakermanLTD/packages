using Microsoft.Extensions.Options;
using System.Text.Json;
using Takerman.Mixer.Services.Dtos;

namespace Takerman.Publishing.FreeMusicArchive
{
    public class FreeMusicArchiveConfig : PlatformConfig
    {
    }

    public interface IFreeMusicArchiveProvider
    {
        Task<FmaSongDto> GetNewest();
    }

    public class FreeMusicArchivePlatform : BasePlatform, IFreeMusicArchiveProvider
    {
        private readonly IOptions<FreeMusicArchiveConfig> _options;
        private readonly HttpClient _client;

        public FreeMusicArchivePlatform(IOptions<FreeMusicArchiveConfig> options, HttpClient client)
        {
            _options = options;
            _client = client;
            Platform = Platform.FreeMusicArchive;
        }

        public async Task<FmaSongDto> GetNewest()
        {
            var response = await _client.GetAsync($"{_options.Value.ClientUrl}/get/tracks.json?limit={_options.Value.Limit}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var document = JsonDocument.Parse(json);
                var track = document.RootElement.GetProperty("dataset").EnumerateArray().Randomize().FirstOrDefault();

                var song = new FmaSongDto
                {
                    Title = track.GetProperty("track_title").GetString(),
                    Artist = track.GetProperty("artist_name").GetString(),
                    Url = track.GetProperty("track_url").GetString()
                };

                var songResponse = await _client.GetAsync(song.Url, HttpCompletionOption.ResponseHeadersRead);

                if (songResponse.IsSuccessStatusCode)
                {
                    song.Data = await songResponse.Content.ReadAsStreamAsync();
                }

                return song;
            }

            return null;
        }
    }
}