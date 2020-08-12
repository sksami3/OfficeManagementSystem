using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Core.Interface.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FindById(long Id);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        bool InsertRange(IEnumerable<TEntity> entities);
        bool DeleteRange(IEnumerable<TEntity> entities);
    }
}
