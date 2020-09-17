using NeighborBeer.Domain.VObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Application.DTOs.Customer
{
    public class CustomerDTO : Response
    {
        public Name Name { get; set; }
        public Cpf Cpf { get; set; }
    }
}
