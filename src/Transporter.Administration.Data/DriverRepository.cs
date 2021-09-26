using Microsoft.EntityFrameworkCore;
using Transporter.Administration.Domain.Interfaces;
using Transporter.Administration.Domain.Models;
using Transporter.Core.Data;

namespace Transporter.Administration.Data
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        private readonly DbSet<Driver> _dbSet;

        public DriverRepository(AdministrationContext context) : base(context)
        {
            _dbSet = context.Set<Driver>();
        }
    }
}
