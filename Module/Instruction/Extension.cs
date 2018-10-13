using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction EmitExtension(Instruction Instruction)
        {
            Extensions.Add(Instruction);
            return Instruction;
        }

        public Instruction Extension(string Name)
        {
            Instruction Extension = CreateInstruction(Op.OpExtension);

            Extension.PushOperand(Name);

            return EmitExtension(Extension);
        }

        public Instruction ExtInstImport(string Name)
        {
            ExtendedInstructionSet = CreateInstruction(Op.OpExtInstImport);

            ExtendedInstructionSet.SetResultTypeId(AllocateId());

            ExtendedInstructionSet.PushOperand(Name);

            return ExtendedInstructionSet;
        }
    }
}
