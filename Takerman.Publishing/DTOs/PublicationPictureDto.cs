namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationPictureDto : IPublication
    {
        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Picture;

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostDescription { get; set; }

        public IEnumerable<byte[]> PostPictures { get; set; }
    }
}