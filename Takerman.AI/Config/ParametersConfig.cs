namespace Takerman.AI.Config
{
    public class ParametersConfig
    {
        public static dynamic Get(ModelType modelType)
        {
            dynamic parameters;
            switch (modelType)
            {
                case ModelType.Mixtral7B:
                case ModelType.Gemma7B:
                    return new
                    {
                        max_new_tokens = 250,
                        temperature = 0.7,
                        top_p = 0.9,
                        repetition_penalty = 1.0
                    };

                case ModelType.DreamLikeArt:
                    return new
                    {
                        max_new_tokens = 250,
                        temperature = 0.7,
                        top_p = 0.9,
                        repetition_penalty = 1.0,
                        width = 512,
                        height = 512,
                        num_inference_steps = 50,
                        guidance_scale = 7.5,
                        num_images_per_prompt = 1
                    };
            }

            return null;
        }
    }
}