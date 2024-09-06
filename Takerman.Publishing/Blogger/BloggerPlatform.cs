using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takerman.Publishing.Medium;

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
