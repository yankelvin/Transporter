using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Transporter.Core.DomainObjects;

namespace Transporter.Core.Data
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task Add(T entity);
        void Update(T entity);
        Task<T> FindById(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> expression);
        Task<bool> SaveChanges();
    }
}
