using static Spv.Specification;

namespace Spv.Generator
{
    public partial class Module
    {
        public Instruction AtomicLoad(uint ResultType, uint Pointer, uint Scope, uint Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicLoad, ResultType, Pointer, Scope, Semantics);
        }

        public Instruction AtomicStore(uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitCode(CreateInstruction(Op.OpAtomicStore, Pointer, Scope, Semantics, Value));
        }

        public Instruction AtomicExchange(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicExchange, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicCompareExchange(uint ResultType, uint Pointer, uint Scope, uint EqualSemantics, uint UnEqualSemantics, uint Value, uint Comparator)
        {
            return EmitOperationWithResulType(Op.OpAtomicCompareExchange, ResultType, Pointer, Scope, EqualSemantics, UnEqualSemantics, Value, Comparator);
        }

        public Instruction AtomicCompareExchangeWeak(uint ResultType, uint Pointer, uint Scope, uint EqualSemantics, uint UnEqualSemantics, uint Value, uint Comparator)
        {
            return EmitOperationWithResulType(Op.OpAtomicCompareExchangeWeak, ResultType, Pointer, Scope, EqualSemantics, UnEqualSemantics, Value, Comparator);
        }

        public Instruction AtomicIIncrement(uint ResultType, uint Pointer, uint Scope, uint Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicIIncrement, ResultType, Pointer, Scope, Semantics);
        }

        public Instruction AtomicIDecrement(uint ResultType, uint Pointer, uint Scope, uint Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicIDecrement, ResultType, Pointer, Scope, Semantics);
        }

        public Instruction AtomicIAdd(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicIAdd, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicISub(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicISub, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicSMin(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicSMin, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicUMin(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicUMin, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicSMax(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicSMax, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicUMax(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicUMax, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicAnd(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicAnd, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicOr(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicOr, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicXor(uint ResultType, uint Pointer, uint Scope, uint Semantics, uint Value)
        {
            return EmitOperationWithResulType(Op.OpAtomicXor, ResultType, Pointer, Scope, Semantics, Value);
        }

        public Instruction AtomicFlagTestAndSet(uint ResultType, uint Pointer, uint Scope, uint Semantics)
        {
            return EmitOperationWithResulType(Op.OpAtomicFlagTestAndSet, ResultType, Pointer, Scope, Semantics);
        }

        public Instruction AtomicFlagClear(uint Pointer, uint Scope, uint Semantics)
        {
            return EmitCode(CreateInstruction(Op.OpAtomicFlagClear, Pointer, Scope, Semantics));
        }
    }
}
