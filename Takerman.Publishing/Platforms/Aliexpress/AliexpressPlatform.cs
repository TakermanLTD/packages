namespace Takerman.Publishing.Platforms.Aliexpress
{
    public class AliexpressConfig : PlatformConfig
    {
    }

    public interface IAliexpressProvider
    {
    }

    public class AliexpressPlatform : BasePlatform, IAliexpressProvider
    {
        public AliexpressPlatform()
        {
            Platform = Platform.Aliexpress;
        }
    }
}