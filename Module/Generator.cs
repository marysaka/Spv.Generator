using System.IO;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction EmitCode(Instruction Instruction)
        {
            if (Instruction.IsTypeDeclaration())
            {
                AddTypeDeclaration(Instruction);
            }
            FunctionsDefinitions.Add(Instruction);
            return Instruction;
        }

        public byte[] Create()
        {
            MemoryStream Stream = new MemoryStream();
            BinaryWriter Writer = new BinaryWriter(Stream);

            // Header of Physical Layout
            Writer.Write(Specification.MagicNumber);
            Writer.Write(Version);
            Writer.Write(GeneratorID);
            Writer.Write(Bound);
            Writer.Write(0);

            foreach (Instruction Capability in Capabilities)
            {
                Capability.Encode(Writer);
            }

            foreach (Instruction Extension in Extensions)
            {
                Extension.Encode(Writer);
            }

            if (ExtendedInstructionSet != null)
                ExtendedInstructionSet.Encode(Writer);

            // 4. TODO: Check validity (nullcheck)
            MemoryModel.Encode(Writer);

            foreach (Instruction EntryPoint in EntryPoints.Values)
            {
                EntryPoint.Encode(Writer);
            }

            foreach (Instruction ExecutionMode in ExecutionModes)
            {
                ExecutionMode.Encode(Writer);
            }

            foreach (Instruction DebugInstruction in DebugInstructions)
            {
                DebugInstruction.Encode(Writer);
            }

            // 8. TODO: All annotation instructions

            foreach (Instruction TypeDeclaration in TypesDeclarations)
            {
                TypeDeclaration.Encode(Writer);
            }

            // 10. TODO: functions "declaration" (functions without a body; there is no forward declaration to a function with a body)

            foreach (Instruction FunctionDefinition in FunctionsDefinitions)
            {
                FunctionDefinition.Encode(Writer);
            }

            byte[] Result = Stream.ToArray();

            Writer.Dispose();
            Stream.Dispose();

            return Result;
        }
    }
}
