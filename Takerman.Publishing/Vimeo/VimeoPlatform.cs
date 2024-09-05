namespace Takerman.Publishing.Vimeo
{
    public class VimeoConfig : PlatformConfig
    {
    }

    public interface IVimeoProvider
    {
    }

    public class VimeoPlatform : BasePlatform, IVimeoProvider
    {
        public VimeoPlatform()
        {
            Platform = Platform.Vimeo;
        }
    }
}