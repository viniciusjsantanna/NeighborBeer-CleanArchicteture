using System;
using System.Collections.Generic;

namespace NeighborBeer.Domain.VObject
{
    public class Name : ValueObject
    {
        public String Text { get; private set; }


        public static implicit operator Name(String text)
            => new Name(text);

        public Name() { }

        public Name(String text)
        {
            this.Text = text;
        }
        protected override IEnumerable<object> GetEquality()
        {
            yield return Text;
        }
    }
}
