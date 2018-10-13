using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        private Instruction EmitConversionInstruction(Op Opcode, uint ResultType, params uint[] Values)
        {
            Instruction Result = CreateInstruction(Opcode, Values);
            Result.SetTypeId(ResultType);
            Result.SetResultTypeId(AllocateId());

            return EmitCode(Result);
        }

        public Instruction ConvertUToF(uint ResultType, uint UnsignedValue)
        {
            return EmitConversionInstruction(Op.OpConvertUToF, ResultType, UnsignedValue);
        }

        public Instruction UConvert(uint ResultType, uint UnsignedValue)
        {
            return EmitConversionInstruction(Op.OpUConvert, ResultType, UnsignedValue);
        }

        public Instruction SConvert(uint ResultType, uint SignedValue)
        {
            return EmitConversionInstruction(Op.OpSConvert, ResultType, SignedValue);
        }

        public Instruction FConvert(uint ResultType, uint FloatValue)
        {
            return EmitConversionInstruction(Op.OpFConvert, ResultType, FloatValue);
        }

        public Instruction QuantizeToF16(uint ResultType, uint Value)
        {
            return EmitConversionInstruction(Op.OpQuantizeToF16, ResultType, Value);
        }

        public Instruction ConvertPtrToU(uint ResultType, uint Pointer)
        {
            return EmitConversionInstruction(Op.OpConvertPtrToU, ResultType, Pointer);
        }

        public Instruction SatConvertSToU(uint ResultType, uint SignedValue)
        {
            return EmitConversionInstruction(Op.OpSatConvertSToU, ResultType, SignedValue);
        }

        public Instruction SatConvertUToS(uint ResultType, uint UnsignedValue)
        {
            return EmitConversionInstruction(Op.OpSatConvertUToS, ResultType, UnsignedValue);
        }

        public Instruction ConvertUToPtr(uint ResultType, uint IntegerValue)
        {
            return EmitConversionInstruction(Op.OpConvertUToPtr, ResultType, IntegerValue);
        }

        public Instruction PtrCastToGeneric(uint ResultType, uint Pointer)
        {
            return EmitConversionInstruction(Op.OpPtrCastToGeneric, ResultType, Pointer);
        }

        public Instruction GenericCastToPtr(uint ResultType, uint Pointer)
        {
            return EmitConversionInstruction(Op.OpGenericCastToPtr, ResultType, Pointer);
        }

        public Instruction GenericCastToPtrExplicit(uint ResultType, uint Pointer, StorageClass Storage)
        {
            return EmitConversionInstruction(Op.OpGenericCastToPtrExplicit, ResultType, Pointer, (uint)Storage);
        }

        public Instruction Bitcast(uint ResultType, uint Operand)
        {
            return EmitConversionInstruction(Op.OpBitcast, ResultType, Operand);
        }
        
    }
}
