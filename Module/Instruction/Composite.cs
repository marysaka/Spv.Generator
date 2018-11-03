using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {

        public Instruction VectorExtractDynamic(Instruction ResultType, Instruction Vector, Instruction Index)
        {
            return EmitOperationWithResulType(Op.OpVectorExtractDynamic, ResultType, Vector.ResultTypeId, Index.ResultTypeId);
        }

        public Instruction VectorInsertDynamic(Instruction ResultType, Instruction Vector, Instruction Component, Instruction Index)
        {
            return EmitOperationWithResulType(Op.OpVectorInsertDynamic, ResultType, Vector.ResultTypeId, Component.ResultTypeId, Index.ResultTypeId);
        }

        public Instruction VectorShuffle(Instruction ResultType, Instruction Vector1, Instruction Vector2, params uint[] Components)
        {
            Instruction VectorShuffle = CreateOperationWithResulType(Op.OpVectorShuffle, ResultType, Vector1.ResultTypeId, Vector2.ResultTypeId);

            VectorShuffle.PushOperand(Components);

            return EmitCode(VectorShuffle);
        }

        public Instruction CompositeConstruct(Instruction ResultType, params Instruction[] Constituents)
        {
            Instruction CompositeConstruct = CreateOperationWithResulType(Op.OpCompositeConstruct, ResultType);
            CompositeConstruct.PushOperandResultTypeId(Constituents);

            return EmitCode(CompositeConstruct);
        }

        public Instruction CompositeExtract(Instruction ResultType, Instruction Composite, params uint[] Indexes)
        {
            Instruction CompositeExtract = CreateOperationWithResulType(Op.OpCompositeExtract, ResultType, Composite.ResultTypeId);
            CompositeExtract.PushOperand(Indexes);

            return EmitCode(CompositeExtract);
        }

        public Instruction CompositeInsert(Instruction ResultType, Instruction Object, Instruction Composite, params uint[] Indexes)
        {
            Instruction CompositeInsert = CreateOperationWithResulType(Op.OpCompositeInsert, ResultType, Object.ResultTypeId, Composite.ResultTypeId);
            CompositeInsert.PushOperand(Indexes);

            return EmitCode(CompositeInsert);
        }

        public Instruction CopyObject(Instruction ResultType, Instruction Operand)
        {
            return EmitOperationWithResulType(Op.OpCopyObject, ResultType, Operand.ResultTypeId);
        }

        public Instruction Transpose(Instruction ResultType, Instruction Matrix)
        {
            return EmitOperationWithResulType(Op.OpTranspose, ResultType, Matrix.ResultTypeId);
        }
    }
}
