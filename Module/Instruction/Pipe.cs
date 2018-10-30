using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ReadPipe(uint ResultType, uint Pipe, uint Pointer, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReadPipe, ResultType, Pipe, Pointer, PacketSize, PacketAlignment);
        }

        public Instruction WritePipe(uint ResultType, uint Pipe, uint Pointer, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpWritePipe, ResultType, Pipe, Pointer, PacketSize, PacketAlignment);
        }

        public Instruction ReservedReadPipe(uint ResultType, uint Pipe, uint ReserveId, uint Index, uint Pointer, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReservedReadPipe, ResultType, Pipe, ReserveId, Index, Pointer, PacketSize, PacketAlignment);
        }

        public Instruction ReservedWritePipe(uint ResultType, uint Pipe, uint ReserveId, uint Index, uint Pointer, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReservedWritePipe, ResultType, Pipe, ReserveId, Index, Pointer, PacketSize, PacketAlignment);
        }

        public Instruction ReserveReadPipePackets(uint ResultType, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReserveReadPipePackets, ResultType, Pipe, NumPackets, PacketSize, PacketAlignment);
        }

        public Instruction ReserveWritePipePackets(uint ResultType, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpReserveWritePipePackets, ResultType, Pipe, NumPackets, PacketSize, PacketAlignment);
        }

        public Instruction CommitReadPipe(uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpCommitReadPipe, Pipe, ReserveId, PacketSize, PacketAlignment));
        }

        public Instruction CommitWritePipe(uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpCommitWritePipe, Pipe, ReserveId, PacketSize, PacketAlignment));
        }

        public Instruction IsValidReserveId(uint ResultType, uint ReserveId)
        {
            return EmitOperationWithResulType(Op.OpIsValidReserveId, ResultType, ReserveId);
        }

        public Instruction GetNumPipePackets(uint ResultType, uint Pipe, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGetNumPipePackets, ResultType, Pipe, PacketSize, PacketAlignment);
        }

        public Instruction GetMaxPipePackets(uint ResultType, uint Pipe, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGetMaxPipePackets, ResultType, Pipe, PacketSize, PacketAlignment);
        }

        public Instruction GroupReserveReadPipePackets(uint ResultType, uint Execution, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGroupReserveReadPipePackets, ResultType, Execution, Pipe, NumPackets, PacketSize, PacketAlignment);
        }

        public Instruction GroupReserveWritePipePackets(uint ResultType, uint Execution, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment)
        {
            return EmitOperationWithResulType(Op.OpGroupReserveWritePipePackets, ResultType, Execution, Pipe, NumPackets, PacketSize, PacketAlignment);
        }

        public Instruction GroupCommitReadPipe(uint Execution, uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpGroupCommitReadPipe, Execution, Pipe, ReserveId, PacketSize, PacketAlignment));
        }

        public Instruction GroupCommitWritePipe(uint Execution, uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment)
        {
            return EmitCode(CreateInstruction(Op.OpGroupCommitWritePipe, Execution, Pipe, ReserveId, PacketSize, PacketAlignment));
        }
    }
}
