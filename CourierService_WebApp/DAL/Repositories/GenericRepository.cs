using DAL.IRepositories;
using DBModel.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public CourierServiceContext context;
        public DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            this.context = new CourierServiceContext();
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            IEnumerable<TEntity> enumer = context.Set<TEntity>();
            return enumer;
        }
        public IEnumerable<TEntity> GetByPage(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> enumer = dbSet;

            if (filter != null)
            {
                enumer = enumer.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                enumer = enumer.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(enumer).ToList();
            }
            else
            {
                return enumer.ToList();
            }
        }
        public virtual TEntity GetByID(Guid id)
        {
            return dbSet.Find(id);
        }
        public virtual bool Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return true;
        }
        public virtual bool Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return true;
        }
        public virtual void Delete(Guid id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual bool Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Added;
            return true;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
