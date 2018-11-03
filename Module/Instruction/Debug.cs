using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {

        public Instruction EmitDebug(Instruction Instruction)
        {
            // TODO: detect forward references and rejects them for the section 7.
            DebugInstructions.Add(Instruction);
            return Instruction;
        }

        public Instruction SourceContinued(string ContinuedSource)
        {
            Instruction SourceContinued = CreateInstruction(Op.OpSourceContinued);

            SourceContinued.PushOperand(ContinuedSource);

            return EmitDebug(SourceContinued);
        }

        public Instruction Source(SourceLanguage SourceLanguage)
        {
            return EmitDebug(CreateInstruction(Op.OpSource, (uint)SourceLanguage));
        }

        public Instruction Source(SourceLanguage SourceLanguage, uint Version)
        {
            return EmitDebug(CreateInstruction(Op.OpSource, (uint)SourceLanguage, Version));
        }

        public Instruction Source(SourceLanguage SourceLanguage, uint Version, Instruction File)
        {
            return EmitDebug(CreateInstruction(Op.OpSource, (uint)SourceLanguage, Version, File.ResultTypeId));
        }

        public Instruction SourceExtension(string Extension)
        {
            Instruction SourceExtension = CreateInstruction(Op.OpSourceExtension);

            SourceExtension.PushOperand(Extension);

            return EmitDebug(SourceExtension);
        }

        public Instruction Name(Instruction Target, string Name)
        {
            Instruction NameInstruction = CreateInstruction(Op.OpName, Target.ResultTypeId);

            NameInstruction.PushOperand(Name);

            return EmitDebug(NameInstruction);
        }

        public Instruction MemberName(Instruction Type, uint Member, string Name)
        {
            Instruction MemberName = CreateInstruction(Op.OpMemberName, Type.ResultTypeId, Member);

            MemberName.PushOperand(Name);

            return EmitDebug(MemberName);
        }

        public Instruction String(string Name)
        {
            Instruction String = CreateInstruction(Op.OpString);
            String.SetResultTypeId(AllocateId());
            String.PushOperand(Name);

            return EmitDebug(String);
        }

        public Instruction Line(Instruction File, uint Line, uint Column)
        {
            return EmitCode(CreateInstruction(Op.OpLine, File.ResultTypeId, Line, Column));
        }

        public Instruction NoLine()
        {
            return EmitCode(CreateInstruction(Op.OpNoLine));
        }
    }
}
