namespace Takerman.Publishing
{
    public interface IBaseConfig
    {
        public string ClientUrl { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public int Limit { get; set; }
    }

    public abstract class BaseConfig : IBaseConfig
    {
        public string ClientUrl { get; set; } = string.Empty;

        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;

        public int Limit { get; set; }
    }
}