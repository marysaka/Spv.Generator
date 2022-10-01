using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Spv.Generator
{
    public struct InstructionOperands
    {
        private const int InternalCount = 5;

        public int Count;
        public Operand Operand1;
        public Operand Operand2;
        public Operand Operand3;
        public Operand Operand4;
        public Operand Operand5;
        public Operand[] Overflow;

        public Span<Operand> AsSpan()
        {
            if (Count > InternalCount)
            {
                return MemoryMarshal.CreateSpan(ref this.Overflow[0], Count);
            }
            else
            {
                return MemoryMarshal.CreateSpan(ref this.Operand1, Count);
            }
        }

        public void Add(Operand operand)
        {
            if (Count < InternalCount)
            {
                MemoryMarshal.CreateSpan(ref this.Operand1, Count + 1)[Count] = operand;
                Count++;
            }
            else
            {
                if (Overflow == null)
                {
                    Overflow = new Operand[InternalCount * 2];
                    MemoryMarshal.CreateSpan(ref this.Operand1, InternalCount).CopyTo(Overflow.AsSpan());
                }
                else if (Count == Overflow.Length)
                {
                    Array.Resize(ref Overflow, Overflow.Length * 2);
                }

                Overflow[Count++] = operand;
            }
        }

        private IEnumerable<Operand> AllOperands => new[] { Operand1, Operand2, Operand3, Operand4, Operand5 }
            .Concat(Overflow ?? Array.Empty<Operand>())
            .Take(Count);

        public override string ToString()
        {
            return $"({string.Join(", ", AllOperands)})";
        }

        public string ToString(string[] labels)
        {
            var labeledParams = AllOperands.Zip(labels, (op, label) => $"{label}: {op}");
            var unlabeledParams = AllOperands.Skip(labels.Length).Select(op => op.ToString());
            var paramsToPrint = labeledParams.Concat(unlabeledParams);
            return $"({string.Join(", ", paramsToPrint)})";
        }
    }
}
