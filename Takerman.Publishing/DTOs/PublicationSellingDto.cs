namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationSellingDto
    {
        public virtual int Id { get; set; }

        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Selling;

        public List<Platform> Platforms { get; set; } = [];

        public string PostName { get; set; }

        public string PostDescription { get; set; }

        public decimal PostPrice { get; set; }

        public IEnumerable<byte[]> PostPictures { get; set; }

        public IEnumerable<byte[]> PostVideos { get; set; }
    }
}