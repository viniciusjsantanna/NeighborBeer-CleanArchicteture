using NeighborBeer.Domain.VObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Domain.Entities.Customer
{
    public class Person : ValueObject
    {
        public Name Name { get; set; }
        public Name LastName { get; set; }

        protected override IEnumerable<object> GetEquality()
        {
            yield return Name;
            yield return LastName;
        }
    }
}
