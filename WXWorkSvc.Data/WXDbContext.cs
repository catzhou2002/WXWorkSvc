global using Microsoft.EntityFrameworkCore;

namespace WXWork3rd.Data;

public class WXDbContext : DbContext
{
    public WXDbContext(DbContextOptions<WXDbContext> options) : base(options)
    { }

    public DbSet<TSuite> Suites { get; set; }
    public DbSet<TCorp> Corps { get; set; }
    public DbSet<TCorpToken> CorpTokens { get; set; }
    public DbSet<TCorpUser> CorpUsers { get; set; }
}
//Server=rm-bp14x87s8bgsok95f1o.sqlserver.rds.aliyuncs.com,3433;Database=DbWXWork;User id=dbadmin;Password=Zmmisateacher31415;Trust Server Certificate = true
