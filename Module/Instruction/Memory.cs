using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction Variable(Instruction ResultType, StorageClass StorageClass, Instruction Initializer = null)
        {
            Instruction Variable = CreateOperationWithResulType(Op.OpVariable, ResultType, (uint)StorageClass);

            if (Initializer != null)
            {
                Variable.PushOperandResultTypeId(Initializer);
            }

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

        public Instruction ImageTexelPointer(Instruction ResultType, Instruction Image, Instruction Coordinate, Instruction Sample)
        {
            return EmitCode(CreateOperationWithResulType(Op.OpImageTexelPointer, ResultType, Image.ResultTypeId, Coordinate.ResultTypeId, Sample.ResultTypeId));
        }

        public Instruction Load(Instruction ResultType, Instruction Pointer, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction Load = CreateOperationWithResulType(Op.OpLoad, ResultType, Pointer.ResultTypeId);

            if (MemoryAccess != 0)
            {
                Load.PushOperand((uint)MemoryAccess);
            }
            return EmitCode(Load);
        }

        public Instruction Store(Instruction Pointer, Instruction Object, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction Store = CreateInstruction(Op.OpStore, Pointer.ResultTypeId, Object.ResultTypeId);

            if (MemoryAccess != 0)
            {
                Store.PushOperand((uint)MemoryAccess);
            }

            return EmitCode(Store);
        }

        public Instruction CopyMemory(Instruction Target, Instruction Source, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction CopyMemory = CreateInstruction(Op.OpCopyMemory, Target.ResultTypeId, Source.ResultTypeId);

            if (MemoryAccess != 0)
            {
                CopyMemory.PushOperand((uint)MemoryAccess);
            }

            return EmitCode(CopyMemory);
        }

        public Instruction CopyMemorySized(Instruction Target, Instruction Source, Instruction Size, MemoryAccessShift MemoryAccess = 0)
        {
            Instruction CopyMemorySized = CreateInstruction(Op.OpCopyMemorySized, Target.ResultTypeId, Source.ResultTypeId, Size.ResultTypeId);

            if (MemoryAccess != 0)
            {
                CopyMemorySized.PushOperand((uint)MemoryAccess);
            }

            return EmitCode(CopyMemorySized);
        }

        public Instruction AccessChain(Instruction ResultType, Instruction Base, params Instruction[] Indexes)
        {
            Instruction AccessChain = CreateOperationWithResulType(Op.OpAccessChain, ResultType, Base.ResultTypeId);

            AccessChain.PushOperandResultTypeId(Indexes);
            return EmitCode(AccessChain);
        }

        public Instruction InBoundsAccessChain(Instruction ResultType, Instruction Base, params Instruction[] Indexes)
        {
            Instruction InBoundsAccessChain = CreateOperationWithResulType(Op.OpInBoundsAccessChain, ResultType, Base.ResultTypeId);

            InBoundsAccessChain.PushOperandResultTypeId(Indexes);
            return EmitCode(InBoundsAccessChain);
        }

        public Instruction PtrAccessChain(Instruction ResultType, Instruction Base, Instruction Element, params Instruction[] Indexes)
        {
            Instruction PtrAccessChain = CreateOperationWithResulType(Op.OpPtrAccessChain, ResultType, Base.ResultTypeId, Element.ResultTypeId);

            PtrAccessChain.PushOperandResultTypeId(Indexes);
            return EmitCode(PtrAccessChain);
        }

        public Instruction ArrayLength(Instruction ResultType, Instruction StructureId, uint ArrayMember)
        {
            return EmitOperationWithResulType(Op.OpArrayLength, ResultType, StructureId.ResultTypeId, ArrayMember);
        }

        public Instruction GenericPtrMemSemantics(Instruction ResultType, Instruction Pointer)
        {
            return EmitOperationWithResulType(Op.OpGenericPtrMemSemantics, ResultType, Pointer.ResultTypeId);
        }

        public Instruction InBoundsPtrAccessChain(Instruction ResultType, Instruction Base, Instruction Element, params Instruction[] Indexes)
        {
            Instruction InBoundsPtrAccessChain = CreateOperationWithResulType(Op.OpInBoundsPtrAccessChain, ResultType, Base.ResultTypeId, Element.ResultTypeId);

            InBoundsPtrAccessChain.PushOperandResultTypeId(Indexes);
            return EmitCode(InBoundsPtrAccessChain);
        }
    }
}
