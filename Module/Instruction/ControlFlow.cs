using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Phi(uint ResultType, params uint[] PairIdRefIdRef)
        {
            return EmitOperationWithResulType(Op.OpPhi, ResultType, PairIdRefIdRef);
        }

        public Instruction LoopMerge(uint MergeBlock, uint ContinueTarget, LoopControlMask LoopControl)
        {
            return EmitCode(CreateInstruction(Op.OpLoopMerge, MergeBlock, ContinueTarget, (uint)LoopControl));
        }

        public Instruction SelectionMerge(uint MergeBlock, SelectionControlMask SelectionControl)
        {
            return EmitCode(CreateInstruction(Op.OpSelectionMerge, MergeBlock, (uint)SelectionControl));
        }

        public Instruction Label()
        {
            return EmitCode(CreateInstruction(Op.OpLabel).SetResultTypeId(AllocateId()));
        }

        public Instruction Branch(uint TargetLabel)
        {
            return EmitCode(CreateInstruction(Op.OpBranch, TargetLabel));
        }

        public Instruction BranchConditional(uint Condition, uint TrueLabel, uint FalseLabel, params uint[] BranchWeights)
        {
            Instruction BranchConditional = CreateInstruction(Op.OpBranchConditional, Condition, TrueLabel, FalseLabel);

            BranchConditional.PushOperand(BranchWeights);

            return BranchConditional;
        }

        public Instruction Switch(uint Selector, uint Default, params uint[] Target)
        {
            Instruction Switch = CreateInstruction(Op.OpSwitch, Selector, Default);

            Switch.PushOperand(Target);

            return Switch;
        }

        public Instruction Kill()
        {
            return EmitCode(CreateInstruction(Op.OpKill));
        }

        public Instruction Return()
        {
            return EmitCode(CreateInstruction(Op.OpReturn));
        }

        public Instruction ReturnValue(uint Value)
        {
            return EmitCode(CreateInstruction(Op.OpReturnValue, Value));
        }

        public Instruction Unreachable()
        {
            return EmitCode(CreateInstruction(Op.OpUnreachable));
        }

        public Instruction LifetimeStart(uint Pointer, uint Size)
        {
            return EmitCode(CreateInstruction(Op.OpLifetimeStart, Pointer, Size));
        }

        public Instruction LifetimeStop(uint Pointer, uint Size)
        {
            return EmitCode(CreateInstruction(Op.OpLifetimeStop, Pointer, Size));
        }
    }
}
