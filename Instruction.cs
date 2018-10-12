using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static Spv.Specification;

namespace Spv.Generator
{
    public class Instruction : IEquatable<Instruction>
    {
        public Op OpCode { get; private set; }

        public List<uint> Words { get; private set; }

        // optioanl
        public  bool HasTypeId { get; private set; }
        private bool HasResultTypeId;
        private uint TypeId;
        private uint ResultTypeId;


        public Instruction(Op OpCode, List<uint> Words = null)
        {
            this.OpCode = OpCode;
            this.Words = Words;
            if (this.Words == null)
                this.Words = new List<uint>();
        }

        public void PushOperand(uint Operand)
        {
            Words.Add(Operand);
        }

        public void PushOperand(int Operand)
        {
            PushOperand((uint)Operand);
        }

        public void PushOperandTypeId(Instruction Operand)
        {
            // TODO: error out if it doesn't have a type id.
            Words.Add(Operand.TypeId);
        }

        public void PushOperandResultTypeId(Instruction Operand)
        {
            Words.Add(Operand.ResultTypeId);
        }

        public void PushOperandTypeId(Instruction[] Operands)
        {
            foreach (Instruction Operand in Operands)
            {
                PushOperandTypeId(Operand);
            }
        }


        public void PushOperand(uint[] Operands)
        {
            Words.AddRange(Operands);
        }

        public void PushOperand(string Operand)
        {
            int OperandSize = Operand.Length;

            if (OperandSize == 0)
            {
                OperandSize = 4;
            }

            for (int i = 0; i < 4 - (OperandSize % 4); i++)
            {
                Operand += '\0';
            }

            byte[] RawOperand = Encoding.ASCII.GetBytes(Operand);
            uint[] Encoded = new uint[RawOperand.Length / 4];

            Buffer.BlockCopy(RawOperand, 0, Encoded, 0, RawOperand.Length);
            PushOperand(Encoded);
        }

        public Instruction SetTypeId(uint TypeId)
        {
            this.HasTypeId = true;
            this.TypeId = TypeId;
            return this;
        }

        public Instruction SetTypeId(Instruction TypeId)
        {
            return SetTypeId(TypeId.TypeId);
        }

        public Instruction SetResultTypeId(Instruction ReturnType)
        {
            return SetResultTypeId(ReturnType.TypeId);
        }

        public Instruction SetResultTypeId(uint ResultTypeId)
        {
            this.HasResultTypeId = true;
            this.ResultTypeId = ResultTypeId;
            return this;
        }

        public void Encode(BinaryWriter Writer)
        {
            ushort WordCount = (ushort)Words.Count;

            WordCount++;

            if (HasTypeId)
                WordCount++;

            if (HasResultTypeId)
                WordCount++;

            // Opcode
            Writer.Write((ushort)OpCode);
            Writer.Write(WordCount);

            if (HasTypeId)
                Writer.Write(TypeId);

            if (HasResultTypeId)
                Writer.Write(ResultTypeId);

            // Words
            foreach (uint Word in Words)
            {
                Writer.Write(Word);
            }

        }

        public bool IsType()
        {
            return OpCode == Op.OpTypeVoid || OpCode == Op.OpTypeBool || OpCode == Op.OpTypeInt
                || OpCode == Op.OpTypeFloat || OpCode == Op.OpTypeVector || OpCode == Op.OpTypeMatrix
                || OpCode == Op.OpTypeImage || OpCode == Op.OpTypeSampler || OpCode == Op.OpTypeSampledImage
                || OpCode == Op.OpTypeArray || OpCode == Op.OpTypeRuntimeArray || OpCode == Op.OpTypeStruct
                || OpCode == Op.OpTypeOpaque || OpCode == Op.OpTypePointer || OpCode == Op.OpTypeFunction
                || OpCode == Op.OpTypeEvent || OpCode == Op.OpTypeDeviceEvent || OpCode == Op.OpTypeReserveId
                || OpCode == Op.OpTypeQueue || OpCode == Op.OpTypePipe || OpCode == Op.OpTypeForwardPointer
                || OpCode == Op.OpTypePipeStorage || OpCode == Op.OpTypeNamedBarrier
                || OpCode == Op.OpTypeAccelerationStructureNVX;
        }

        public bool IsGlobalVariable()
        {
            return OpCode == Op.OpVariable && Words.Count >= 2 && (StorageClass)Words[1] != StorageClass.Function;
        }

        public bool IsConstant()
        {
            return OpCode == Op.OpConstant || OpCode == Op.OpSpecConstantTrue
                || OpCode == Op.OpSpecConstantFalse || OpCode == Op.OpSpecConstant
                || OpCode == Op.OpSpecConstantComposite || OpCode == Op.OpSpecConstantOp;
        }

        public bool IsTypeDeclaration()
        {
            return IsType() || IsConstant() || IsGlobalVariable();
        }

        public override bool Equals(object Other)
        {
            if (Other == null || this.GetType() != Other.GetType())
            {
                return false;
            }
            return Equals((Instruction)Other);
        }

        public bool Equals(Instruction Other)
        {
            bool Result = OpCode == Other.OpCode
                && Words.Count == Other.Words.Count;

            if (Result)
            {
                for (int i = 0; i < Words.Count; i++)
                {
                    if (Words[i] != Other.Words[i])
                    {
                        return false;
                    }
                }
            }
            return Result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OpCode, Words, HasTypeId, HasResultTypeId, TypeId, ResultTypeId);
        }
    }
}
