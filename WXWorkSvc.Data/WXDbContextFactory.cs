using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXWork3rd.Data;


public class WXDbContextFactory : IDesignTimeDbContextFactory<WXDbContext>
{
    public WXDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WXDbContext>();
        optionsBuilder.UseSqlServer("Server=rm-bp14x87s8bgsok95f1o.sqlserver.rds.aliyuncs.com,3433;Database=DBWXWork;User id=dbadmin;Password=Zmmisateacher31415;Trust Server Certificate = true");

        return new WXDbContext(optionsBuilder.Options);
    }
}
