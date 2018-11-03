using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ConstantTrue(Instruction ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantTrue, ResultType));
        }

        public Instruction ConstantFalse(Instruction ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantFalse, ResultType));
        }

        public Instruction Constant(Instruction ResultType, params uint[] Value)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstant, ResultType, Value));
        }

        public Instruction ConstantComposite(Instruction ResultType, params Instruction[] Constituents)
        {
            Instruction ConstantComposite = CreateOperationWithResulType(Op.OpConstantComposite, ResultType);
            ConstantComposite.PushOperandResultTypeId(Constituents);
            
            return AddTypeDeclaration(ConstantComposite);
        }

        public Instruction ConstantSampler(Instruction ResultType, SamplerAddressingMode SamplerAddressingMode, bool Normalized, SamplerFilterMode SamplerFilterMode)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantSampler, ResultType, (uint)SamplerAddressingMode, Normalized ? 1u : 0u, (uint)SamplerFilterMode));
        }

        public Instruction ConstantNull(Instruction ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpConstantNull, ResultType));
        }

        public Instruction SpecConstantTrue(Instruction ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpSpecConstantTrue, ResultType));
        }

        public Instruction SpecConstantFalse(Instruction ResultType)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpSpecConstantFalse, ResultType));
        }

        public Instruction SpecConstant(Instruction ResultType, params uint[] Value)
        {
            return AddTypeDeclaration(CreateOperationWithResulType(Op.OpSpecConstant, ResultType, Value));
        }

        public Instruction SpecConstantComposite(Instruction ResultType, params Instruction[] Constituents)
        {
            Instruction SpecConstantComposite = CreateOperationWithResulType(Op.OpSpecConstantComposite, ResultType);
            SpecConstantComposite.PushOperandResultTypeId(Constituents);

            return AddTypeDeclaration(SpecConstantComposite);
        }

        public Instruction SpecConstantOp(Instruction ResultType, Op Opcode, params Instruction[] Operands)
        {
            Instruction SpecConstantOp = CreateOperationWithResulType(Op.OpSpecConstantOp, ResultType,(uint)Opcode);
            SpecConstantOp.PushOperandResultTypeId(Operands);

            return AddTypeDeclaration(SpecConstantOp);
        }
    }
}
