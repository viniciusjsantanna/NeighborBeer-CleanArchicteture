using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeighborBeer.Domain.Entities.Customer;

namespace NeighborBeer.Infrastructure.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property<int>(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.ModifyDate)
                .HasColumnType("datetime")
                .IsRequired();
            builder.OwnsOne(
                    e => e.Cpf,
                    vObj =>
                    {
                        vObj.Property(e => e._value)
                            .HasColumnType("varchar(11)")
                            .HasColumnName("Cpf");
                    });

            builder.OwnsOne(
                   e => e.Person,
                   vObj =>
                   {
                       vObj.OwnsOne(
                            e => e.Name,
                            vObj =>
                            {
                                vObj.Property(e => e.Text)
                                   .HasColumnType("varchar(50)")
                                   .HasColumnName("Name");
                            });

                       vObj.OwnsOne(
                           e => e.LastName,
                           vObj =>
                           {
                               vObj.Property(e => e.Text)
                                  .HasColumnType("varchar(50)")
                                  .HasColumnName("LastName");
                           });
                   });
        }
    }
}
