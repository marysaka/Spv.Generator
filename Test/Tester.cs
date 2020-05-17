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

                AddTypeDeclaration(new Instruction(Op.OpTypeVoid));
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
