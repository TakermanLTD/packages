namespace Takerman.Publishing.Imdb
{
    public class ImdbConfig : PlatformConfig
    {
    }

    public interface IImdbProvider
    {
    }

    public class ImdbProvider : BasePlatform, IImdbProvider
    {
    }
}