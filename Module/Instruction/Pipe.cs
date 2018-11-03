using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ReadPipe(Instruction ResultType, Instruction Pipe, Instruction Pointer, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReadPipe, ResultType, Pipe.ResultTypeId, Pointer.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction WritePipe(Instruction ResultType, Instruction Pipe, Instruction Pointer, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpWritePipe, ResultType, Pipe.ResultTypeId, Pointer.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction ReservedReadPipe(Instruction ResultType, Instruction Pipe, Instruction ReserveId, Instruction Index, Instruction Pointer, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReservedReadPipe, ResultType, Pipe.ResultTypeId, ReserveId.ResultTypeId, Index.ResultTypeId, Pointer.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction ReservedWritePipe(Instruction ResultType, Instruction Pipe, Instruction ReserveId, Instruction Index, Instruction Pointer, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReservedWritePipe, ResultType, Pipe.ResultTypeId, ReserveId.ResultTypeId, Index.ResultTypeId, Pointer.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction ReserveReadPipePackets(Instruction ResultType, Instruction Pipe, Instruction NumPackets, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReserveReadPipePackets, ResultType, Pipe.ResultTypeId, NumPackets.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction ReserveWritePipePackets(Instruction ResultType, Instruction Pipe, Instruction NumPackets, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReserveWritePipePackets, ResultType, Pipe.ResultTypeId, NumPackets.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction CommitReadPipe(Instruction Pipe, Instruction ReserveId, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpCommitReadPipe, Pipe.ResultTypeId, ReserveId.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId));
        }

        public Instruction CommitWritePipe(Instruction Pipe, Instruction ReserveId, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpCommitWritePipe, Pipe.ResultTypeId, ReserveId.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId));
        }

        public Instruction IsValidReserveId(Instruction ResultType, Instruction ReserveId)
        {
            return EmitOperationWithResulType(Op.OpIsValidReserveId, ResultType, ReserveId.ResultTypeId);
        }

        public Instruction GetNumPipePackets(Instruction ResultType, Instruction Pipe, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGetNumPipePackets, ResultType, Pipe.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction GetMaxPipePackets(Instruction ResultType, Instruction Pipe, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGetMaxPipePackets, ResultType, Pipe.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction GroupReserveReadPipePackets(Instruction ResultType, Instruction Execution, Instruction Pipe, Instruction NumPackets, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGroupReserveReadPipePackets, ResultType, Execution.ResultTypeId, Pipe.ResultTypeId, NumPackets.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction GroupReserveWritePipePackets(Instruction ResultType, Instruction Execution, Instruction Pipe, Instruction NumPackets, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGroupReserveWritePipePackets, ResultType, Execution.ResultTypeId, Pipe.ResultTypeId, NumPackets.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId);
        }

        public Instruction GroupCommitReadPipe(Instruction Execution, Instruction Pipe, Instruction ReserveId, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpGroupCommitReadPipe, Execution.ResultTypeId, Pipe.ResultTypeId, ReserveId.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId));
        }

        public Instruction GroupCommitWritePipe(Instruction Execution, Instruction Pipe, Instruction ReserveId, Instruction PacketSize, Instruction PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpGroupCommitWritePipe, Execution.ResultTypeId, Pipe.ResultTypeId, ReserveId.ResultTypeId, PacketSize.ResultTypeId, PacketAlignment.ResultTypeId));
        }
    }
}
