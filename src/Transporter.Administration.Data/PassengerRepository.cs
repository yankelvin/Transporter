using Microsoft.EntityFrameworkCore;
using Transporter.Administration.Domain.Interfaces;
using Transporter.Administration.Domain.Models;
using Transporter.Core.Data;

namespace Transporter.Administration.Data
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        private readonly DbSet<Passenger> _dbSet;

        public PassengerRepository(AdministrationContext context) : base(context)
        {
            _dbSet = context.Set<Passenger>();
        }
    }
}
