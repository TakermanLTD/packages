namespace Takerman.Publishing.Ebay
{
    public class EbayConfig : PlatformConfig
    {
    }

    public interface IEbayProvider
    {
    }

    public class EbayProvider : BasePlatform, IEbayProvider
    {
    }
}