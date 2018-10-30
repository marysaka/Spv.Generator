using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction GroupAsyncCopy(uint ResultType, uint Execution, uint Destination, uint Source, uint NumElements, uint Stride, uint Event)
        {
            return EmitOperationWithResulType(Op.OpGroupAsyncCopy, ResultType, Execution, Destination, Source, NumElements, Stride, Event);
        }

        public Instruction GroupWaitEvents(uint Execution, uint NumElements, uint EventsList)
        {
            return EmitCode(CreateInstruction(Op.OpGroupWaitEvents, Execution, NumElements, EventsList));
        }

        public Instruction GroupAll(uint ResultType, uint Execution, uint Predicate)
        {
            return EmitOperationWithResulType(Op.OpGroupAll, ResultType, Execution, Predicate);
        }

        public Instruction GroupAny(uint ResultType, uint Execution, uint Predicate)
        {
            return EmitOperationWithResulType(Op.OpGroupAny, ResultType, Execution, Predicate);
        }

        public Instruction GroupBroadcast(uint ResultType, uint Execution, uint Value, uint LocalId)
        {
            return EmitOperationWithResulType(Op.OpGroupBroadcast, ResultType, Execution, Value, LocalId);
        }

        public Instruction GroupIAdd(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupIAdd, ResultType, Execution, Operation, X);
        }

        public Instruction GroupFAdd(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupFAdd, ResultType, Execution, Operation, X);
        }

        public Instruction GroupFMin(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMin, ResultType, Execution, Operation, X);
        }

        public Instruction GroupUMin(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMin, ResultType, Execution, Operation, X);
        }

        public Instruction GroupSMin(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMin, ResultType, Execution, Operation, X);
        }

        public Instruction GroupFMax(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMax, ResultType, Execution, Operation, X);
        }

        public Instruction GroupUMax(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMax, ResultType, Execution, Operation, X);
        }

        public Instruction GroupSMax(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMax, ResultType, Execution, Operation, X);
        }

        public Instruction SubgroupBallotKHR(uint ResultType, uint Predicate)
        {
            return EmitOperationWithResulType(Op.OpSubgroupBallotKHR, ResultType, Predicate);
        }

        public Instruction SubgroupFirstInvocationKHR(uint ResultType, uint Value)
        {
            return EmitOperationWithResulType(Op.OpSubgroupFirstInvocationKHR, ResultType, Value);
        }

        public Instruction SubgroupReadInvocationKHR(uint ResultType, uint Value, uint Index)
        {
            return EmitOperationWithResulType(Op.OpSubgroupReadInvocationKHR, ResultType, Value, Index);
        }

        // FIXME: Those AMD instructions are to be announced, do we keep them?
        public Instruction GroupIAddNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupIAddNonUniformAMD, ResultType, Execution, Operation, X);
        }

        public Instruction GroupFAddNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupFAddNonUniformAMD, ResultType, Execution, Operation, X);
        }

        public Instruction GroupFMinNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMinNonUniformAMD, ResultType, Execution, Operation, X);
        }

        public Instruction GroupUMinNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMinNonUniformAMD, ResultType, Execution, Operation, X);
        }

        public Instruction GroupSMinNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMinNonUniformAMD, ResultType, Execution, Operation, X);
        }

        public Instruction GroupFMaxNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMaxNonUniformAMD, ResultType, Execution, Operation, X);
        }

        public Instruction GroupUMaxNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMaxNonUniformAMD, ResultType, Execution, Operation, X);
        }

        public Instruction GroupSMaxNonUniformAMD(uint ResultType, uint Execution, uint Operation, uint X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMaxNonUniformAMD, ResultType, Execution, Operation, X);
        }
    }
}
