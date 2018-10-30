using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ConstantTrue(uint ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantTrue, ResultType));
        }

        public Instruction ConstantFalse(uint ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantFalse, ResultType));
        }

        public Instruction Constant(uint ResultType, params uint[] Value)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstant, ResultType, Value));
        }

        public Instruction ConstantComposite(uint ResultType, params uint[] Constituents)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantComposite, ResultType, Constituents));
        }

        public Instruction ConstantSampler(uint ResultType, SamplerAddressingMode SamplerAddressingMode, bool Normalized, SamplerFilterMode SamplerFilterMode)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantSampler, ResultType, (uint)SamplerAddressingMode, Normalized ? 1u : 0u, (uint)SamplerFilterMode));
        }

        public Instruction ConstantNull(uint ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantNull, ResultType));
        }

        public Instruction SpecConstantTrue(uint ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpSpecConstantTrue, ResultType));
        }

        public Instruction SpecConstantFalse(uint ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpSpecConstantFalse, ResultType));
        }

        public Instruction SpecConstant(uint ResultType, params uint[] Value)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpSpecConstant, ResultType, Value));
        }

        public Instruction SpecConstantComposite(uint ResultType, params uint[] Constituents)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpSpecConstantComposite, ResultType, Constituents));
        }

        public Instruction SpecConstantOp(uint ResultType, Op Opcode, params uint[] Operands)
        {
            Instruction SpecConstantOp = CreateOperationWithResulType(Op.OpSpecConstantOp, ResultType,(uint)Opcode);
            SpecConstantOp.PushOperand(Operands);

            return AddTypeDeclaration(SpecConstantOp);
        }
    }
}
