using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CallCenter.App.Entities;

namespace CallCenter.App.Data
{
    public class CallCenterContext : DbContext
    {
        public CallCenterContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CallCenterDB;Trusted_Connection=true;MultipleActiveResultSets=true;");
        }
    }
}
