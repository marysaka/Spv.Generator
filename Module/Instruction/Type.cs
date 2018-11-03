using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction AddTypeDeclaration(Instruction Type)
        {
            int ListIndex = TypesDeclarations.IndexOf(Type);
            // FIXME: IMPLEMENT EQUALS IN INSTRUCTION
            if (ListIndex < 0)
            {
                if (!Type.HasResultTypeId)
                {
                    Type.SetResultTypeId(AllocateId());
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
            // TODO: checks?
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
            // TODO: checks?
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
            // TODO: capabilities & checks
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeVector, ComponentType.ResultTypeId, ComponentCount));
        }

        public Instruction TypeMatrix(Instruction ComponentType, uint ComponentCount)
        {
            // TODO: capabilities & checks
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeMatrix, ComponentType.ResultTypeId, ComponentCount));
        }

        public Instruction TypeImage(Instruction SampleType, Dim Dim, uint Depth, bool Arrayed, uint MS, uint Sampled, params AccessQualifier[] OptionalAccessQualifiers)
        {
            // TODO: capabilities & checks
            Instruction TypeImage = CreateInstruction(Op.OpTypeImage, SampleType.ResultTypeId, (uint)Dim, Depth, Arrayed ? 1u : 0u, MS, Sampled);
            foreach (AccessQualifier AccessQualifier in OptionalAccessQualifiers)
            {
                TypeImage.PushOperand((uint)AccessQualifier);
            }

            return AddTypeDeclaration(TypeImage);
        }

        public Instruction TypeSampler()
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeSampler));
        }

        public Instruction TypeSampledImage(Instruction ImageType)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeSampledImage, ImageType.ResultTypeId));
        }

        public Instruction TypeArray(Instruction ElementType, Instruction Length)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeArray, ElementType.ResultTypeId, Length.ResultTypeId));
        }

        public Instruction TypeRuntimeArray(Instruction ElementType)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeRuntimeArray, ElementType.ResultTypeId));
        }

        public Instruction TypeStruct(params Instruction[] Members)
        {
            if (Members.Length == 0)
            {
                // TODO: error/exception
            }

            Instruction Result = CreateInstruction(Op.OpTypeStruct);
            Result.PushOperandResultTypeId(Members);

            return AddTypeDeclaration(Result);
        }

        public Instruction TypeOpaque(string OpaqueName)
        {
            Instruction TypeOpaque = CreateInstruction(Op.OpTypeOpaque);
            TypeOpaque.PushOperand(OpaqueName);

            return AddTypeDeclaration(TypeOpaque);
        }

        public Instruction TypePointer(StorageClass StorageClass, Instruction Type)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypePointer, (uint)StorageClass, Type.ResultTypeId));
        }

        public Instruction TypeFunction(Instruction ReturnType, params Instruction[] Params)
        {
            Instruction TypeFunction = CreateInstruction(Op.OpTypeFunction);

            TypeFunction.PushOperandResultTypeId(ReturnType);
            TypeFunction.PushOperandResultTypeId(Params);

            return AddTypeDeclaration(TypeFunction);
        }

        public Instruction TypeEvent()
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeEvent));
        }

        public Instruction TypeDeviceEvent()
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeDeviceEvent));
        }

        public Instruction TypeReserveId()
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeReserveId));
        }

        public Instruction TypeQueue()
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypeQueue));
        }

        public Instruction TypePipe(AccessQualifier Qualifier)
        {
            return AddTypeDeclaration(CreateInstruction(Op.OpTypePipe, (uint)Qualifier));
        }

        public Instruction TypeForwardPointer(Instruction PointerType, StorageClass StorageClass)
        {
            Instruction TypeForwardPointer = CreateInstruction(Op.OpTypeForwardPointer, PointerType.ResultTypeId, (uint)StorageClass);

            // Manually added because it's forwarded.
            TypesDeclarations.Add(TypeForwardPointer);

            return TypeForwardPointer;
        }
    }
}
