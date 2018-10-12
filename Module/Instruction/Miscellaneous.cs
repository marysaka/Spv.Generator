using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Nop()
        {
            return EmitCode(CreateInstruction(Op.OpNop));
        }

        public Instruction Undef(uint IdResultType)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpUndef).SetTypeId(IdResultType), true);
        }
    }
}
