using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction ConstantTrue(uint BoolType)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpConstantTrue).SetTypeId(BoolType), true);
        }

        public Instruction ConstantFalse(uint BoolType)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpConstantFalse).SetTypeId(BoolType), true);
        }

        public Instruction Constant(uint Type, params uint[] Value)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpConstant, Value).SetTypeId(Type), true);
        }

        public Instruction ConstantComposite(uint CompositeType, params uint[] Constituents)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpConstantComposite, Constituents).SetTypeId(CompositeType), true);
        }

        public Instruction ConstantSampler(uint SamplerType, SamplerAddressingMode SamplerAddressingMode, bool Normalized, SamplerFilterMode SamplerFilterMode)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpConstantSampler, SamplerType, (uint)SamplerAddressingMode, Normalized ? 1u : 0u, (uint)SamplerFilterMode).SetTypeId(SamplerType), true);
        }

        public Instruction ConstantNull(uint Type)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpConstantNull).SetTypeId(Type), true);
        }

        public Instruction SpecConstantTrue(uint BoolType)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpSpecConstantTrue).SetTypeId(BoolType), true);
        }

        public Instruction SpecConstantFalse(uint BoolType)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpSpecConstantFalse).SetTypeId(BoolType), true);
        }

        public Instruction SpecConstant(uint Type, params uint[] Value)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpSpecConstant, Value).SetTypeId(Type), true);
        }

        public Instruction SpecConstantComposite(uint CompositeType, params uint[] Constituents)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpSpecConstantComposite, Constituents).SetTypeId(CompositeType), true);
        }

        public Instruction SpecConstantOp(uint Type, Op Opcode, params uint[] Operands)
        {
            Instruction SpecConstantOp = CreateInstruction(Op.OpSpecConstantOp, (uint)Opcode);
            SpecConstantOp.PushOperand(Operands);
            SpecConstantOp.SetTypeId(Type);

            return AddTypeDeclaration(SpecConstantOp, true);
        }
    }
}
