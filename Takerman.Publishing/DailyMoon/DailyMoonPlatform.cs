namespace Takerman.Publishing.DailyMoon
{
    public class DailyMoonConfig : PlatformConfig
    {
    }

    public interface IDailyMoonProvider
    {
    }

    public class DailyMoonPlatform : BasePlatform, IDailyMoonProvider
    {
        public DailyMoonPlatform()
        {
            Platform = Platform.DailyMoon;
        }
    }
}