using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        // TODO: implements all image instructions
        public Instruction SampledImage(uint ResultType, uint Image, uint Sampler)
        {
            return EmitOperationWithResulType(Op.OpSampledImage, ResultType, Image, Sampler);
        }
    }
}
