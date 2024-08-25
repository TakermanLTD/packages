namespace Takerman.Mixer.Services.Configuration
{
    public interface IBaseConfig
    {
        public string ClientUrl { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public int Limit { get; set; }
    }
}