using System;
using System.Collections.Generic;
using System.Text;

using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Function(Instruction ReturnType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            Instruction Function = CreateInstruction(Op.OpFunction);

            Function.SetResultTypeId(AllocateId());
            Function.SetTypeId(ReturnType);
            Function.PushOperand((uint)FunctionControl);
            Function.PushOperandTypeId(FunctionType);

            return EmitCode(Function);
        }

        public Instruction FunctionParameter(uint ResultType)
        {
            return EmitCode(CreateInstruction(Op.OpFunctionParameter).SetTypeId(ResultType).SetResultTypeId(AllocateId()));
        }

        public Instruction FunctionEnd()
        {
            return EmitCode(CreateInstruction(Op.OpFunctionEnd));
        }
    }
}
