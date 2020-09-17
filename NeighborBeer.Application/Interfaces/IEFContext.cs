using Microsoft.EntityFrameworkCore;
using NeighborBeer.Domain.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Application.Interfaces
{
    public interface IEFContext
    {
        DbSet<Customer> Customers { get; }
    }
}
