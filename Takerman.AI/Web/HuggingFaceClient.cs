using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Takerman.AI.Config;

namespace Takerman.AI.Web
{
    public class HuggingFaceClient : HttpClient
    {
        private const string HUGGING_FACE_TOKEN = "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";
        private readonly ILogger<HuggingFaceClient> _logger;

        public HuggingFaceClient(ILogger<HuggingFaceClient> logger)
        {
            _logger = logger;
            BaseAddress = new Uri("https://api-inference.huggingface.co/models/");
        }

        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HUGGING_FACE_TOKEN);
            return base.SendAsync(request, cancellationToken);
        }

        public async Task<byte[]> GetTextToMediaResultAsync(string question, ModelType model)
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

            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HUGGING_FACE_TOKEN);
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await PostAsync(model.GetEnumDescription(), content);
                if (response.IsSuccessStatusCode)
                {
                    var imageData = await response.Content.ReadAsByteArrayAsync();
                    return imageData;
                }
                else
                {
                    _logger.LogError("Failed to generate media: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                _logger.LogError(ex, "An error occured when requesting model: " + message);
            }

            return null;
        }

        public async Task<string> GetTextResultAsync(string question, ModelType model)
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

            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HUGGING_FACE_TOKEN);
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await PostAsync(model.GetEnumDescription(), content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    var error = "Failed to generate output: " + response.StatusCode;
                    _logger.LogError(error);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message + (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                _logger.LogError(ex, "An error occured when requesting model: " + message);
            }

            return string.Empty;
        }
    }
}