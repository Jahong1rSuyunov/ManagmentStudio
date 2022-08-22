using ManagmentStudio.Shared;
using Microsoft.EntityFrameworkCore;

namespace ManagmentStudio.Server.AppDbContext
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {

        }

        public DbSet<Query> Queries { get; set; }
    }
}
