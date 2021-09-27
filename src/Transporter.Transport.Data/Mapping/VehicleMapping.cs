using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Data.Mapping
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle), "Transport");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.VehicleType)
                .IsRequired();

            builder.Property(u => u.LicensePlate)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(u => u.Brand)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Model)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Year)
                .IsRequired();

            builder.Property(u => u.Capacity)
                .IsRequired();

            builder.Property(u => u.CpfDriver)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasMany(p => p.TransportRecords)
                .WithOne(p => p.Vehicle)
                .HasForeignKey(p => p.Id);
        }
    }
}
