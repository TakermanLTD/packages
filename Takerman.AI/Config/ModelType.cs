using System.ComponentModel;

namespace Takerman.AI.Config
{
    public enum ModelType
    {
        /// <summary>
        /// Generic https://huggingface.co/mistralai/Mixtral-8x7B-Instruct-v0.1
        /// </summary>
        [Description("mistralai/Mixtral-8x7B-Instruct-v0.1")]
        Mixtral7B,

        /// <summary>
        /// Generic https://huggingface.co/google/gemma-7b
        /// </summary>
        [Description("google/gemma-7b")]
        Gemma7B,

        /// <summary>
        /// Generic https://huggingface.co/meta-llama/Llama-2-7b
        /// </summary>
        // [Description("meta-llama/Llama-2-7b")]
        // LLama7B,

        /// <summary>
        /// Text-toImage https://huggingface.co/dreamlike-art/dreamlike-diffusion-1.0
        /// </summary>
        [Description("dreamlike-art/dreamlike-diffusion-1.0")]
        DreamLikeArt,

        /// <summary>
        /// Deep estimation https://huggingface.co/vinvino02/glpn-nyu
        /// </summary>
        // [Description("vinvino02/glpn-nyu")]
        // VinVino,

        /// <summary>
        /// Object detection https://huggingface.co/facebook/detr-resnet-50
        /// </summary>
        // [Description("facebook/detr-resnet-50")]
        // DetrResnet,

        /// <summary>
        /// Text-to-Image https://huggingface.co/black-forest-labs/FLUX.1-dev
        /// </summary>
        [Description("black-forest-labs/FLUX.1-dev")]
        Flux,

        /// <summary>
        /// Image-to-Video https://huggingface.co/stabilityai/stable-video-diffusion-img2vid-xt
        /// </summary>
        // [Description("stabilityai/stable-video-diffusion-img2vid-xt")]
        // StabilityAI,

        /// <summary>
        /// Translation https://huggingface.co/google-t5/t5-large
        /// </summary>
        // [Description("google-t5/t5-large")]
        // GoogleTranslate,

        /// <summary>
        /// Text-to-Audio https://huggingface.co/facebook/musicgen-small
        /// </summary>
        // [Description("facebook/musicgen-small")]
        // MusicGenSmall,

        /// <summary>
        /// Text-to-Audio https://huggingface.co/facebook/musicgen-medium
        /// </summary>
        // [Description("facebook/musicgen-medium")]
        // MusicGenMedium,

        /// <summary>
        /// Text-to-Audio https://huggingface.co/facebook/musicgen-large
        /// </summary>
        // [Description("facebook/musicgen-large")]
        // MusicGenLarge
    }
}