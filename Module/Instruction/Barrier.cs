using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ControlBarrier(Instruction ExecutionScope, Instruction MemoryScope, Instruction Semantics)
        {
            return EmitCode(CreateInstruction(Op.OpControlBarrier, ExecutionScope.ResultTypeId, MemoryScope.ResultTypeId, Semantics.ResultTypeId));
        }

        public Instruction MemoryBarrier(Instruction ExecutionScope, Instruction Semantics)
        {
            return EmitCode(CreateInstruction(Op.OpMemoryBarrier, ExecutionScope.ResultTypeId, Semantics.ResultTypeId));
        }
    }
}
