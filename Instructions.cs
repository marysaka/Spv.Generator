using System.Collections.Generic;

using static Spv.Specification;


namespace Spv.Generator
{
    public static class Instructions
    {
        public static Instruction CreateInstruction(Op Opcode, params uint[] Words)
        {
            return new Instruction(Opcode, new List<uint>(Words));
        }

        public static Instruction Label()
        {
            return CreateInstruction(Op.OpLabel);
        }

        public static Instruction Return()
        {
            return CreateInstruction(Op.OpReturn);
        }
    }
}
