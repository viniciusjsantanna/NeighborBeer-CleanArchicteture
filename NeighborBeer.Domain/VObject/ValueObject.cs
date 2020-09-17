using System;
using System.Collections.Generic;
using System.Linq;

namespace NeighborBeer.Domain.VObject
{
    public abstract class ValueObject
    {
        public static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if(ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEquality();

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, null))
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEquality().SequenceEqual(other.GetEquality());
        }

        public override int GetHashCode()
        {
            return GetEquality().Select(e => e != null ? e.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
