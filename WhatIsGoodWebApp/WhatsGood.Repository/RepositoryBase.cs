using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WhatsGood.Domain.Entities;
using WhatsGood.Domain.Repositories;

namespace WhatsGood.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : EntityBase
    {
        protected EventDbContext Context;

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            Context = unitOfWork as EventDbContext;
        }

        protected DbSet<TEntity> CurrentSet
        {
            get { return Context.Set<TEntity>(); }
        }

        public TEntity Find(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity Find(int id, params string[] includes)
        {
            var query = Context.Set<TEntity>().Where(entity => entity.Id == id);
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.FirstOrDefault();
        }

        public Task<TEntity> FindAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> List()
        {
            return Context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        public void Remove(TEntity item)
        {
            Context.Set<TEntity>().Remove(item);
        }

        public void Edit(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = Context.Entry(item);

            if (entry.State != EntityState.Detached) return;

            TEntity attachedEntity = CurrentSet.Local.SingleOrDefault(e => e.Id == item.Id); 

            if (attachedEntity != null)
            {
                var attachedEntry = Context.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(item);
            }
            else
            {
                entry.State = EntityState.Modified;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }

   



}
