using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Takerman.AI
{
    public class AIManager(ILogger _logger) : IAIManager
    {
        private const string API_KEY = "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";

        public async Task<byte[]> GetMediaAnswer(string question, AIModel model, string outputFileName)
        {
            var requestBody = new
            {
                inputs = question,
                parameters = new
                {
                    max_new_tokens = 250,
                    temperature = 0.7,
                    top_p = 0.9,
                    repetition_penalty = 1.0,
                    width = 512,
                    height = 512,
                    num_inference_steps = 50,
                    guidance_scale = 7.5,
                    num_images_per_prompt = 1,
                },
                options = new
                {
                    wait_for_model = true,
                    use_cache = false
                }
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", API_KEY);
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("https://api-inference.huggingface.co/models/" + model.GetEnumDescription(), content);
                if (response.IsSuccessStatusCode)
                {
                    var imageData = await response.Content.ReadAsByteArrayAsync();
                    File.WriteAllBytes(outputFileName, imageData);
                    return imageData;
                }
                else
                {
                    var error = "Failed to generate media: " + response.StatusCode;
                    _logger.LogError(error);
                    Console.WriteLine(error);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                _logger.LogError(ex, "An error occured when requesting model: " + message);
                Console.WriteLine(message);
            }

            return null;
        }

        public async Task<string> GetTextAnswer(string question, AIModel model)
        {
            var requestBody = new
            {
                inputs = question,
                parameters = new
                {
                    max_new_tokens = 250,
                    temperature = 0.7,
                    top_p = 0.9,
                    repetition_penalty = 1.0
                },
                options = new
                {
                    wait_for_model = true,
                    use_cache = false
                }
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", API_KEY);
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("https://api-inference.huggingface.co/models/" + model.GetEnumDescription(), content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    var error = "Failed to generate output: " + response.StatusCode;
                    _logger.LogError(error);
                    Console.WriteLine(error);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                _logger.LogError(ex, "An error occured when requesting model: " + message);
                Console.WriteLine(message);
            }

            return null;
        }
    }
}