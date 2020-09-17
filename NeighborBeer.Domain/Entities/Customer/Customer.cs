using NeighborBeer.Domain.VObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Domain.Entities.Customer
{
    public class Customer: BaseEntity
    {
        public Person Person { get; set; }
        public Cpf Cpf { get; set; }
    }
}
