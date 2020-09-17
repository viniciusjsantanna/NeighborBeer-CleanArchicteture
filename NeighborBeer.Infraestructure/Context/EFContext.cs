using Microsoft.EntityFrameworkCore;
using NeighborBeer.Application.Interfaces;
using NeighborBeer.Domain.Entities.Customer;

namespace NeighborBeer.Infrastructure.Context
{
    public class EFContext: DbContext, IEFContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options){}
        public DbSet<Customer> Customers { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
        }
    }
}
