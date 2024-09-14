﻿namespace Takerman.Publishing.Platforms.Tmdb
{
    public class TmdbConfig : PlatformConfig
    {
    }

    public interface ITmdbProvider
    {
    }

    public class TmdbPlatform : BasePlatform, ITmdbProvider
    {
        public TmdbPlatform()
        {
            Platform = Platform.Tmdb;
        }
    }
}