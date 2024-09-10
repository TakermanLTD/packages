namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationVideoDto : IPublication
    {
        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Video;

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostName { get; set; }

        public string PostDescription { get; set; }

        public byte[] PostVideo { get; set; }
    }
}