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
            ModuleTest.Extension("TestExtension");
            ModuleTest.ExtInstImport("GLSL.std.450");
            
            Instruction TypeVoid       = ModuleTest.TypeVoid();
            Instruction TypeFloat      = ModuleTest.TypeFloat(32);
            Instruction TypeInt        = ModuleTest.TypeInt(32, true);
            Instruction TypePointerInt = ModuleTest.TypePointer(StorageClass.Input, TypeInt.TypeId);


            Instruction MainFunctionType = ModuleTest.TypeFunction(TypeVoid);
            Instruction MainFunction     = ModuleTest.CreateFunction(TypeVoid, FunctionControlMask.MaskNone, MainFunctionType);

            Instruction SecondaryFunctionType = ModuleTest.TypeFunction(TypeVoid);
            Instruction SecondaryFunction     = ModuleTest.CreateFunction(TypeVoid, FunctionControlMask.MaskNone, SecondaryFunctionType);

            ModuleTest.EmitCode(MainFunction);
            ModuleTest.Label();
            ModuleTest.FunctionCall(TypeVoid.TypeId, SecondaryFunction.ResultTypeId);
            ModuleTest.EmitCode(Instructions.Return());
            ModuleTest.FunctionEnd();

            ModuleTest.EmitCode(SecondaryFunction);
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
