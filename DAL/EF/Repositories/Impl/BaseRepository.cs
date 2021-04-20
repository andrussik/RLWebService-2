using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Repositories.Impl
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        private readonly AppDbContext _dbContext;
        protected DbSet<TEntity> RepoDbSet { get; }

        protected BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            RepoDbSet = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await RepoDbSet
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await RepoDbSet.FindAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await RepoDbSet
                .AsQueryable()
                .AsNoTracking()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await RepoDbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            entities = entities.ToList();
            await RepoDbSet.AddRangeAsync(entities);
            return entities;
        }

        public TEntity Remove(TEntity entity)
        {
            RepoDbSet.Remove(entity);
            return entity;
        }

        public async Task<TEntity> RemoveAsync(Guid id)
        {
            var entity = await GetAsync(id);
            RepoDbSet.Remove(entity);
            return entity;
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            entities = entities.ToList();
            RepoDbSet.RemoveRange(entities);
            return entities;
        }

        public IList<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                _dbContext.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
        }

        // NB! For testing purpose only! Please avoid passing IQueryable to BLL.
        public IQueryable<TEntity> AsQueryable()
        {
            return RepoDbSet.AsQueryable();
        }
    }
}