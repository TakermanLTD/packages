namespace Takerman.Publishing.Platforms.Facebook
{
    public class FacebookConfig : PlatformConfig
    {
    }

    public interface IFacebookProvider
    {
    }

    public class FacebookPlatform : BasePlatform, IFacebookProvider
    {
        public FacebookPlatform()
        {
            Platform = Platform.Facebook;
        }
    }
}