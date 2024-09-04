namespace Takerman.Publishing.Amazon
{
    public class AmazonConfig : BaseConfig
    {
    }

    public interface IAmazonProvider
    {
    }

    public class AmazonProvider : BaseProvider, IAmazonProvider
    {
    }
}