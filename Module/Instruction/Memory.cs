using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Variable(uint Type, StorageClass StorageClass)
        {
            Instruction Variable = CreateOperationWithResulType(Op.OpVariable, Type, (uint)StorageClass);

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

        public Instruction ImageTexelPointer(uint ResultType, uint Image, uint Coordinate, uint Sample)
        {
            Instruction ImageTexelPointer = CreateOperationWithResulType(Op.OpImageTexelPointer, ResultType, Image, Coordinate, Sample);

            return EmitCode(ImageTexelPointer);
        }

        public Instruction Load(uint ResultType, uint Pointer, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction Load = CreateOperationWithResulType(Op.OpLoad, ResultType, Pointer);

            if (MemoryAccess != 0)
            {
                Load.PushOperand((uint)MemoryAccess);
            }
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

        public Instruction AccessChain(uint ResultType, uint Base, params uint[] Indexes)
        {
            Instruction AccessChain = CreateOperationWithResulType(Op.OpAccessChain, ResultType, Base);

            AccessChain.PushOperand(Indexes);
            return EmitCode(AccessChain);
        }

        public Instruction InBoundsAccessChain(uint ResultType, uint Base, params uint[] Indexes)
        {
            Instruction InBoundsAccessChain = CreateOperationWithResulType(Op.OpInBoundsAccessChain, ResultType, Base);

            InBoundsAccessChain.PushOperand(Indexes);
            return EmitCode(InBoundsAccessChain);
        }

        public Instruction PtrAccessChain(uint ResultType, uint Base, uint Element, params uint[] Indexes)
        {
            Instruction PtrAccessChain = CreateOperationWithResulType(Op.OpPtrAccessChain, ResultType, Base, Element);

            PtrAccessChain.PushOperand(Indexes);
            return EmitCode(PtrAccessChain);
        }

        public Instruction ArrayLength(uint ResultType, uint StructureId, uint ArrayMember)
        {
            return EmitOperationWithResulType(Op.OpArrayLength, ResultType, StructureId, ArrayMember);
        }

        public Instruction GenericPtrMemSemantics(uint ResultType, uint Pointer)
        {
            return EmitOperationWithResulType(Op.OpGenericPtrMemSemantics, ResultType, Pointer);
        }

        public Instruction InBoundsPtrAccessChain(uint ResultType, uint Base, uint Element, params uint[] Indexes)
        {
            Instruction InBoundsPtrAccessChain = CreateOperationWithResulType(Op.OpInBoundsPtrAccessChain, ResultType, Base, Element);

            InBoundsPtrAccessChain.PushOperand(Indexes);
            return EmitCode(InBoundsPtrAccessChain);
        }
    }
}
