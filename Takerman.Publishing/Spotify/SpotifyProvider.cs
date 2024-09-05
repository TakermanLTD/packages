using Microsoft.Extensions.Options;
using SpotifyAPI.Web;

namespace Takerman.Publishing.Spotify
{
    public class SpotifyConfig : PlatformConfig
    {
    }

    public interface ISpotifyProvider
    {
    }

    public class SpotifyProvider(IOptions<SpotifyConfig> _options) : BasePlatform, ISpotifyProvider
    {
        private readonly SpotifyClient _spotify = new SpotifyClient(_options.Value.ClientId);

        public async Task<SearchResponse> GetByGenre(string genre)
        {
            var searchRequest = new SearchRequest(SearchRequest.Types.Track, $"genre:\"{genre.ToLower()}\"");
            var searchResult = await _spotify.Search.Item(searchRequest);
            return searchResult;
        }
    }
}