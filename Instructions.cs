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

        public static Instruction Function(Instruction ReturnType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            Instruction Result = CreateInstruction(Op.OpFunction);

            Result.SetTypeId(ReturnType);
            Result.PushOperand((uint)FunctionControl);
            Result.PushOperandTypeId(FunctionType);

            return Result;
        }

        public static Instruction Label()
        {
            return CreateInstruction(Op.OpLabel);
        }

        public static Instruction FunctionEnd()
        {
            return CreateInstruction(Op.OpFunctionEnd);
        }

        public static Instruction Return()
        {
            return CreateInstruction(Op.OpReturn);
        }
    }
}
