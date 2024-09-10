namespace Takerman.Publishing.Platforms.Amazon
{
    public class AmazonConfig : PlatformConfig
    {
    }

    public interface IAmazonProvider
    {
    }

    public class AmazonPlatform : BasePlatform, IAmazonProvider
    {
        public AmazonPlatform()
        {
            Platform = Platform.Amazon;
        }
    }
}