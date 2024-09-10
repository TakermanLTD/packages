using Microsoft.Extensions.Options;
using SpotifyAPI.Web;

namespace Takerman.Publishing.Platforms.Spotify
{
    public class SpotifyConfig : PlatformConfig
    {
    }

    public interface ISpotifyProvider
    {
    }

    public class SpotifyPlatform : BasePlatform, ISpotifyProvider
    {
        private readonly SpotifyClient _spotify;
        private readonly IOptions<SpotifyConfig> _options;

        public SpotifyPlatform(IOptions<SpotifyConfig> options)
        {
            _options = options;
            _spotify = new SpotifyClient(_options.Value.ClientId);
            Platform = Platform.Spotify;
        }

        public async Task<SearchResponse> GetByGenre(string genre)
        {
            var searchRequest = new SearchRequest(SearchRequest.Types.Track, $"genre:\"{genre.ToLower()}\"");
            var searchResult = await _spotify.Search.Item(searchRequest);
            return searchResult;
        }
    }
}