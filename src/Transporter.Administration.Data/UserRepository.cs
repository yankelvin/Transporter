using Microsoft.EntityFrameworkCore;
using Transporter.Administration.Domain.Interfaces;
using Transporter.Administration.Domain.Models;
using Transporter.Core.Data;

namespace Transporter.Administration.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(AdministrationContext context) : base(context)
        {
            _dbSet = context.Set<User>();
        }
    }
}
