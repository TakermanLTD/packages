namespace Takerman.Publishing.Emag
{
    public class EmagConfig : BaseConfig
    {
    }

    public interface IEmagProvider
    {
    }

    public class EmagProvider : BaseProvider, IEmagProvider
    {
    }
}