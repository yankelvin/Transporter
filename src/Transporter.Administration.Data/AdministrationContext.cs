using Microsoft.EntityFrameworkCore;
using Transporter.Administration.Domain.Models;
using Transporter.Core.Data;

namespace Transporter.Administration.Data
{
    public class AdministrationContext : CoreContext
    {
        public AdministrationContext(DbContextOptions<AdministrationContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
