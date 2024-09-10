namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationBlogpostDto : IPublication
    {
        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Blogpost;

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostName { get; set; }

        public string PostDescription { get; set; }
    }
}