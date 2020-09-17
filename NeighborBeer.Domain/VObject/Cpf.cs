using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NeighborBeer.Domain.VObject
{
    public class Cpf : IEquatable<Cpf>
    {
        public string _value  { get; }

        public Cpf(){}

        public Cpf(String text)
        {
            _value = text;
        }

        public static implicit operator Cpf(String text)
            => new Cpf(text);
        public bool Equals([AllowNull] Cpf other)
        {
            return _value.Equals(other._value);
        }
        public override string ToString()
        {
            return MaskCpf();
        }

        private string MaskCpf()
        {
            var part1 = this._value.Substring(0, 3);
            var part2 = this._value.Substring(3, 3);
            var part3 = this._value.Substring(6, 3);
            var part4 = this._value.Substring(9);

            return part1 + "." + part2 + "." + part3 + "-" + part4;  
        }
    }
}
