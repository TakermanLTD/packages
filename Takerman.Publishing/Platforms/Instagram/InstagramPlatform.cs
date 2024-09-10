namespace Takerman.Publishing.Platforms.Instagram
{
    public class InstagramConfig : PlatformConfig
    {
    }

    public interface IInstagramProvider
    {
    }

    public class InstagramPlatform : BasePlatform, IInstagramProvider
    {
        public InstagramPlatform()
        {
            Platform = Platform.Instagram;
        }
    }
}