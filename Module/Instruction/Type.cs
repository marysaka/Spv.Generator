using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction AddTypeDeclaration(Instruction Type, bool IsResult = false)
        {
            int ListIndex = TypesDeclarations.IndexOf(Type);
            // FIXME: IMPLEMENT EQUALS IN INSTRUCTION
            if (ListIndex < 0)
            {
                if (IsResult)
                {
                    if (!Type.HasResultTypeId)
                    {
                        Type.SetResultTypeId(AllocateId());
                    }
                }
                else
                {
                    if (!Type.HasTypeId)
                    {
                        Type.SetTypeId(AllocateId());
                    }
                }

                TypesDeclarations.Add(Type);
                return Type;
            }
            return TypesDeclarations[ListIndex];
        }

        public Instruction TypeVoid()
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeVoid));
        }

        public Instruction TypeBool()
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeBool));
        }

        public Instruction TypeInt(int Width, bool Signed)
        {
            if (Width == 8)
            {
                AddCapability(Capability.Int8);
            }
            else if (Width == 16)
            {
                AddCapability(Capability.Int16);
            }
            else if (Width == 64)
            {
                AddCapability(Capability.Int64);
            }

            return AddTypeDeclaration(CreateInstruction(Op.OpTypeInt, (uint)Width, Signed ? 1u : 0u));
        }

        public Instruction TypeFloat(int Width)
        {
            if (Width == 16)
            {
                AddCapability(Capability.Float16);
            }
            else if (Width == 64)
            {
                AddCapability(Capability.Float64);
            }

            return AddTypeDeclaration(CreateInstruction(Op.OpTypeFloat, (uint)Width));
        }

        public Instruction TypeVector(Instruction ComponentType, uint ComponentCount)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeVector, ComponentType.TypeId, ComponentCount));
        }

        public Instruction TypeMatrix(Instruction ComponentType, uint ComponentCount)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeMatrix, ComponentType.TypeId, ComponentCount));
        }
    }
}
