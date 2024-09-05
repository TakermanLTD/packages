namespace Takerman.Publishing.Emag
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