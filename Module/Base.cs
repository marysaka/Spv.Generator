using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        // TODO register the generator: https://www.khronos.org/registry/spir-v/api/spir-v.xml
        private const uint GeneratorID = 0;

        // TODO: update to latest specs when 1.0 will be fully supported.
        private const uint DefaultVersion = 0x00010000; // Specification.Version

        private uint Bound = 1;
        private uint Version;

        private List<Instruction> Capabilities;
        private List<Instruction> Extensions;
        private Instruction       ExtendedInstructionSet;
        private Instruction       MemoryModel;
        private List<Instruction> TypesDeclarations;
        private List<Instruction> DebugInstructions;
        private List<Instruction> Annotations;
        private List<Instruction> FunctionsDefinitions;

        private Dictionary<string, Instruction> EntryPoints;
        private List<Instruction> ExecutionModes;


        public Module(uint Version = DefaultVersion)
        {
            this.Version           = Version;
            Capabilities           = new List<Instruction>();
            Extensions             = new List<Instruction>();
            ExtendedInstructionSet = null;
            TypesDeclarations      = new List<Instruction>();
            FunctionsDefinitions   = new List<Instruction>();
            DebugInstructions      = new List<Instruction>();
            Annotations            = new List<Instruction>();
            EntryPoints            = new Dictionary<string, Instruction>();
            ExecutionModes         = new List<Instruction>();
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

        private Instruction CreateInstruction(Op Opcode, params uint[] Words)
        {
            return new Instruction(Opcode, new List<uint>(Words));
        }

        public uint AllocateId()
        {
            return Bound++;
        }
    }
}
