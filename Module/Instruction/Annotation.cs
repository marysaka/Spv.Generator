using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction EmitAnnotation(Instruction Instruction)
        {
            Annotations.Add(Instruction);
            return Instruction;
        }

        // TODO: All decorations opcodes
    }
}
