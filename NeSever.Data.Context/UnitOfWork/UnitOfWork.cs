using System;
using System.Collections.Generic;
using System.Text;

namespace HappyFit.Data.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void BeginTransaction()
        {
            dbFactory.GetNeSeverCoreProjectDBContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            dbFactory.GetNeSeverCoreProjectDBContext.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            dbFactory.GetNeSeverCoreProjectDBContext.Database.CommitTransaction();
        }

        public void SaveChanges()
        {
            dbFactory.GetNeSeverCoreProjectDBContext.Save();
        }
    }
}
