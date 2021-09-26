using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transporter.Administration.Domain.Models;

namespace Transporter.Administration.Data.Mapping
{
    public class PassengerMapping : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger), "Administration");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.City)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(u => u.Uf)
                .IsRequired()
                .HasMaxLength(2);

            builder.HasOne(p => p.Person)
                .WithOne(p => p.Passenger)
                .HasForeignKey<Passenger>(p => p.PersonId);
        }
    }
}
