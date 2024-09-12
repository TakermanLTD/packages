namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationTweetDto
    {
        public virtual int Id { get; set; }

        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Tweet;

        public List<Platform> Platforms { get; set; } = [];

        public string PostDescription { get; set; }
    }
}