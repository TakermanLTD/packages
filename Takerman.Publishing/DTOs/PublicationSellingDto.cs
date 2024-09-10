namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationSellingDto : IPublication
    {
        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Selling;

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostName { get; set; }

        public string PostDescription { get; set; }

        public decimal PostPrice { get; set; }

        public IEnumerable<byte[]> PostPictures { get; set; }

        public IEnumerable<byte[]> PostVideos { get; set; }
    }
}