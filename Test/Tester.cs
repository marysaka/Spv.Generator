using System;
using System.IO;

using static Spv.Specification;

namespace Spv.Generator.Test
{
    class Tester
    {
        static void Main(string[] Args)
        {
            Module ModuleTest = new Module();
            ModuleTest.AddCapability(Capability.Shader);
            ModuleTest.SetMemoryModel(AddressingModel.Logical, MemoryModel.GLSL450);

            Instruction MainFunctionType = ModuleTest.TypeFunction(ModuleTest.TypeVoid());
            Instruction MainFunction     = ModuleTest.FunctionStart(ModuleTest.TypeVoid(), FunctionControlMask.MaskNone, MainFunctionType);

            ModuleTest.Label();
            ModuleTest.EmitCode(Instructions.Return());
            ModuleTest.FunctionEnd();

            ModuleTest.EntryPoint(ExecutionModel.Vertex, MainFunction, "main");

            byte[] ModuleData = ModuleTest.Create();

            File.WriteAllBytes(Args[0], ModuleData);

            Console.WriteLine(Args[0]);
        }
    }
}
