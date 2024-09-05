namespace Takerman.Publishing.X
{
    public class XConfig : PlatformConfig
    {
    }

    public interface IXProvider
    {
    }

    public class XProvider : BasePlatform, IXProvider
    {
        public XProvider()
        {
            Platform = Platform.X;
        }
    }
}