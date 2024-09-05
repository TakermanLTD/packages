namespace Takerman.Publishing.Instagram
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