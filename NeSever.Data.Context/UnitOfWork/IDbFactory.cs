using NeSever.Data.Context;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyFit.Data.Context.UnitOfWork
{
    public interface IDbFactory
    {
        NeSeverCoreProjectDBContext GetNeSeverCoreProjectDBContext { get; }
    }
}
