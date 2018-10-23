using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction EmitVertex()
        {
            return EmitCode(CreateInstruction(Op.OpEmitVertex));
        }

        public Instruction EndPrimitive()
        {
            return EmitCode(CreateInstruction(Op.OpEndPrimitive));
        }

        public Instruction EmitStreamVertex(uint Stream)
        {
            return EmitCode(CreateInstruction(Op.OpEmitStreamVertex, Stream));
        }

        public Instruction EndStreamPrimitive(uint Stream)
        {
            return EmitCode(CreateInstruction(Op.OpEndStreamPrimitive, Stream));
        }
    }
}
