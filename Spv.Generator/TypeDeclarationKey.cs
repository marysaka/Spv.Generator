using System;
using System.Diagnostics.CodeAnalysis;

namespace Spv.Generator
{
    internal struct TypeDeclarationKey : IEquatable<TypeDeclarationKey>
    {
        private Instruction _typeDeclaration;
        private bool _forcedAllocation;

        public TypeDeclarationKey(Instruction typeDeclaration, bool isForcedAllocation)
        {
            _typeDeclaration = typeDeclaration;
            _forcedAllocation = isForcedAllocation;
        }

        public override int GetHashCode()
        {
            if(_forcedAllocation) return HashCode.Combine(_typeDeclaration);
            else return DeterministicHashCode.Combine(_typeDeclaration.Opcode, _typeDeclaration.GetHashCodeContent());
        }

        public bool Equals(TypeDeclarationKey other)
        {
            if(_forcedAllocation) return _typeDeclaration == other._typeDeclaration;
            else return _typeDeclaration.Opcode == other._typeDeclaration.Opcode && _typeDeclaration.EqualsContent(other._typeDeclaration);
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return obj is TypeDeclarationKey && Equals((TypeDeclarationKey)obj);
        }
    }
}