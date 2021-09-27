using Microsoft.EntityFrameworkCore;
using Transporter.Core.Data;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Data
{
    public class TransportContext : CoreContext
    {
        public TransportContext(DbContextOptions<TransportContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TransportRecord> TransportRecords { get; set; }
    }
}
