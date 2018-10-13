using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction CreateFunction(Instruction ResultType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            Instruction Function = CreateInstruction(Op.OpFunction);

            Function.SetResultTypeId(AllocateId());
            Function.SetTypeId(ResultType);
            Function.PushOperand((uint)FunctionControl);
            Function.PushOperandTypeId(FunctionType);

            return Function;
        }

        public Instruction Function(Instruction ResultType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            return EmitCode(CreateFunction(ResultType, FunctionControl, FunctionType));
        }

        public Instruction FunctionParameter(uint ResultType)
        {
            return EmitCode(CreateInstruction(Op.OpFunctionParameter).SetTypeId(ResultType).SetResultTypeId(AllocateId()));
        }

        public Instruction FunctionEnd()
        {
            return EmitCode(CreateInstruction(Op.OpFunctionEnd));
        }

        public Instruction FunctionCall(uint ResultType, uint Function, params uint[] Arguments)
        {
            Instruction FunctionCall = CreateInstruction(Op.OpFunctionCall, Function);

            FunctionCall.SetResultTypeId(AllocateId());
            FunctionCall.SetTypeId(ResultType);
            FunctionCall.PushOperand(Arguments);

            return EmitCode(FunctionCall);
        }
    }
}
