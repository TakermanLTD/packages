namespace Takerman.Publishing.Platforms.X
{
    public class XConfig : PlatformConfig
    {
    }

    public interface IXProvider
    {
    }

    public class XPlatform : BasePlatform, IXProvider
    {
        public XPlatform()
        {
            Platform = Platform.X;
        }
    }
}