using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ShiftRightLogical(uint ResultType, uint Base, uint Shift)
        {
            return EmitOperationWithResulType(Op.OpShiftRightLogical, ResultType, Base, Shift);
        }

        public Instruction ShiftRightArithmetic(uint ResultType, uint Base, uint Shift)
        {
            return EmitOperationWithResulType(Op.OpShiftRightArithmetic, ResultType, Base, Shift);
        }

        public Instruction ShiftLeftLogical(uint ResultType, uint Base, uint Shift)
        {
            return EmitOperationWithResulType(Op.OpShiftLeftLogical, ResultType, Base, Shift);
        }

        public Instruction BitwiseOr(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpBitwiseOr, ResultType, Operand1, Operand2);
        }

        public Instruction BitwiseXor(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpBitwiseXor, ResultType, Operand1, Operand2);
        }

        public Instruction BitwiseAnd(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpBitwiseAnd, ResultType, Operand1, Operand2);
        }

        public Instruction Not(uint ResultType, uint Operand)
        {
            return EmitOperationWithResulType(Op.OpNot, ResultType, Operand);
        }

        public Instruction BitFieldInsert(uint ResultType, uint Base, uint Insert, uint Offset, uint Count)
        {
            return EmitOperationWithResulType(Op.OpBitFieldInsert, ResultType, Base, Insert, Offset, Count);
        }

        public Instruction BitFieldSExtract(uint ResultType, uint Base, uint Offset, uint Count)
        {
            return EmitOperationWithResulType(Op.OpBitFieldSExtract, ResultType, Base, Offset, Count);
        }

        public Instruction BitFieldUExtract(uint ResultType, uint Base, uint Offset, uint Count)
        {
            return EmitOperationWithResulType(Op.OpBitFieldUExtract, ResultType, Base, Offset, Count);
        }

        public Instruction BitReverse(uint ResultType, uint Base)
        {
            return EmitOperationWithResulType(Op.OpBitReverse, ResultType, Base);
        }

        public Instruction BitCount(uint ResultType, uint Base)
        {
            return EmitOperationWithResulType(Op.OpBitCount, ResultType, Base);
        }
    }
}
