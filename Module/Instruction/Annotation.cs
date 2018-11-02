using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction EmitAnnotation(Instruction Instruction)
        {
            Annotations.Add(Instruction);
            return Instruction;
        }

        public Instruction Decorate(uint Target, Decoration Decoration, params uint[] Literals)
        {
            Instruction Decorate = CreateInstruction(Op.OpDecorate, Target, (uint)Decoration);
            Decorate.PushOperand(Literals);

            return EmitAnnotation(Decorate);
        }

        public Instruction MemberDecorate(uint StructureType, uint Member, Decoration Decoration, params uint[] Literals)
        {
            Instruction MemberDecorate = CreateInstruction(Op.OpMemberDecorate, StructureType, Member, (uint)Decoration);
            MemberDecorate.PushOperand(Literals);

            return EmitAnnotation(MemberDecorate);
        }

        public Instruction DecorationGroup()
        {
            Instruction DecorationGroup = CreateInstruction(Op.OpDecorationGroup);
            DecorationGroup.SetResultTypeId(AllocateId());

            return EmitAnnotation(DecorationGroup);
        }

        public Instruction GroupDecorate(uint DecorationGroup, params uint[] Targets)
        {
            Instruction GroupDecorate = CreateInstruction(Op.OpGroupDecorate, DecorationGroup);
            GroupDecorate.PushOperand(Targets);

            return EmitAnnotation(GroupDecorate);
        }

        public Instruction GroupMemberDecorate(uint DecorationGroup, params uint[] Targets)
        {
            Instruction GroupMemberDecorate = CreateInstruction(Op.OpGroupMemberDecorate, DecorationGroup);
            GroupMemberDecorate.PushOperand(Targets);

            return EmitAnnotation(GroupMemberDecorate);
        }
    }
}
