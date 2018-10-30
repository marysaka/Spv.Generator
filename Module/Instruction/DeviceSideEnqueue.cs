using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction EnqueueMarker(uint ResultType, uint Queue, uint NumEvents, uint WaitEvents, uint RetEvent)
        {
            return EmitOperationWithResulType(Op.OpEnqueueMarker, ResultType, Queue, NumEvents, WaitEvents, RetEvent);
        }

        public Instruction EnqueueKernel(uint ResultType, uint Queue, uint Flags, uint NDRange, uint NumEvents, uint WaitEvents, uint RetEvent, uint Invoke, uint Param, uint ParamSize, uint ParamAlign, params uint[] LocalSize)
        {
            Instruction EnqueueKernel = EmitOperationWithResulType(Op.OpEnqueueKernel, ResultType, Queue, Flags, NDRange, NumEvents, WaitEvents, RetEvent, Invoke, Param, ParamSize, ParamAlign);
            EnqueueKernel.PushOperand(LocalSize);

            return EnqueueKernel;
        }

        public Instruction GetKernelNDrangeSubGroupCount(uint ResultType, uint NDRange, uint Invoke, uint Param, uint ParamSize, uint ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelNDrangeSubGroupCount, ResultType, NDRange, Invoke, Param, ParamSize, ParamAlign);
        }

        public Instruction GetKernelNDrangeMaxSubGroupSize(uint ResultType, uint NDRange, uint Invoke, uint Param, uint ParamSize, uint ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelNDrangeMaxSubGroupSize, ResultType, NDRange, Invoke, Param, ParamSize, ParamAlign);
        }

        public Instruction GetKernelWorkGroupSize(uint ResultType, uint Invoke, uint Param, uint ParamSize, uint ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelWorkGroupSize, ResultType, Invoke, Param, ParamSize, ParamAlign);
        }

        public Instruction GetKernelPreferredWorkGroupSizeMultiple(uint ResultType, uint Invoke, uint Param, uint ParamSize, uint ParamAlign)
        {
            return EmitOperationWithResulType(Op.OpGetKernelPreferredWorkGroupSizeMultiple, ResultType, Invoke, Param, ParamSize, ParamAlign);
        }

        public Instruction RetainEvent(uint Event)
        {
            return EmitCode(CreateInstruction(Op.OpRetainEvent, Event));
        }

        public Instruction ReleaseEvent(uint Event)
        {
            return EmitCode(CreateInstruction(Op.OpReleaseEvent, Event));
        }

        public Instruction CreateUserEvent(uint ResultType)
        {
            return EmitOperationWithResulType(Op.OpCreateUserEvent, ResultType);
        }

        public Instruction IsValidEvent(uint ResultType, uint Event)
        {
            return EmitOperationWithResulType(Op.OpIsValidEvent, ResultType, Event);
        }

        public Instruction SetUserEventStatus(uint Event, uint Status)
        {
            return EmitCode(CreateInstruction(Op.OpSetUserEventStatus, Event, Status));
        }

        public Instruction CaptureEventProfilingInfo(uint Event, uint ProfilingInfo, uint Value)
        {
            return EmitCode(CreateInstruction(Op.OpCaptureEventProfilingInfo, Event, ProfilingInfo, Value));
        }

        public Instruction GetDefaultQueue(uint ResultType)
        {
            return EmitOperationWithResulType(Op.OpGetDefaultQueue, ResultType);
        }

        public Instruction BuildNDRange(uint ResultType, uint GlobalWorkSize, uint LocalWorkSize, uint GlobalWorkOffset)
        {
            return EmitOperationWithResulType(Op.OpBuildNDRange, ResultType, GlobalWorkSize, LocalWorkSize, GlobalWorkOffset);
        }
    }
}
