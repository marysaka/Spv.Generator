using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        private Instruction EmitCompositeInstruction(Op Opcode, uint ResultType, params uint[] Values)
        {
            Instruction Result = CreateInstruction(Opcode, Values);
            Result.SetTypeId(ResultType);
            Result.SetResultTypeId(AllocateId());

            return EmitCode(Result);
        }

        public Instruction VectorExtractDynamic(uint ResultType, uint Vector, uint Index)
        {
            return EmitCompositeInstruction(Op.OpVectorExtractDynamic, ResultType, Vector, Index);
        }

        public Instruction VectorInsertDynamic(uint ResultType, uint Vector, uint Component, uint Index)
        {
            return EmitCompositeInstruction(Op.OpVectorInsertDynamic, ResultType, Vector, Component, Index);
        }

        public Instruction VectorShuffle(uint ResutType, uint Vector1, uint Vector2, params uint[] Components)
        {
            Instruction VectorShuffle = EmitCompositeInstruction(Op.OpVectorShuffle, ResutType, Vector1, Vector2);

            VectorShuffle.PushOperand(Components);

            return VectorShuffle;
        }

        public Instruction CompositeConstruct(uint ResultType, params uint[] Constituents)
        {
            return EmitCompositeInstruction(Op.OpCompositeConstruct, ResultType, Constituents);
        }

        public Instruction CompositeExtract(uint ResultType, uint Composite, params uint[] Indexes)
        {
            Instruction CompositeExtract = EmitCompositeInstruction(Op.OpCompositeExtract, ResultType, Composite);
            CompositeExtract.PushOperand(Indexes);

            return CompositeExtract;
        }

        public Instruction CompositeInsert(uint ResultType, uint Object, uint Composite, params uint[] Indexes)
        {
            Instruction CompositeInsert = EmitCompositeInstruction(Op.OpCompositeInsert, ResultType, Object, Composite);
            CompositeInsert.PushOperand(Indexes);

            return CompositeInsert;
        }

        public Instruction CopyObject(uint ResultType, uint Operand)
        {
            return EmitCompositeInstruction(Op.OpCopyObject, ResultType, Operand);
        }

        public Instruction Transpose(uint ResultType, uint Matrix)
        {
            return EmitCompositeInstruction(Op.OpTranspose, ResultType, Matrix);
        }
    }
}
