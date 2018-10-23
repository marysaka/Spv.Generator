using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        // TODO: implements all relational & logical instructions

        public Instruction Any(uint ResultType, uint Vector)
        {
            return EmitOperationWithResulType(Op.OpAny, ResultType, Vector);
        }

        public Instruction All(uint ResultType, uint Vector)
        {
            return EmitOperationWithResulType(Op.OpAll, ResultType, Vector);
        }

        public Instruction IsNaN(uint ResultType, uint x)
        {
            return EmitOperationWithResulType(Op.OpIsNan, ResultType, x);
        }

        public Instruction IsInf(uint ResultType, uint x)
        {
            return EmitOperationWithResulType(Op.OpIsInf, ResultType, x);
        }

        public Instruction IsFinite(uint ResultType, uint x)
        {
            return EmitOperationWithResulType(Op.OpIsFinite, ResultType, x);
        }

        public Instruction IsNormal(uint ResultType, uint x)
        {
            return EmitOperationWithResulType(Op.OpIsNormal, ResultType, x);
        }

        public Instruction SignBitSet(uint ResultType, uint x)
        {
            return EmitOperationWithResulType(Op.OpSignBitSet, ResultType, x);
        }

        public Instruction LessOrGreater(uint ResultType, uint x, uint y)
        {
            return EmitOperationWithResulType(Op.OpLessOrGreater, x, y);
        }

        public Instruction Ordered(uint ResultType, uint x, uint y)
        {
            return EmitOperationWithResulType(Op.OpOrdered, x, y);
        }

        public Instruction UnOrdered(uint ResultType, uint x, uint y)
        {
            return EmitOperationWithResulType(Op.OpUnordered, x, y);
        }

        public Instruction LogicalEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalEqual, ResultType, Operand1, Operand2);
        }

        public Instruction LogicalNotEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalNotEqual, ResultType, Operand1, Operand2);
        }

        public Instruction LogicalOr(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalOr, ResultType, Operand1, Operand2);
        }

        public Instruction LogicalAnd(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpLogicalAnd, ResultType, Operand1, Operand2);
        }

        public Instruction Select(uint ResultType, uint Condition, uint Object1, uint Object2)
        {
            return EmitOperationWithResulType(Op.OpSelect, ResultType, Condition, Object1, Object2);
        }

        public Instruction IEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpIEqual, ResultType, Operand1, Operand2);
        }

        public Instruction INotEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpINotEqual, ResultType, Operand1, Operand2);
        }

        public Instruction UGreaterThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpUGreaterThan, ResultType, Operand1, Operand2);
        }

        public Instruction SGreaterThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpSGreaterThan, ResultType, Operand1, Operand2);
        }

        public Instruction UGreaterThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpUGreaterThanEqual, ResultType, Operand1, Operand2);
        }

        public Instruction SGreaterThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpSGreaterThanEqual, ResultType, Operand1, Operand2);
        }

        public Instruction ULessThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpULessThan, ResultType, Operand1, Operand2);
        }

        public Instruction SLessThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpSLessThan, ResultType, Operand1, Operand2);
        }

        public Instruction ULessThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpULessThanEqual, ResultType, Operand1, Operand2);
        }

        public Instruction SLessThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpSLessThanEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FOrdEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FUnOrdEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FOrdNotEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdNotEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FUnOrdNotEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordNotEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FOrdLessThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdLessThan, ResultType, Operand1, Operand2);
        }

        public Instruction FUnordLessThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordLessThan, ResultType, Operand1, Operand2);
        }

        public Instruction FOrdGreaterThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdGreaterThan, ResultType, Operand1, Operand2);
        }

        public Instruction FUnordGreaterThan(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordGreaterThan, ResultType, Operand1, Operand2);
        }

        public Instruction FOrdLessThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdLessThanEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FUnordLessThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordLessThanEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FOrdGreaterThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFOrdGreaterThanEqual, ResultType, Operand1, Operand2);
        }

        public Instruction FUnordGreaterThanEqual(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitOperationWithResulType(Op.OpFUnordGreaterThanEqual, ResultType, Operand1, Operand2);
        }
    }
}
