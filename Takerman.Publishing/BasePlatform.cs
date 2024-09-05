namespace Takerman.Publishing
{
    public interface IProvider
    {
    }

    public abstract class BasePlatform : IProvider
    {
        public Platform Platform { get; set; }
    }
}