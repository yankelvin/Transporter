using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Data.Mapping
{
    public class TransportRecordMapping : IEntityTypeConfiguration<TransportRecord>
    {
        public void Configure(EntityTypeBuilder<TransportRecord> builder)
        {
            builder.ToTable(nameof(TransportRecord), "Transport");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.CpfPassenger)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(u => u.TransportDate)
                .IsRequired();

            builder.Property(u => u.LicensePlate)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(u => u.Price)
                .IsRequired();

            builder.Property(u => u.Kilometers)
                .IsRequired();

            builder.HasOne(p => p.Vehicle)
                .WithMany(p => p.TransportRecords)
                .HasForeignKey(p => p.VehicleId);
        }
    }
}
