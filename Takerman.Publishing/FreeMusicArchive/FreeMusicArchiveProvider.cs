using Microsoft.Extensions.Options;
using System.Text.Json;
using Takerman.Mixer.Services.Dtos;

namespace Takerman.Publishing.FreeMusicArchive
{
    public class FreeMusicArchiveConfig : BaseConfig
    {
    }

    public interface IFreeMusicArchiveProvider
    {
        Task<FmaSongDto> GetNewest();
    }

    public class FreeMusicArchiveProvider(IOptions<FreeMusicArchiveConfig> _options, HttpClient _client) : BaseProvider, IFreeMusicArchiveProvider
    {
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