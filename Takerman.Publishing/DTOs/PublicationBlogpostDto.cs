namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationBlogpostDto
    {
        public virtual int Id { get; set; }

        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Blogpost;

        public List<Platform> Platforms { get; set; } = [];

        public string PostName { get; set; }

        public string PostDescription { get; set; }
    }
}