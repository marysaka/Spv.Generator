using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction CreateFunction(Instruction ResultType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            Instruction Function = CreateOperationWithResulType(Op.OpFunction, ResultType);

            Function.PushOperand((uint)FunctionControl);
            Function.PushOperandResultTypeId(FunctionType);

            return Function;
        }

        public Instruction Function(Instruction ResultType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            return EmitCode(CreateFunction(ResultType, FunctionControl, FunctionType));
        }

        public Instruction FunctionParameter(Instruction ResultType)
        {
            return EmitCode(CreateInstruction(Op.OpFunctionParameter).SetTypeId(ResultType).SetResultTypeId(AllocateId()));
        }

        public Instruction FunctionEnd()
        {
            return EmitCode(CreateInstruction(Op.OpFunctionEnd));
        }

        public Instruction FunctionCall(Instruction ResultType, Instruction Function, params Instruction[] Arguments)
        {
            Instruction FunctionCall = CreateOperationWithResulType(Op.OpFunctionCall, ResultType, Function.ResultTypeId);
            FunctionCall.PushOperandResultTypeId(Arguments);

            return EmitCode(FunctionCall);
        }
    }
}
