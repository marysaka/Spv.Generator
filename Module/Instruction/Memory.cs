using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Variable(uint ResultType, uint Type, StorageClass StorageClass)
        {
            Instruction Variable = CreateInstruction(Op.OpVariable, (uint)StorageClass);
            Variable.SetTypeId(Type);
            Variable.SetResultTypeId(ResultType);

            if (Variable.IsGlobalVariable())
            {
                TypesDeclarations.Add(Variable);
            }
            else
            {
                EmitCode(Variable);
            }

            return Variable;
        }

        public Instruction ImageTexelPointer(uint ResultType, uint Type, uint Image, uint Coordinate, uint Sample)
        {
            Instruction ImageTexelPointer = CreateInstruction(Op.OpImageTexelPointer, Image, Coordinate, Sample);

            ImageTexelPointer.SetTypeId(Type);
            ImageTexelPointer.SetResultTypeId(ResultType);
            return EmitCode(ImageTexelPointer);
        }

        public Instruction Load(uint ResultType, uint Type, uint Pointer, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction Load = CreateInstruction(Op.OpLoad, Pointer);

            if (MemoryAccess != 0)
            {
                Load.PushOperand((uint)MemoryAccess);
            }

            Load.SetTypeId(Type);
            Load.SetResultTypeId(ResultType);
            return EmitCode(Load);
        }

        public Instruction Store(uint Pointer, uint Object, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction Store = CreateInstruction(Op.OpStore, Pointer, Object);

            if (MemoryAccess != 0)
            {
                Store.PushOperand((uint)MemoryAccess);
            }

            return EmitCode(Store);
        }

        public Instruction CopyMemory(uint Target, uint Source, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction CopyMemory = CreateInstruction(Op.OpCopyMemory, Target, Source);
            if (MemoryAccess != 0)
            {
                CopyMemory.PushOperand((uint)MemoryAccess);
            }

            return EmitCode(CopyMemory);
        }

        public Instruction CopyMemorySized(uint Target, uint Source, uint Size, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction CopyMemorySized = CreateInstruction(Op.OpCopyMemorySized, Target, Source, Size);

            if (MemoryAccess != 0)
            {
                CopyMemorySized.PushOperand((uint)MemoryAccess);
            }

            return EmitCode(CopyMemorySized);
        }

        public Instruction AccessChain(uint ResultType, uint Type, uint Base, params uint[] Indexes)
        {
            Instruction AccessChain = CreateInstruction(Op.OpAccessChain, Base);

            AccessChain.SetTypeId(Type);
            AccessChain.SetResultTypeId(ResultType);
            AccessChain.PushOperand(Indexes);
            return EmitCode(AccessChain);
        }

        public Instruction InBoundsAccessChain(uint ResultType, uint Type, uint Base, params uint[] Indexes)
        {
            Instruction InBoundsAccessChain = CreateInstruction(Op.OpInBoundsAccessChain, Base);

            InBoundsAccessChain.SetTypeId(Type);
            InBoundsAccessChain.SetResultTypeId(ResultType);
            InBoundsAccessChain.PushOperand(Indexes);
            return EmitCode(InBoundsAccessChain);
        }

        public Instruction PtrAccessChain(uint ResultType, uint Type, uint Base, uint Element, params uint[] Indexes)
        {
            Instruction PtrAccessChain = CreateInstruction(Op.OpPtrAccessChain, Base, Element);

            PtrAccessChain.SetTypeId(Type);
            PtrAccessChain.SetResultTypeId(ResultType);
            PtrAccessChain.PushOperand(Indexes);
            return EmitCode(PtrAccessChain);
        }

        public Instruction ArrayLength(uint ResultType, uint Type, uint StructureId, uint ArrayMember)
        {
            Instruction ArrayLength = CreateInstruction(Op.OpArrayLength, StructureId, ArrayMember);
            ArrayLength.SetTypeId(Type);
            ArrayLength.SetResultTypeId(ResultType);

            return EmitCode(ArrayLength);
        }

        public Instruction GenericPtrMemSemantics(uint ResultType, uint Type, uint Pointer)
        {
            Instruction GenericPtrMemSemantics = CreateInstruction(Op.OpGenericPtrMemSemantics, Pointer);
            GenericPtrMemSemantics.SetTypeId(Type);
            GenericPtrMemSemantics.SetResultTypeId(ResultType);

            return EmitCode(GenericPtrMemSemantics);
        }

        public Instruction InBoundsPtrAccessChain(uint ResultType, uint Type, uint Base, uint Element, params uint[] Indexes)
        {
            Instruction InBoundsPtrAccessChain = CreateInstruction(Op.OpInBoundsPtrAccessChain, Base, Element);

            InBoundsPtrAccessChain.SetTypeId(Type);
            InBoundsPtrAccessChain.SetResultTypeId(ResultType);
            InBoundsPtrAccessChain.PushOperand(Indexes);
            return EmitCode(InBoundsPtrAccessChain);
        }
    }
}
