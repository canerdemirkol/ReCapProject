using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFreamwork
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null);
        TEntity GetAsNoTrack(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<TEntity> Query();
        Task<int> Execute(FormattableString interpolatedQueryString);
        TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);
        int GetCount(Expression<Func<TEntity, bool>> expression = null);
    }
}
