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
            

            //ModuleTest.TypeMatrix(ModuleTest.TypeVector(ModuleTest.TypeFloat(32), 4), 4);

            Instruction TypeVoid       = ModuleTest.TypeVoid();
            Instruction TypeFloat      = ModuleTest.TypeFloat(32);
            Instruction TypeInt        = ModuleTest.TypeInt(32, true);
            Instruction TypePointerInt = ModuleTest.TypePointer(StorageClass.Input, TypeInt.TypeId);


            Instruction MainFunctionType = ModuleTest.TypeFunction(TypeVoid);
            Instruction MainFunction     = ModuleTest.Function(TypeVoid, FunctionControlMask.MaskNone, MainFunctionType);

            //ModuleTest.FunctionParameter(TypeInt.TypeId);
            //ModuleTest.FunctionParameter(TypeFloat.TypeId);

            ModuleTest.Label();
            ModuleTest.EmitCode(Instructions.Return());
            ModuleTest.FunctionEnd();

            Instruction SecondaryFunctionType = ModuleTest.TypeFunction(TypeVoid, TypeInt);
            Instruction SecondaryFunction     = ModuleTest.Function(TypeVoid, FunctionControlMask.MaskNone, SecondaryFunctionType);
            ModuleTest.FunctionParameter(TypeInt.TypeId);
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
