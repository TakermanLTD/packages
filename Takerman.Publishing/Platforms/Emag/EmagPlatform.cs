namespace Takerman.Publishing.Platforms.Emag
{
    public class EmagConfig : PlatformConfig
    {
    }

    public interface IEmagProvider
    {
    }

    public class EmagPlatform : BasePlatform, IEmagProvider
    {
        public EmagPlatform()
        {
            Platform = Platform.Emag;
        }
    }
}