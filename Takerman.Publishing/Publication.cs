namespace Takerman.Publishing
{
    public class Publication
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public IEnumerable<BaseProvider> Providers { get; set; } = [];

        public IEnumerable<string> Pictures { get; set; } = [];
    }
}