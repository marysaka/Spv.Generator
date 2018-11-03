using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction SNegate(Instruction ResultType, Instruction Operand)
        {
            return EmitOperationWithResulType(Op.OpSNegate, ResultType, Operand.ResultTypeId);
        }

        public Instruction FNegate(Instruction ResultType, Instruction Operand)
        {
            return EmitOperationWithResulType(Op.OpFNegate, ResultType, Operand.ResultTypeId);
        }

        public Instruction IAdd(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpIAdd, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FAdd(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFAdd, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction ISub(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpISub, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FSub(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFSub, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction IMul(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpIMul, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FMul(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFMul, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction UDiv(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpUDiv, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SDiv(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSDiv, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FDiv(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFDiv, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction UMod(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpUMod, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SRem(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSRem, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SMod(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSMod, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FRem(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFRem, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction FMod(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpFMod, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction VectorTimesScalar(Instruction ResultType, Instruction Vector, Instruction Scalar)
        {
            return EmitOperationWithResulType(Op.OpVectorTimesScalar, ResultType, Vector.ResultTypeId, Scalar.ResultTypeId);
        }

        public Instruction MatrixTimesScalar(Instruction ResultType, Instruction Matrix, Instruction Scalar)
        {
            return EmitOperationWithResulType(Op.OpMatrixTimesScalar, ResultType, Matrix.ResultTypeId, Scalar.ResultTypeId);
        }

        public Instruction VectorTimesMatrix(Instruction ResultType, Instruction Vector, Instruction Matrix)
        {
            return EmitOperationWithResulType(Op.OpVectorTimesMatrix, ResultType, Vector.ResultTypeId, Matrix.ResultTypeId);
        }

        public Instruction MatrixTimesVector(Instruction ResultType, Instruction Matrix, Instruction Vector)
        {
            return EmitOperationWithResulType(Op.OpMatrixTimesVector, ResultType, Matrix.ResultTypeId, Vector.ResultTypeId);
        }

        public Instruction MatrixTimesMatrix(Instruction ResultType, Instruction LeftMatrix, Instruction RightMatrix)
        {
            return EmitOperationWithResulType(Op.OpMatrixTimesMatrix, ResultType, LeftMatrix.ResultTypeId, RightMatrix.ResultTypeId);
        }

        public Instruction OuterProduct(Instruction ResultType, Instruction Vector1, Instruction Vector2)
        {
            return EmitOperationWithResulType(Op.OpOuterProduct, ResultType, Vector1.ResultTypeId, Vector2.ResultTypeId);
        }

        public Instruction Dot(Instruction ResultType, Instruction Vector1, Instruction Vector2)
        {
            return EmitOperationWithResulType(Op.OpDot, ResultType, Vector1.ResultTypeId, Vector2.ResultTypeId);
        }

        public Instruction IAddCarry(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpIAddCarry, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction ISubBorrow(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpISubBorrow, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction UMulExtended(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpUMulExtended, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }

        public Instruction SMulExtended(Instruction ResultType, Instruction Operand1, Instruction Operand2)
        {
            return EmitOperationWithResulType(Op.OpSMulExtended, ResultType, Operand1.ResultTypeId, Operand2.ResultTypeId);
        }
    }
}
