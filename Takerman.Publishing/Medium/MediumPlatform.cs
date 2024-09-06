namespace Takerman.Publishing.Medium
{
    public class MediumConfig : PlatformConfig
    {
    }

    public interface IMediumProvider
    {
    }

    public class MediumPlatform : BasePlatform, IMediumProvider
    {
        public MediumPlatform()
        {
            Platform = Platform.Medium;
        }
    }
}