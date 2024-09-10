namespace Takerman.Publishing.Blogger
{
    namespace Takerman.Publishing.Medium
    {
        public class BloggerConfig : PlatformConfig
        {
        }

        public interface IBloggerProvider
        {
        }

        public class BloggerPlatform : BasePlatform, IBloggerProvider
        {
            public BloggerPlatform()
            {
                Platform = Platform.Blogger;
            }
        }
    }
}