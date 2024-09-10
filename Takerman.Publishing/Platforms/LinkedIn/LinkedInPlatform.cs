namespace Takerman.Publishing.Platforms.LinkedIn
{
    public class LinkedInConfig : PlatformConfig
    {
    }

    public interface ILinkedInProvider
    {
    }

    public class LinkedInPlatform : BasePlatform, ILinkedInProvider
    {
        public LinkedInPlatform()
        {
            Platform = Platform.LinkedIn;
        }
    }
}