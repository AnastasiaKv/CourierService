using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> GetByPage(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(Guid id);
        bool Insert(TEntity entity);
        bool Delete(TEntity entity);
        void Delete(Guid id);
        bool Update(TEntity entity);
        void Save();
        void Dispose(bool disposing);
        void Dispose();
    }
}
