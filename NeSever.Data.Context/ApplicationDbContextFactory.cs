using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NeSever.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<NeSeverCoreProjectDBContext>
    {
        NeSeverCoreProjectDBContext IDesignTimeDbContextFactory<NeSeverCoreProjectDBContext>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NeSeverCoreProjectDBContext>();

            builder.UseSqlServer("Data Source=185.22.187.183;Initial Catalog=NeSeverCoreProjectDB;Persist Security Info=True;User ID=NeSeverCoreProjectUser;Password=@NeSeverCoreProjectUser",
            // optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(NeSeverCoreProjectDBContext).GetTypeInfo().Assembly.GetName().Name));

            //builder.UseSqlServer("Server = localhost; Database = NeSeverCoreProjectDB; Trusted_Connection = True; ",
             optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(NeSeverCoreProjectDBContext).GetTypeInfo().Assembly.GetName().Name));




            return new NeSeverCoreProjectDBContext(builder.Options);
        }
    }
}
