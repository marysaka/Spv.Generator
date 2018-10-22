using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        private Instruction EmitArithmeticInstruction(Op Opcode, uint ResultType, params uint[] Values)
        {
            Instruction Result = CreateInstruction(Opcode, Values);
            Result.SetTypeId(ResultType);
            Result.SetResultTypeId(AllocateId());

            return EmitCode(Result);
        }

        public Instruction SNegate(uint ResultType, uint Operand)
        {
            return EmitArithmeticInstruction(Op.OpSNegate, ResultType, Operand);
        }

        public Instruction FNegate(uint ResultType, uint Operand)
        {
            return EmitArithmeticInstruction(Op.OpFNegate, ResultType, Operand);
        }

        public Instruction IAdd(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpIAdd, ResultType, Operand1, Operand2);
        }

        public Instruction FAdd(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpFAdd, ResultType, Operand1, Operand2);
        }

        public Instruction ISub(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpISub, ResultType, Operand1, Operand2);
        }

        public Instruction FSub(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpFSub, ResultType, Operand1, Operand2);
        }

        public Instruction IMul(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpIMul, ResultType, Operand1, Operand2);
        }

        public Instruction FMul(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpFMul, ResultType, Operand1, Operand2);
        }

        public Instruction UDiv(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpUDiv, ResultType, Operand1, Operand2);
        }

        public Instruction SDiv(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpSDiv, ResultType, Operand1, Operand2);
        }

        public Instruction FDiv(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpFDiv, ResultType, Operand1, Operand2);
        }

        public Instruction UMod(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpUMod, ResultType, Operand1, Operand2);
        }

        public Instruction SRem(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpSRem, ResultType, Operand1, Operand2);
        }

        public Instruction SMod(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpSMod, ResultType, Operand1, Operand2);
        }

        public Instruction FRem(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpFRem, ResultType, Operand1, Operand2);
        }

        public Instruction FMod(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpFMod, ResultType, Operand1, Operand2);
        }

        public Instruction VectorTimesScalar(uint ResultType, uint Vector, uint Scalar)
        {
            return EmitArithmeticInstruction(Op.OpVectorTimesScalar, ResultType, Vector, Scalar);
        }

        public Instruction MatrixTimesScalar(uint ResultType, uint Matrix, uint Scalar)
        {
            return EmitArithmeticInstruction(Op.OpMatrixTimesScalar, ResultType, Matrix, Scalar);
        }

        public Instruction VectorTimesMatrix(uint ResultType, uint Vector, uint Matrix)
        {
            return EmitArithmeticInstruction(Op.OpVectorTimesMatrix, ResultType, Vector, Matrix);
        }

        public Instruction MatrixTimesVector(uint ResultType, uint Matrix, uint Vector)
        {
            return EmitArithmeticInstruction(Op.OpMatrixTimesVector, ResultType, Matrix, Vector);
        }

        public Instruction MatrixTimesMatrix(uint ResultType, uint LeftMatrix, uint RightMatrix)
        {
            return EmitArithmeticInstruction(Op.OpMatrixTimesMatrix, ResultType, LeftMatrix, RightMatrix);
        }

        public Instruction OuterProduct(uint ResultType, uint Vector1, uint Vector2)
        {
            return EmitArithmeticInstruction(Op.OpOuterProduct, ResultType, Vector1, Vector2);
        }

        public Instruction Dot(uint ResultType, uint Vector1, uint Vector2)
        {
            return EmitArithmeticInstruction(Op.OpDot, ResultType, Vector1, Vector2);
        }

        public Instruction IAddCarry(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpIAddCarry, ResultType, Operand1, Operand2);
        }

        public Instruction ISubBorrow(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpISubBorrow, ResultType, Operand1, Operand2);
        }

        public Instruction UMulExtended(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpUMulExtended, ResultType, Operand1, Operand2);
        }

        public Instruction SMulExtended(uint ResultType, uint Operand1, uint Operand2)
        {
            return EmitArithmeticInstruction(Op.OpSMulExtended, ResultType, Operand1, Operand2);
        }
    }
}
