using System;
using System.Collections.Generic;
using System.Text;

namespace HappyFit.Data.Context.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void RollbackTransaction();

        void CommitTransaction();

        void SaveChanges();
    }
}
