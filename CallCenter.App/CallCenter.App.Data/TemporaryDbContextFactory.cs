using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenter.App.Data
{
    public class TemporaryDbContextFactory : IDbContextFactory<CallCenterContext>
    {

        public CallCenterContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<CallCenterContext>();
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CallCenterDB;Trusted_Connection=true;MultipleActiveResultSets=true;");
            return new CallCenterContext(builder.Options);
        }
    }
}
