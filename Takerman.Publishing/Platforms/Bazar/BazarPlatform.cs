﻿namespace Takerman.Publishing.Platforms.Bazar
{
    public class BazarbgConfig : PlatformConfig
    {
    }

    public interface IBazarbgProvider
    {
    }

    public class BazarPlatform : BasePlatform, IBazarbgProvider
    {
        public BazarPlatform()
        {
            Platform = Platform.Bazar;
        }
    }
}