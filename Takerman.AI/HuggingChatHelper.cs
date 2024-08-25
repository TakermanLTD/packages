using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Takerman.AI.Config;

namespace Takerman.AI
{
    public class HuggingChatHelper
    {
        private const string HUGGING_FACE_TOKEN = "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";
        private const string HUGGING_FACE_API = "https://api-inference.huggingface.co/models/";

        public static async Task<byte[]> GetTextToMediaResultAsync(string question, ModelType model)
        {
            var requestBody = new
            {
                inputs = question,
                parameters = ParametersConfig.Get(model),
                options = new
                {
                    wait_for_model = true,
                    use_cache = false
                }
            };

            var client = new HttpClient
            {
                BaseAddress = new Uri(HUGGING_FACE_API)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HUGGING_FACE_TOKEN);
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(model.GetEnumDescription(), content);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsByteArrayAsync();
                else
                    throw new Exception("Failed to generate media: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                var message = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(message, ex);
            }
        }

        public static async Task<string> GetTextResultAsync(string question, ModelType model)
        {
            var requestBody = new
            {
                inputs = question,
                parameters = ParametersConfig.Get(model),
                options = new
                {
                    wait_for_model = true,
                    use_cache = false
                }
            };

            var client = new HttpClient
            {
                BaseAddress = new Uri(HUGGING_FACE_API)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HUGGING_FACE_TOKEN);
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(model.GetEnumDescription(), content);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception("Failed to generate media: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                var message = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(message, ex);
            }
        }
    }
}