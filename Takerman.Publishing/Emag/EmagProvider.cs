namespace Takerman.Publishing.Emag
{
    public class EmagConfig : PlatformConfig
    {
    }

    public interface IEmagProvider
    {
    }

    public class EmagProvider : BasePlatform, IEmagProvider
    {
    }
}