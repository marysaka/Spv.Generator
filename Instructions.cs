using System;
using System.Collections.Generic;
using System.Text;

using static Spv.Specification;


namespace Spv.Generator
{
    public static class Instructions
    {
        public static Instruction CreateInstruction(Op Opcode, params uint[] Words)
        {
            return new Instruction(Opcode, new List<uint>(Words));
        }

        public static Instruction Nop()
        {
            return CreateInstruction(Op.OpNop);
        }

        public static Instruction Capability(Capability Capability)
        {
            return CreateInstruction(Op.OpCapability, (uint)Capability);
        }

        public static Instruction MemoryModel(AddressingModel AddressingModel, MemoryModel MemoryModel)
        {
            return CreateInstruction(Op.OpMemoryModel, (uint)AddressingModel, (uint)MemoryModel);
        }

        public static Instruction EntryPoint(ExecutionModel ExecutionModel, Instruction Function, string Name, params Instruction[] Interfaces)
        {
            // TODO: check if Function is an OpFunction
            Instruction Result = CreateInstruction(Op.OpEntryPoint);

            Result.PushOperand((uint)ExecutionModel);
            Result.PushOperandResultTypeId(Function);
            Result.PushOperand(Name);
            Result.PushOperandTypeId(Interfaces);

            return Result;
        }

        public static Instruction Function(Instruction ReturnType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            Instruction Result = CreateInstruction(Op.OpFunction);

            Result.SetTypeId(ReturnType);
            Result.PushOperand((uint)FunctionControl);
            Result.PushOperandTypeId(FunctionType);

            return Result;
        }

        public static Instruction Label()
        {
            return CreateInstruction(Op.OpLabel);
        }

        public static Instruction FunctionEnd()
        {
            return CreateInstruction(Op.OpFunctionEnd);
        }

        public static Instruction Return()
        {
            return CreateInstruction(Op.OpReturn);
        }

        public static Instruction TypeVoid()
        {
            return CreateInstruction(Op.OpTypeVoid);
        }

        public static Instruction TypeBool()
        {
            return CreateInstruction(Op.OpTypeBool);
        }

        public static Instruction TypeInt(int Width, bool Signed)
        {
            return CreateInstruction(Op.OpTypeInt, (uint)Width, Signed ? 1u: 0u);
        }

        public static Instruction TypeFloat(int Width)
        {
            return CreateInstruction(Op.OpTypeFloat, (uint)Width);
        }

        public static Instruction TypeFunction(Instruction ReturnType, params Instruction[] Params)
        {
            Instruction Result = CreateInstruction(Op.OpTypeFunction);

            Result.PushOperandTypeId(ReturnType);
            Result.PushOperandTypeId(Params);

            return Result;
        }
    }
}
