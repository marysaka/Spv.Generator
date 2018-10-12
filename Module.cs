using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static Spv.Specification;

namespace Spv.Generator
{
    class Module
    {
        // TODO register the generator: https://www.khronos.org/registry/spir-v/api/spir-v.xml
        private const uint GeneratorID = 0;

        private uint Bound = 1;
        private uint Version;
        private List<Instruction> Capabilities;
        private Instruction       MemoryModel;
        private List<Instruction> TypesDeclarations;
        private List<Instruction> FunctionsDefinitions;
        private Dictionary<string, Instruction> EntryPoints;


        public Module(uint Version = Specification.Version)
        {
            this.Version = Version;
            this.Capabilities = new List<Instruction>();
            this.TypesDeclarations = new List<Instruction>();
            this.FunctionsDefinitions = new List<Instruction>();
            this.EntryPoints = new Dictionary<string, Instruction>();
        }

        public void AddCapability(Capability Capability)
        {
            foreach (Instruction Instruction in Capabilities)
            {
                if ((Capability)Instruction.Words[0] == Capability)
                {
                    break;
                }
            }
            Capabilities.Add(Instructions.Capability(Capability));
        }

        public void SetMemoryModel(AddressingModel AddressingModel, MemoryModel MemoryModel)
        {
            this.MemoryModel = Instructions.MemoryModel(AddressingModel, MemoryModel);
        }

        public void EntryPoint(ExecutionModel ExecutionModel, Instruction Function, string Name, params Instruction[] Interfaces)
        {
            string RegistryName = $"{Name}_{ExecutionModel}";
            if (!EntryPoints.ContainsKey(RegistryName))
                EntryPoints.Add(RegistryName, Instructions.EntryPoint(ExecutionModel, Function, Name, Interfaces));
        }

        // Types
        public Instruction TypeVoid()
        {
            return AddTypeDeclaration(Instructions.TypeVoid());
        }

        public Instruction TypeBool()
        {
            return AddTypeDeclaration(Instructions.TypeBool());
        }

        public Instruction TypeInt(int Width, bool Signed)
        {
            if (Width == 8)
            {
                AddCapability(Capability.Int8);
            }
            else if (Width == 16)
            {
                AddCapability(Capability.Int16);
            }
            else if (Width == 64)
            {
                AddCapability(Capability.Int64);
            }

            return AddTypeDeclaration(Instructions.TypeInt(Width, Signed));
        }

        public Instruction TypeFloat(int Width)
        {
            if (Width == 16)
            {
                AddCapability(Capability.Float16);
            }
            else if (Width == 64)
            {
                AddCapability(Capability.Float64);
            }

            return AddTypeDeclaration(Instructions.TypeFloat(Width));
        }

        public Instruction TypeFunction(Instruction ReturnType, params Instruction[] Params)
        {
            return AddTypeDeclaration(Instructions.TypeFunction(ReturnType, Params));
        }

        public Instruction FunctionStart(Instruction ReturnType, FunctionControlMask FunctionControl, Instruction FunctionType)
        {
            return EmitCode(Instructions.Function(ReturnType, FunctionControl, FunctionType).SetResultTypeId(Bound++));
        }

        public Instruction Label()
        {
            return EmitCode(Instructions.Label().SetResultTypeId(Bound++));
        }

        public Instruction FunctionEnd()
        {
            return EmitCode(Instructions.FunctionEnd());
        }

        public Instruction AddTypeDeclaration(Instruction Type)
        {
            int ListIndex = TypesDeclarations.IndexOf(Type);
            // FIXME: IMPLEMENT EQUALS IN INSTRUCTION
            if (ListIndex < 0)
            {
                if (!Type.HasTypeId)
                {
                    Type.SetTypeId(Bound++);
                }
                TypesDeclarations.Add(Type);
                return Type;
            }
            return TypesDeclarations[ListIndex];
        }

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

            // 2. TODO: All extentions?

            // 3. TODO: OpExtInstImport if present

            // 4. TODO: Check validity (nullcheck)
            MemoryModel.Encode(Writer);

            foreach (Instruction EntryPoint in EntryPoints.Values)
            {
                EntryPoint.Encode(Writer);
            }

            // 6. TODO: all execution mode

            // 7. TODO: some of the debug instructions

            // 8. TODO: All annotation instructions

            // 9. TODO: All type declarations
            foreach (Instruction TypeDeclaration in TypesDeclarations)
            {
                TypeDeclaration.Encode(Writer);
            }

            // 10. TODO: functions "declaration" (functions without a body; there is no forward declaration to a function with a body)

            // 11. TODO: functions definitions
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
