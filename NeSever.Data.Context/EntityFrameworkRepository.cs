using HappyFit.Data.Context.UnitOfWork;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeSever.Data.Context
{
    public class EntityFrameworkRepository : EntityFrameworkReadOnlyRepository, IRepository
    {
        public EntityFrameworkRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            this.dbContext = dbFactory.GetNeSeverCoreProjectDBContext;
        }

        public virtual void Create<TEntity>(TEntity entity)
        where TEntity : class, IEntity
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity)
        where TEntity : class, IEntity
        {
            dbContext.Set<TEntity>().Attach(entity);
        }
        public virtual void UpdateRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                dbContext.Set<TEntity>().Attach(entity);
            }
        }
        public virtual void Delete<TEntity>(object id)
           where TEntity : class, IEntity
        {
            TEntity entity = dbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
         where TEntity : class, IEntity
        {
            var dbSet = dbContext.Set<TEntity>();

            dbSet.Attach(entity);


            dbSet.Remove(entity);
        }

        public virtual int Save()
        {
            //TODO Validation will be added
            dbContext.SaveChanges();

            return 0;
        }

        public virtual Task<int> SaveAsync()
        {
            //TODO Validation will be added
            dbContext.SaveChangesAsync();
            return Task.FromResult(0);
        }


    }
}
