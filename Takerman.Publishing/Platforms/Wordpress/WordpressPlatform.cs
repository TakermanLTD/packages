namespace Takerman.Publishing.Platforms.Wordpress
{
    public class WordpressConfig : PlatformConfig
    {
    }

    public interface IWordpressProvider
    {
    }

    public class WordpressPlatform : BasePlatform, IWordpressProvider
    {
        public WordpressPlatform()
        {
            Platform = Platform.Wordpress;
        }
    }
}