namespace Takerman.AI.HuggingChat
{
    public class HuggingChatParams
    {
        public static dynamic Get(HuggingChatModel modelType)
        {
            dynamic parameters;
            switch (modelType)
            {
                case HuggingChatModel.Mixtral7B:
                case HuggingChatModel.Gemma7B:
                    return new
                    {
                        max_new_tokens = 250,
                        temperature = 0.7,
                        top_p = 0.9,
                        repetition_penalty = 1.0
                    };

                case HuggingChatModel.DreamLikeArt:
                    return new
                    {
                        max_new_tokens = 250,
                        temperature = 0.7,
                        top_p = 0.9,
                        repetition_penalty = 1.0,
                        width = 1024,
                        height = 512,
                        num_inference_steps = 50,
                        guidance_scale = 7.5,
                        num_images_per_prompt = 1
                    };

                case HuggingChatModel.Flux:
                    return new
                    {
                        width = 1024,
                        height = 512,
                        guidance_scale = 3.5,
                        num_inference_steps = 28,
                        num_images_per_prompt = 1
                    };
            }

            return null;
        }
    }
}