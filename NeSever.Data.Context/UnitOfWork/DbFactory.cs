using NeSever.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyFit.Data.Context.UnitOfWork
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private NeSeverCoreProjectDBContext dbContext;
        public DbFactory(NeSeverCoreProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public NeSeverCoreProjectDBContext GetNeSeverCoreProjectDBContext
        {
            get
            {
                return this.dbContext;
            }
        }

        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }
            }
            isDisposed = true;
        }
    }
}
