namespace Takerman.Publishing.Platforms.FreeMusicArchive
{
    public class FmaSongDto
    {
        public string Title { get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public Stream Data { get; set; }
    }
}