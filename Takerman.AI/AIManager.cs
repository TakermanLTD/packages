using HuggingFace;

namespace Takerman.AI
{
    public class AIManager : IAIManager
    {
        public async Task<string> GetAnswer(string question, AIModel model)
        {
            try
            {
                using var client = new HttpClient();
                var api = new HuggingFaceApi("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", client);
                var response = await api.GenerateTextAsync(
                    model.GetEnumDescription(),
                    new GenerateTextRequest
                    {
                        Inputs = question,
                        Parameters = new GenerateTextRequestParameters
                        {
                            Max_new_tokens = 250,
                            Return_full_text = true
                        },
                        Options = new GenerateTextRequestOptions
                        {
                            Use_cache = true,
                            Wait_for_model = true
                        }
                    });

                var result = string.Join(" ", response.Select(x => x.Generated_text));

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null ? string.Empty : ex.InnerException.Message);
                throw;
            }
        }
    }
}