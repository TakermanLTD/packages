namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationShortDto
    {
        public virtual int Id { get; set; }

        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Short;

        public List<Platform> Platforms { get; set; } = [];

        public string PostDescription { get; set; }

        public byte[] PostShort { get; set; }
    }
}