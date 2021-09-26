using Microsoft.EntityFrameworkCore;
using Transporter.Administration.Domain.Interfaces;
using Transporter.Administration.Domain.Models;
using Transporter.Core.Data;

namespace Transporter.Administration.Data
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly DbSet<Person> _dbSet;

        public PersonRepository(AdministrationContext context) : base(context)
        {
            _dbSet = context.Set<Person>();
        }
    }
}
