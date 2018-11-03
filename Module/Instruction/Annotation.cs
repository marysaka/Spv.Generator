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

        public Instruction Decorate(Instruction Target, Decoration Decoration, params uint[] Literals)
        {
            Instruction Decorate = CreateInstruction(Op.OpDecorate, Target.ResultTypeId, (uint)Decoration);
            Decorate.PushOperand(Literals);

            return EmitAnnotation(Decorate);
        }

        public Instruction MemberDecorate(Instruction StructureType, uint Member, Decoration Decoration, params uint[] Literals)
        {
            Instruction MemberDecorate = CreateInstruction(Op.OpMemberDecorate, StructureType.ResultTypeId, Member, (uint)Decoration);
            MemberDecorate.PushOperand(Literals);

            return EmitAnnotation(MemberDecorate);
        }

        public Instruction DecorationGroup()
        {
            Instruction DecorationGroup = CreateInstruction(Op.OpDecorationGroup);
            DecorationGroup.SetResultTypeId(AllocateId());

            return EmitAnnotation(DecorationGroup);
        }

        public Instruction GroupDecorate(Instruction DecorationGroup, params uint[] Targets)
        {
            Instruction GroupDecorate = CreateInstruction(Op.OpGroupDecorate, DecorationGroup.ResultTypeId);
            GroupDecorate.PushOperand(Targets);

            return EmitAnnotation(GroupDecorate);
        }

        public Instruction GroupMemberDecorate(Instruction DecorationGroup, params uint[] Targets)
        {
            Instruction GroupMemberDecorate = CreateInstruction(Op.OpGroupMemberDecorate, DecorationGroup.ResultTypeId);
            GroupMemberDecorate.PushOperand(Targets);

            return EmitAnnotation(GroupMemberDecorate);
        }
    }
}
