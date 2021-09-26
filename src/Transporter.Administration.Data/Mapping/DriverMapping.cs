using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transporter.Administration.Domain.Models;

namespace Transporter.Administration.Data.Mapping
{
    public class DriverMapping : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable(nameof(Driver), "Administration");

            builder.HasKey(u => u.Id);

            builder.HasOne(p => p.Person)
                .WithOne(p => p.Driver)
                .HasForeignKey<Driver>(p => p.PersonId);
        }
    }
}
