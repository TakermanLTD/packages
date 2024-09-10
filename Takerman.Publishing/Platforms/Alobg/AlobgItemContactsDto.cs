using System.Text.Json.Serialization;

namespace Takerman.Publishing.Platforms.Alobg
{
    public class AlobgItemContactsDto
    {
        [JsonPropertyName("hide_name")]
        public bool HideName { get; set; } = false;

        [JsonPropertyName("hide_location")]
        public bool HideLocation { get; set; } = false;

        [JsonPropertyName("hide_address")]
        public bool HideAddress { get; set; } = true;

        [JsonPropertyName("hide_website")]
        public bool HideWebsite { get; set; } = false;

        [JsonPropertyName("phones")]
        public IEnumerable<string> Phones { get; set; } = ["0897887191"];

        [JsonPropertyName("email")]
        public string Email { get; set; } = "tanyo@takerman.net";
    }
}