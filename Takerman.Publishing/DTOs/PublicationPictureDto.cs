namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationPictureDto
    {
        public virtual int Id { get; set; }

        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Picture;

        public List<Platform> Platforms { get; set; } = [];

        public string PostDescription { get; set; }

        public IEnumerable<byte[]> PostPictures { get; set; }
    }
}