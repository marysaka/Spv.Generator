using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Nop()
        {
            return EmitCode(CreateInstruction(Op.OpNop));
        }

        public Instruction Undef(Instruction ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpUndef, ResultType));
        }
    }
}
