using System.ComponentModel;

namespace Takerman.AI.Local
{
    public enum OllamaModel
    {
        [Description("phi3:mini")]
        Phi3Mini,

        [Description("codellama")]
        Codelamma7b,

        [Description("chanwit/flux-7b")]
        Flux7b
    }
}