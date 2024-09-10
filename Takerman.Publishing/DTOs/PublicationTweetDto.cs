namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationTweetDto : IPublication
    {
        public int ProjectId { get; set; }

        public PostType Type { get; } = PostType.Tweet;

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostDescription { get; set; }
    }
}