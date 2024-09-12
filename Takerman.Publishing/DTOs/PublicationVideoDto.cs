namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationVideoDto
    {
        public virtual int Id { get; set; }

        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Video;

        public List<Platform> Platforms { get; set; } = [];

        public string PostName { get; set; }

        public string PostDescription { get; set; }

        public byte[] PostVideo { get; set; }
    }
}