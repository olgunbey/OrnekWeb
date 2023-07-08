using IdentityServer4.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Persistence
{
    public class DesignTime : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var dbcontextoptions = new DbContextOptionsBuilder<AppDbContext>();
            dbcontextoptions.UseSqlServer("Data Source=OLGUNBEY\\OLGUNBEYSQL; Initial Catalog=AnaProje;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new AppDbContext(dbcontextoptions.Options);
        }
    }
}
