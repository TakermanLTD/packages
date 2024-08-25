using Newtonsoft.Json;

namespace Takerman.AI.DTOs
{
    public class TextOutput
    {
        [JsonProperty("generated_text")]
        public string generated_text { get; set; }
    }
}