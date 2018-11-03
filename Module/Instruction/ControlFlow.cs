using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Phi(Instruction ResultType, params Instruction[] PairIdRefIdRef)
        {
            Instruction Phi = CreateOperationWithResulType(Op.OpPhi, ResultType);
            Phi.PushOperandResultTypeId(PairIdRefIdRef);

            return EmitCode(Phi);
        }

        public Instruction LoopMerge(Instruction MergeBlock, Instruction ContinueTarget, LoopControlMask LoopControl)
        {
            return EmitCode(CreateInstruction(Op.OpLoopMerge, MergeBlock.ResultTypeId, ContinueTarget.ResultTypeId, (uint)LoopControl));
        }

        public Instruction SelectionMerge(Instruction MergeBlock, SelectionControlMask SelectionControl)
        {
            return EmitCode(CreateInstruction(Op.OpSelectionMerge, MergeBlock.ResultTypeId, (uint)SelectionControl));
        }

        public Instruction Label()
        {
            return EmitCode(CreateInstruction(Op.OpLabel).SetResultTypeId(AllocateId()));
        }

        public Instruction Branch(Instruction TargetLabel)
        {
            return EmitCode(CreateInstruction(Op.OpBranch, TargetLabel.ResultTypeId));
        }

        public Instruction BranchConditional(Instruction Condition, Instruction TrueLabel, Instruction FalseLabel, params uint[] BranchWeights)
        {
            Instruction BranchConditional = CreateInstruction(Op.OpBranchConditional, Condition.ResultTypeId, TrueLabel.ResultTypeId, FalseLabel.ResultTypeId);

            BranchConditional.PushOperand(BranchWeights);

            return BranchConditional;
        }

        public Instruction Switch(Instruction Selector, Instruction Default, params uint[] Target)
        {
            Instruction Switch = CreateInstruction(Op.OpSwitch, Selector.ResultTypeId, Default.ResultTypeId);

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

        public Instruction ReturnValue(Instruction Value)
        {
            return EmitCode(CreateInstruction(Op.OpReturnValue, Value.ResultTypeId));
        }

        public Instruction Unreachable()
        {
            return EmitCode(CreateInstruction(Op.OpUnreachable));
        }

        public Instruction LifetimeStart(Instruction Pointer, Instruction Size)
        {
            return EmitCode(CreateInstruction(Op.OpLifetimeStart, Pointer.ResultTypeId, Size.ResultTypeId));
        }

        public Instruction LifetimeStop(Instruction Pointer, Instruction Size)
        {
            return EmitCode(CreateInstruction(Op.OpLifetimeStop, Pointer.ResultTypeId, Size.ResultTypeId));
        }
    }
}
