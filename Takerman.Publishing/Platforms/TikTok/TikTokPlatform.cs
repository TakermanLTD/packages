namespace Takerman.Publishing.Platforms.TikTok
{
    public class TikTokConfig : PlatformConfig
    {
    }

    public interface ITikTokProvider
    {
    }

    public class TikTokPlatform : BasePlatform, ITikTokProvider
    {
        public TikTokPlatform()
        {
            Platform = Platform.TikTok;
        }
    }
}