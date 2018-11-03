using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction EnqueueMarker(Instruction ResultType, Instruction Queue, Instruction NumEvents, Instruction WaitEvents, Instruction RetEvent)
        {
            return EmitOperationWithResulType(Op.OpEnqueueMarker, ResultType, Queue.ResultTypeId, NumEvents.ResultTypeId, WaitEvents.ResultTypeId, RetEvent.ResultTypeId);
        }

        public Instruction EnqueueKernel(Instruction ResultType, Instruction Queue, Instruction Flags, Instruction NDRange, Instruction NumEvents, Instruction WaitEvents, Instruction RetEvent, Instruction Invoke, Instruction Param, Instruction ParamSize, Instruction ParamAlign, params Instruction[] LocalSize)
        {
            Instruction EnqueueKernel = EmitOperationWithResulType(Op.OpEnqueueKernel, ResultType, Queue.ResultTypeId, Flags.ResultTypeId, NDRange.ResultTypeId, NumEvents.ResultTypeId, WaitEvents.ResultTypeId, RetEvent.ResultTypeId, Invoke.ResultTypeId, Param.ResultTypeId, ParamSize.ResultTypeId, ParamAlign.ResultTypeId);
            EnqueueKernel.PushOperandResultTypeId(LocalSize);

            return EnqueueKernel;
        }

        public Instruction GetKernelNDrangeSubGroupCount(Instruction ResultType, Instruction NDRange, Instruction Invoke, Instruction Param, Instruction ParamSize, Instruction ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelNDrangeSubGroupCount, ResultType, NDRange.ResultTypeId, Invoke.ResultTypeId, Param.ResultTypeId, ParamSize.ResultTypeId, ParamAlign.ResultTypeId);
        }

        public Instruction GetKernelNDrangeMaxSubGroupSize(Instruction ResultType, Instruction NDRange, Instruction Invoke, Instruction Param, Instruction ParamSize, Instruction ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelNDrangeMaxSubGroupSize, ResultType, NDRange.ResultTypeId, Invoke.ResultTypeId, Param.ResultTypeId, ParamSize.ResultTypeId, ParamAlign.ResultTypeId);
        }

        public Instruction GetKernelWorkGroupSize(Instruction ResultType, Instruction Invoke, Instruction Param, Instruction ParamSize, Instruction ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelWorkGroupSize, ResultType, Invoke.ResultTypeId, Param.ResultTypeId, ParamSize.ResultTypeId, ParamAlign.ResultTypeId);
        }

        public Instruction GetKernelPreferredWorkGroupSizeMultiple(Instruction ResultType, Instruction Invoke, Instruction Param, Instruction ParamSize, Instruction ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelPreferredWorkGroupSizeMultiple, ResultType, Invoke.ResultTypeId, Param.ResultTypeId, ParamSize.ResultTypeId, ParamAlign.ResultTypeId);
        }

        public Instruction RetainEvent(Instruction Event)
        {
            return EmitCode(CreateInstruction(Op.OpRetainEvent, Event.ResultTypeId));
        }

        public Instruction ReleaseEvent(Instruction Event)
        {
            return EmitCode(CreateInstruction(Op.OpReleaseEvent, Event.ResultTypeId));
        }

        public Instruction CreateUserEvent(Instruction ResultType)
        {
            return EmitOperationWithResulType(Op.OpCreateUserEvent, ResultType);
        }

        public Instruction IsValidEvent(Instruction ResultType, Instruction Event)
        {
            return EmitOperationWithResulType(Op.OpIsValidEvent, ResultType, Event.ResultTypeId);
        }

        public Instruction SetUserEventStatus(Instruction Event, Instruction Status)
        {
            return EmitCode(CreateInstruction(Op.OpSetUserEventStatus, Event.ResultTypeId, Status.ResultTypeId));
        }

        public Instruction CaptureEventProfilingInfo(Instruction Event, Instruction ProfilingInfo, Instruction Value)
        {
            return EmitCode(CreateInstruction(Op.OpCaptureEventProfilingInfo, Event.ResultTypeId, ProfilingInfo.ResultTypeId, Value.ResultTypeId));
        }

        public Instruction GetDefaultQueue(Instruction ResultType)
        {
            return EmitOperationWithResulType(Op.OpGetDefaultQueue, ResultType);
        }

        public Instruction BuildNDRange(Instruction ResultType, Instruction GlobalWorkSize, Instruction LocalWorkSize, Instruction GlobalWorkOffset)
        {
            return EmitOperationWithResulType(Op.OpBuildNDRange, ResultType, GlobalWorkSize.ResultTypeId, LocalWorkSize.ResultTypeId, GlobalWorkOffset.ResultTypeId);
        }
    }
}
