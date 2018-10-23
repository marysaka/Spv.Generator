using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction DPdx(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpDPdx, ResultType, P);
        }

        public Instruction DPdy(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpDPdy, ResultType, P);
        }

        public Instruction Fwidth(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpFwidth, ResultType, P);
        }

        public Instruction DPdxFine(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpDPdxFine, ResultType, P);
        }

        public Instruction DPdyFine(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpDPdyFine, ResultType, P);
        }

        public Instruction FwidthFine(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpFwidthFine, ResultType, P);
        }

        public Instruction DPdxCoarse(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpDPdxCoarse, ResultType, P);
        }

        public Instruction DPdyCoarse(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpDPdyCoarse, ResultType, P);
        }

        public Instruction FwidthCoarse(uint ResultType, uint P)
        {
            return EmitOperationWithResulType(Op.OpFwidthCoarse, ResultType, P);
        }

    }
}
