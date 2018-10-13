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
            ModuleTest.Extension("SPV_AMD_shader_explicit_vertex_parameter");
            ModuleTest.ExtInstImport("GLSL.std.450");
            
            ModuleTest.TypeMatrix(ModuleTest.TypeVector(ModuleTest.TypeFloat(32), 4), 4);

            Instruction MainFunctionType = ModuleTest.TypeFunction(ModuleTest.TypeVoid());
            Instruction MainFunction     = ModuleTest.FunctionStart(ModuleTest.TypeVoid(), FunctionControlMask.MaskNone, MainFunctionType);

            ModuleTest.Undef(ModuleTest.TypeVoid().TypeId);
            ModuleTest.ConstantTrue(ModuleTest.TypeBool().TypeId);


            ModuleTest.Label();
            ModuleTest.EmitCode(Instructions.Return());
            ModuleTest.FunctionEnd();

            ModuleTest.AddEntryPoint(ExecutionModel.Fragment, MainFunction, "main");
            ModuleTest.AddExecutionMode(MainFunction, ExecutionMode.OriginLowerLeft);

            byte[] ModuleData = ModuleTest.Create();

            File.WriteAllBytes(Args[0], ModuleData);

            Console.WriteLine(Args[0]);
        }
    }
}
