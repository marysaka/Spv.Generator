using System;
using System.IO;

using static Spv.Specification;

namespace Spv.Generator.Test
{
    class Tester
    {
        public class TestModule : Module
        {
            public TestModule() : base(Specification.Version) {}

            protected override void Construct()
            {
                SetMemoryModel(AddressingModel.Logical, MemoryModel.GLSL450);

                AddCapability(Capability.Shader);
                AddExtension("SomeExtension");

                Instruction extImport = AddExtInstImport("GLSL.std.450");

                Instruction typeVoid = TypeVoid();
                Instruction typeFloat = TypeFloat(32);
                Instruction typeInt = TypeInt(32, true);
                Instruction typePointer = TypePointer(StorageClass.Input, typeInt);
                Instruction mainFunctionType = TypeFunction(typeVoid);
                Instruction secondaryFunctionType = TypeFunction(typeVoid); // Will end up using the same Id as mainFunctionType as it's duplicated.

                Instruction secondaryFunction = Function(typeVoid, FunctionControlMask.MaskNone, secondaryFunctionType);
                AddLabel(Label());
                Return();
                FunctionEnd();

                Instruction mainFunction = Function(typeVoid, FunctionControlMask.MaskNone, mainFunctionType);
                AddLabel(Label());
                FunctionCall(typeVoid, secondaryFunction);
                Return();
                FunctionEnd();

                AddEntryPoint(ExecutionModel.Fragment, mainFunction, "main");
                AddExecutionMode(mainFunction, ExecutionMode.OriginLowerLeft);
            }
        }

        static void Main(string[] Args)
        {
            Module module = new TestModule();

            byte[] ModuleData = module.Generate();

            File.WriteAllBytes(Args[0], ModuleData);

            Console.WriteLine(Args[0]);
        }
    }
}
