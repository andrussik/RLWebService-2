using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity);
        TEntity Remove(TEntity entity);
        Task<TEntity> RemoveAsync(Guid id);
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entity);
        IList<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map);
        IQueryable<TEntity> AsQueryable();
    }
}