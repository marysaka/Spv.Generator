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

            public void Construct()
            {
                AddCapability(Capability.Shader);
                Instruction glslStd450 = AddExtInstImport("GLSL.std.450");
                SetMemoryModel(AddressingModel.Logical, MemoryModel.Simple);

                Instruction floatType = TypeFloat(32);
                Instruction floatInputType = TypePointer(StorageClass.Input, floatType);
                Instruction floatOutputType = TypePointer(StorageClass.Output, floatType);
                Instruction vec4Type = TypeVector(floatType, 4);
                Instruction vec4OutputPtrType = TypePointer(StorageClass.Output, vec4Type);

                Instruction inputTest = Variable(floatInputType, StorageClass.Input);
                Instruction outputTest = Variable(floatOutputType, StorageClass.Output);
                Instruction outputColor = Variable(vec4OutputPtrType, StorageClass.Output);

                Name(inputTest, "inputTest");
                Name(outputColor, "outputColor");
                AddGlobalVariable(inputTest);
                AddGlobalVariable(outputTest);
                AddGlobalVariable(outputColor);

                Instruction rColor = Constant(floatType, 0.5f);
                Instruction gColor = Constant(floatType, 0.0f);
                Instruction bColor = Constant(floatType, 0.0f);
                Instruction aColor = Constant(floatType, 1.0f);

                Instruction compositeColor = ConstantComposite(vec4Type, rColor, gColor, bColor, aColor);

                Instruction voidType = TypeVoid();

                Instruction mainFunctionType = TypeFunction(voidType, true);
                Instruction mainFunction = Function(voidType, FunctionControlMask.MaskNone, mainFunctionType);
                AddLabel(Label());

                Instruction tempInput = Load(floatType, inputTest);

                Instruction resultSqrt = ExtInst(floatType, glslStd450, 31, tempInput);

                Store(outputTest, resultSqrt);
                Store(outputColor, compositeColor);

                Return();
                FunctionEnd();

                AddEntryPoint(ExecutionModel.Fragment, mainFunction, "main", inputTest, outputTest, outputColor);
                AddExecutionMode(mainFunction, ExecutionMode.OriginLowerLeft);
            }
        }

        static void Main(string[] Args)
        {
            TestModule module = new TestModule();
            module.Construct();

            byte[] ModuleData = module.Generate();

            File.WriteAllBytes(Args[0], ModuleData);

            Console.WriteLine(Args[0]);
        }
    }
}
