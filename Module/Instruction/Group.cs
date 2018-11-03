using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction GroupAsyncCopy(Instruction ResultType, Instruction Execution, Instruction Destination, Instruction Source, Instruction NumElements, Instruction Stride, Instruction Event)
        {
            return EmitOperationWithResulType(Op.OpGroupAsyncCopy, ResultType, Execution.ResultTypeId, Destination.ResultTypeId, Source.ResultTypeId, NumElements.ResultTypeId, Stride.ResultTypeId, Event.ResultTypeId);
        }

        public Instruction GroupWaitEvents(Instruction Execution, Instruction NumElements, Instruction EventsList)
        {
            return EmitCode(CreateInstruction(Op.OpGroupWaitEvents, Execution.ResultTypeId, NumElements.ResultTypeId, EventsList.ResultTypeId));
        }

        public Instruction GroupAll(Instruction ResultType, Instruction Execution, Instruction Predicate)
        {
            return EmitOperationWithResulType(Op.OpGroupAll, ResultType, Execution.ResultTypeId, Predicate.ResultTypeId);
        }

        public Instruction GroupAny(Instruction ResultType, Instruction Execution, Instruction Predicate)
        {
            return EmitOperationWithResulType(Op.OpGroupAny, ResultType, Execution.ResultTypeId, Predicate.ResultTypeId);
        }

        public Instruction GroupBroadcast(Instruction ResultType, uint Execution, uint Value, uint LocalId)
        {
            return EmitOperationWithResulType(Op.OpGroupBroadcast, ResultType, Execution, Value, LocalId);
        }

        public Instruction GroupIAdd(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupIAdd, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupFAdd(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupFAdd, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupFMin(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMin, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupUMin(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMin, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupSMin(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMin, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupFMax(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMax, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupUMax(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMax, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupSMax(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMax, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction SubgroupBallotKHR(Instruction ResultType, uint Predicate)
        {
            return EmitOperationWithResulType(Op.OpSubgroupBallotKHR, ResultType, Predicate);
        }

        public Instruction SubgroupFirstInvocationKHR(Instruction ResultType, uint Value)
        {
            return EmitOperationWithResulType(Op.OpSubgroupFirstInvocationKHR, ResultType, Value);
        }

        public Instruction SubgroupReadInvocationKHR(Instruction ResultType, uint Value, uint Index)
        {
            return EmitOperationWithResulType(Op.OpSubgroupReadInvocationKHR, ResultType, Value, Index);
        }

        // FIXME: Those AMD instructions are to be announced, do we keep them?
        public Instruction GroupIAddNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupIAddNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupFAddNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupFAddNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupFMinNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMinNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupUMinNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMinNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupSMinNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMinNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupFMaxNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupFMaxNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupUMaxNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupUMaxNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }

        public Instruction GroupSMaxNonUniformAMD(Instruction ResultType, Instruction Execution, GroupOperation Operation, Instruction X)
        {
            return EmitOperationWithResulType(Op.OpGroupSMaxNonUniformAMD, ResultType, Execution.ResultTypeId, (uint)Operation, X.ResultTypeId);
        }
    }
}
