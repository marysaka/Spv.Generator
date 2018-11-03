using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {

        public Instruction ConvertUToF(Instruction ResultType, Instruction UnsignedValue)
        {
            return EmitOperationWithResulType(Op.OpConvertUToF, ResultType, UnsignedValue.ResultTypeId);
        }

        public Instruction UConvert(Instruction ResultType, Instruction UnsignedValue)
        {
            return EmitOperationWithResulType(Op.OpUConvert, ResultType, UnsignedValue.ResultTypeId);
        }

        public Instruction SConvert(Instruction ResultType, Instruction SignedValue)
        {
            return EmitOperationWithResulType(Op.OpSConvert, ResultType, SignedValue.ResultTypeId);
        }

        public Instruction FConvert(Instruction ResultType, Instruction FloatValue)
        {
            return EmitOperationWithResulType(Op.OpFConvert, ResultType, FloatValue.ResultTypeId);
        }

        public Instruction QuantizeToF16(Instruction ResultType, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpQuantizeToF16, ResultType, Value.ResultTypeId);
        }

        public Instruction ConvertPtrToU(Instruction ResultType, Instruction Pointer)
        {
            return EmitOperationWithResulType(Op.OpConvertPtrToU, ResultType, Pointer.ResultTypeId);
        }

        public Instruction SatConvertSToU(Instruction ResultType, Instruction SignedValue)
        {
            return EmitOperationWithResulType(Op.OpSatConvertSToU, ResultType, SignedValue.ResultTypeId);
        }

        public Instruction SatConvertUToS(Instruction ResultType, Instruction UnsignedValue)
        {
            return EmitOperationWithResulType(Op.OpSatConvertUToS, ResultType, UnsignedValue.ResultTypeId);
        }

        public Instruction ConvertUToPtr(Instruction ResultType, Instruction IntegerValue)
        {
            return EmitOperationWithResulType(Op.OpConvertUToPtr, ResultType, IntegerValue.ResultTypeId);
        }

        public Instruction PtrCastToGeneric(Instruction ResultType, Instruction Pointer)
        {
            return EmitOperationWithResulType(Op.OpPtrCastToGeneric, ResultType, Pointer.ResultTypeId);
        }

        public Instruction GenericCastToPtr(Instruction ResultType, Instruction Pointer)
        {
            return EmitOperationWithResulType(Op.OpGenericCastToPtr, ResultType, Pointer.ResultTypeId);
        }

        public Instruction GenericCastToPtrExplicit(Instruction ResultType, Instruction Pointer, StorageClass Storage)
        {
            return EmitOperationWithResulType(Op.OpGenericCastToPtrExplicit, ResultType, Pointer.ResultTypeId, (uint)Storage);
        }

        public Instruction Bitcast(Instruction ResultType, Instruction Operand)
        {
            return EmitOperationWithResulType(Op.OpBitcast, ResultType, Operand.ResultTypeId);
        }
        
    }
}
