using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction AtomicLoad(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicLoad, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId);
        }

        public Instruction AtomicStore(Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitCode(CreateInstruction(Op.OpAtomicStore, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId));
        }

        public Instruction AtomicExchange(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicExchange, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicCompareExchange(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction EqualSemantics, Instruction UnEqualSemantics, Instruction Value, Instruction Comparator)
        {
            return EmitOperationWithResulType(Op.OpAtomicCompareExchange, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, EqualSemantics.ResultTypeId, UnEqualSemantics.ResultTypeId, Value.ResultTypeId, Comparator.ResultTypeId);
        }

        public Instruction AtomicCompareExchangeWeak(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction EqualSemantics, Instruction UnEqualSemantics, Instruction Value, Instruction Comparator)
        {
            return EmitOperationWithResulType(Op.OpAtomicCompareExchangeWeak, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, EqualSemantics.ResultTypeId, UnEqualSemantics.ResultTypeId, Value.ResultTypeId, Comparator.ResultTypeId);
        }

        public Instruction AtomicIIncrement(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicIIncrement, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId);
        }

        public Instruction AtomicIDecrement(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicIDecrement, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId);
        }

        public Instruction AtomicIAdd(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicIAdd, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicISub(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicISub, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicSMin(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicSMin, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicUMin(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicUMin, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicSMax(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicSMax, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicUMax(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicUMax, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicAnd(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicAnd, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicOr(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicOr, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicXor(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics, Instruction Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicXor, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId, Value.ResultTypeId);
        }

        public Instruction AtomicFlagTestAndSet(Instruction ResultType, Instruction Pointer, Instruction Scope, Instruction Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicFlagTestAndSet, ResultType, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId);
        }

        public Instruction AtomicFlagClear(Instruction Pointer, Instruction Scope, Instruction Semantics)
        {
            return EmitCode(CreateInstruction(Op.OpAtomicFlagClear, Pointer.ResultTypeId, Scope.ResultTypeId, Semantics.ResultTypeId));
        }
    }
}
