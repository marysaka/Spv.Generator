using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction DPdx(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpDPdx, ResultType, P.ResultTypeId);
        }

        public Instruction DPdy(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpDPdy, ResultType, P.ResultTypeId);
        }

        public Instruction Fwidth(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpFwidth, ResultType, P.ResultTypeId);
        }

        public Instruction DPdxFine(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpDPdxFine, ResultType, P.ResultTypeId);
        }

        public Instruction DPdyFine(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpDPdyFine, ResultType, P.ResultTypeId);
        }

        public Instruction FwidthFine(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpFwidthFine, ResultType, P.ResultTypeId);
        }

        public Instruction DPdxCoarse(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpDPdxCoarse, ResultType, P.ResultTypeId);
        }

        public Instruction DPdyCoarse(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpDPdyCoarse, ResultType, P.ResultTypeId);
        }

        public Instruction FwidthCoarse(Instruction ResultType, Instruction P)
        {
            return EmitOperationWithResulType(Op.OpFwidthCoarse, ResultType, P.ResultTypeId);
        }

    }
}
