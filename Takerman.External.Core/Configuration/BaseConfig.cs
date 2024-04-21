namespace Takerman.Mixer.Services.Configuration
{
    public abstract class BaseConfig : IBaseConfig
    {
        public string ClientUrl { get; set; } = string.Empty;

        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;

        public int Limit { get; set; }
    }
}