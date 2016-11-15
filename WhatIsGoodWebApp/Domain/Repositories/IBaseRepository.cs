using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsGood.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Find(int id);
        TEntity Find(int id, params string[] includes);
        Task<TEntity> FindAsync(int id);
        IQueryable<TEntity> List();
        void Add(TEntity item);
        void Remove(TEntity item);
        void Edit(TEntity item);
    }
}
