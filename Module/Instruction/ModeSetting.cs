using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction SetMemoryModel(AddressingModel AddressingModel, MemoryModel MemoryModel)
        {
            this.MemoryModel = CreateInstruction(Op.OpMemoryModel, (uint)AddressingModel, (uint)MemoryModel);

            return this.MemoryModel;
        }

        public Instruction AddEntryPoint(ExecutionModel ExecutionModel, Instruction EntryPoint, string Name, params Instruction[] Interfaces)
        {
            string RegistryName = $"{Name}_{ExecutionModel}";

            Instruction EntryPointInstruction;

            EntryPoints.TryGetValue(RegistryName, out EntryPointInstruction);

            // TODO: return an error/throw an exception for duplicates?
            if (!EntryPoints.ContainsKey(RegistryName))
            {
                // TODO: Enable Capabilities
                EntryPointInstruction = CreateInstruction(Op.OpEntryPoint);

                EntryPointInstruction.PushOperand((uint)ExecutionModel);

                // TODO: check if Function is an OpFunction
                EntryPointInstruction.PushOperandResultTypeId(EntryPoint);
                EntryPointInstruction.PushOperand(Name);
                EntryPointInstruction.PushOperandResultTypeId(Interfaces);
                EntryPoints.Add(RegistryName, EntryPointInstruction);
            }

            return EntryPointInstruction;
        }

        public Instruction AddExecutionMode(Instruction EntryPoint, ExecutionMode ExecutionMode, params uint[] Optionals)
        {
            // TODO: Enable Capabilities
            Instruction ExecutionModeInstruction = CreateInstruction(Op.OpExecutionMode, EntryPoint.ResultTypeId, (uint)ExecutionMode);
            ExecutionModeInstruction.PushOperand(Optionals);

            ExecutionModes.Add(ExecutionModeInstruction);
            return ExecutionModeInstruction;
        }

        public Instruction AddCapability(Capability Capability)
        {
            foreach (Instruction Instruction in Capabilities)
            {
                if ((Capability)Instruction.Words[0] == Capability)
                {
                    return Instruction;
                }
            }

            Instruction CapabilityInstruction = CreateInstruction(Op.OpCapability, (uint)Capability);

            Capabilities.Add(CapabilityInstruction);

            return CapabilityInstruction;
        }
    }
}
