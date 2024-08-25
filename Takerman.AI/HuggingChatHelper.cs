﻿using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Takerman.AI.Config;
using Takerman.AI.DTOs;

namespace Takerman.AI
{
    public class HuggingChatHelper
    {
        private const string HUGGING_FACE_TOKEN = "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";
        private const string HUGGING_FACE_API = "https://api-inference.huggingface.co/models/";

        public static async Task<byte[]> GetResultAsync(string question, ModelType model)
        {
            var response = await GetResponse(question, model);
            return await response.ReadAsByteArrayAsync();
        }

        public static async Task<string> GetTextResultAsync(string question, ModelType model)
        {
            var response = await GetResponse(question, model);
            var text = await response.ReadAsStringAsync();
            var result = string.Join(" ", JsonSerializer.Deserialize<IEnumerable<TextOutput>>(text).Select(x => x.generated_text));
            return result;
        }

        private static async Task<HttpContent> GetResponse(string question, ModelType model)
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
                BaseAddress = new Uri(HUGGING_FACE_API),
                Timeout = TimeSpan.FromHours(3),
                MaxResponseContentBufferSize = 2147483647
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HUGGING_FACE_TOKEN);
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(model.GetEnumDescription(), content);

                if (response.IsSuccessStatusCode)
                {
                    return response.Content;
                }
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