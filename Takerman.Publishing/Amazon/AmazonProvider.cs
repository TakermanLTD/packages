namespace Takerman.Publishing.Amazon
{
    public class AmazonConfig : PlatformConfig
    {
    }

    public interface IAmazonProvider
    {
    }

    public class AmazonProvider : BasePlatform, IAmazonProvider
    {
    }
}