using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Any(Instruction ResultType, Instruction Vector)
        {
            return EmitOperationWithResulType(Op.OpAny, ResultType, Vector.ResultTypeId);
        }

        public Instruction All(Instruction ResultType, Instruction Vector)
        {
            return EmitOperationWithResulType(Op.OpAll, ResultType, Vector.ResultTypeId);
        }

        public Instruction IsNaN(Instruction ResultType, Instruction x)
        {
            return EmitOperationWithResulType(Op.OpIsNan, ResultType, x.ResultTypeId);
        }

        public Instruction IsInf(Instruction ResultType, Instruction x)
        {
            return EmitOperationWithResulType(Op.OpIsInf, ResultType, x.ResultTypeId);
        }

        public Instruction IsFinite(Instruction ResultType, Instruction x)
        {
            return EmitOperationWithResulType(Op.OpIsFinite, ResultType, x.ResultTypeId);
        }

        public Instruction IsNormal(Instruction ResultType, Instruction x)
        {
            return EmitOperationWithResulType(Op.OpIsNormal, ResultType, x.ResultTypeId);
        }

        public Instruction SignBitSet(Instruction ResultType, Instruction x)
        {
            return EmitOperationWithResulType(Op.OpSignBitSet, ResultType, x.ResultTypeId);
        }

        public Instruction LessOrGreater(Instruction ResultType, Instruction x, Instruction y)
        {
            return EmitOperationWithResulType(Op.OpLessOrGreater, ResultType, x.ResultTypeId, y.ResultTypeId);
        }

        public Instruction Ordered(Instruction ResultType, Instruction x, Instruction y)
        {
            return EmitOperationWithResulType(Op.OpOrdered, ResultType, x.ResultTypeId, y.ResultTypeId);
        }

        public Instruction UnOrdered(Instruction ResultType, Instruction x, Instruction y)
        {
            return EmitOperationWithResulType(Op.OpUnordered, ResultType, x.ResultTypeId, y.ResultTypeId);
        }

        public Instruction LogicalEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction LogicalNotEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalNotEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction LogicalOr(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalOr, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction LogicalAnd(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalAnd, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction Select(Instruction ResultType, Instruction Condition, Instruction Object1, Instruction Object2)
        {
            return EmitOperationWithResulType(Op.OpSelect, ResultType, Condition.ResultTypeId, Object1.ResultTypeId, Object2.ResultTypeId);
        }

        public Instruction IEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpIEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction INotEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpINotEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction UGreaterThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpUGreaterThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SGreaterThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSGreaterThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction UGreaterThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpUGreaterThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SGreaterThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSGreaterThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction ULessThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpULessThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SLessThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSLessThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction ULessThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpULessThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SLessThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSLessThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FOrdEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FUnOrdEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FOrdNotEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdNotEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FUnOrdNotEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordNotEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FOrdLessThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdLessThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FUnordLessThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordLessThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FOrdGreaterThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdGreaterThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FUnordGreaterThan(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordGreaterThan, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FOrdLessThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdLessThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FUnordLessThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordLessThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FOrdGreaterThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdGreaterThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FUnordGreaterThanEqual(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordGreaterThanEqual, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }
    }
}
