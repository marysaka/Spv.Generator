using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ShiftRightLogical(Instruction ResultType, Instruction Base, Instruction Shift)
        {
            return EmitOperationWithResulType(Op.OpShiftRightLogical, ResultType, Base.ResultTypeId, Shift.ResultTypeId);
        }

        public Instruction ShiftRightArithmetic(Instruction ResultType, Instruction Base, Instruction Shift)
        {
            return EmitOperationWithResulType(Op.OpShiftRightArithmetic, ResultType, Base.ResultTypeId, Shift.ResultTypeId);
        }

        public Instruction ShiftLeftLogical(Instruction ResultType, Instruction Base, Instruction Shift)
        {
            return EmitOperationWithResulType(Op.OpShiftLeftLogical, ResultType, Base.ResultTypeId, Shift.ResultTypeId);
        }

        public Instruction BitwiseOr(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpBitwiseOr, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction BitwiseXor(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpBitwiseXor, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction BitwiseAnd(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpBitwiseAnd, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction Not(Instruction ResultType, Instruction Operand)
        {
            return EmitOperationWithResulType(Op.OpNot, ResultType, Operand.ResultTypeId);
        }

        public Instruction BitFieldInsert(Instruction ResultType, Instruction Base, Instruction Insert, Instruction Offset, Instruction Count)
        {
            return EmitOperationWithResulType(Op.OpBitFieldInsert, ResultType, Base.ResultTypeId, Insert.ResultTypeId, Offset.ResultTypeId, Count.ResultTypeId);
        }

        public Instruction BitFieldSExtract(Instruction ResultType, Instruction Base, Instruction Offset, Instruction Count)
        {
            return EmitOperationWithResulType(Op.OpBitFieldSExtract, ResultType, Base.ResultTypeId, Offset.ResultTypeId, Count.ResultTypeId);
        }

        public Instruction BitFieldUExtract(Instruction ResultType, Instruction Base, Instruction Offset, Instruction Count)
        {
            return EmitOperationWithResulType(Op.OpBitFieldUExtract, ResultType, Base.ResultTypeId, Offset.ResultTypeId, Count.ResultTypeId);
        }

        public Instruction BitReverse(Instruction ResultType, Instruction Base)
        {
            return EmitOperationWithResulType(Op.OpBitReverse, ResultType, Base.ResultTypeId);
        }

        public Instruction BitCount(Instruction ResultType, Instruction Base)
        {
            return EmitOperationWithResulType(Op.OpBitCount, ResultType, Base.ResultTypeId);
        }
    }
}
