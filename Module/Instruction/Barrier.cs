using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ControlBarrier(uint ExecutionScope, uint MemoryScope, uint Semantics)
        {
            return EmitCode(CreateInstruction(Op.OpControlBarrier, ExecutionScope, MemoryScope, Semantics));
        }

        public Instruction MemoryBarrier(uint ExecutionScope, uint Semantics)
        {
            return EmitCode(CreateInstruction(Op.OpMemoryBarrier, ExecutionScope, Semantics));
        }
    }
}
