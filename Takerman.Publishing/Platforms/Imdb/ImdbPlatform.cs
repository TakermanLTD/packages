namespace Takerman.Publishing.Platforms.Imdb
{
    public class ImdbConfig : PlatformConfig
    {
    }

    public interface IImdbProvider
    {
    }

    public class ImdbPlatform : BasePlatform, IImdbProvider
    {
        public ImdbPlatform()
        {
            Platform = Platform.Imdb;
        }
    }
}