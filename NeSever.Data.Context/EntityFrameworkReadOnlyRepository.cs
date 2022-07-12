using HappyFit.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NeSever.Data.Context
{
    public class EntityFrameworkReadOnlyRepository : IReadOnlyRepository
    {
        public NeSeverCoreProjectDBContext dbContext;

        public EntityFrameworkReadOnlyRepository(IDbFactory dbFactory)
        {
            this.dbContext = dbFactory.GetNeSeverCoreProjectDBContext;
        }

        public IQueryable<TEntity> SelectInclude<TEntity>(Expression<Func<TEntity, object>> include) where TEntity : class, IEntity
        {
            return this.dbContext.Set<TEntity>().Include(include);
        }

        public IQueryable<TEntity> SelectIncludeMany<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : class, IEntity
        {
            return this.dbContext.Set<TEntity>().IncludeMultiple(includes);
        }

        public IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? skip = null, int? take = null)
         where TEntity : class, IEntity
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = dbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? skip = null, int? take = null)
        where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? skip = null, int? take = null)
         where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? skip = null, int? take = null)
            where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? skip = null, int? take = null)
         where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual TEntity GetById<TEntity>(object id)
         where TEntity : class, IEntity
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual ValueTask<TEntity> GetByIdAsync<TEntity>(object id)
         where TEntity : class, IEntity
        {
            return dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
         where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
         where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).CountAsync();
        }

        public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
         where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
          where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter).AnyAsync();
        }

        public virtual TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
          where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
           where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public virtual TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
          where TEntity : class, IEntity
        {
            return GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
          where TEntity : class, IEntity
        {
            return await GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public List<TEntity> SelectFromQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, IEntity
        {
            return this.dbContext.Set<TEntity>().FromSqlRaw(sqlQuery, parameters).AsNoTracking().ToList();
        }

        public async Task<List<TEntity>> SelectFromQueryAsync<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, IEntity
        {
            return await this.dbContext.Set<TEntity>().FromSqlRaw(sqlQuery, parameters).AsNoTracking().ToListAsync();
        }

        public TEntity GetFromQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, IEntity
        {
            return this.dbContext.Set<TEntity>().FromSqlRaw(sqlQuery, parameters).AsNoTracking().ToList().SingleOrDefault();
        }

        public async Task<TEntity> GetFromQueryAsync<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, IEntity
        {
            return await this.dbContext.Set<TEntity>().FromSqlRaw(sqlQuery, parameters).AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
