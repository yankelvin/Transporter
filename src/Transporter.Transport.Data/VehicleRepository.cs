using Microsoft.EntityFrameworkCore;
using Transporter.Core.Data;
using Transporter.Transport.Domain.Interfaces;
using Transporter.Transport.Domain.Models;

namespace Transporter.Transport.Data
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly DbSet<Vehicle> _dbSet;

        public VehicleRepository(TransportContext context) : base(context)
        {
            _dbSet = context.Set<Vehicle>();
        }
    }
}
