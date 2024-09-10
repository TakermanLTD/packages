namespace Takerman.Publishing.Platforms.Ebay
{
    public class EbayConfig : PlatformConfig
    {
    }

    public interface IEbayProvider
    {
    }

    public class EbayPlatform : BasePlatform, IEbayProvider
    {
        public EbayPlatform()
        {
            Platform = Platform.Ebay;
        }
    }
}