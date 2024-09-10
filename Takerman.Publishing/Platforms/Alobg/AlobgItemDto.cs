using System.Text.Json.Serialization;

namespace Takerman.Publishing.Platforms.Alobg
{
    public class AlobgItemDto
    {
        [JsonPropertyName("_comment")]
        private string Comment { get; set; } = "Електроника » Други";

        [JsonPropertyName("out_id")]
        private string OutId { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("subcat_id")]
        private string SubcatId { get; set; } = "355";

        [JsonPropertyName("region_name")]
        private string RegionName { get; set; } = "Пловдив";

        [JsonPropertyName("location_name")]
        private string LocationName { get; set; } = "Пловдив";

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("currency")]
        private string Currency { get; set; } = "EUR";

        [JsonPropertyName("images")]
        public IEnumerable<string> Images { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("desc")]
        public string Description { get; set; }

        [JsonPropertyName("contacts")]
        public AlobgItemContactsDto Contacts { get; set; }
    }
}