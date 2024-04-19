using Microsoft.EntityFrameworkCore;

namespace site.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        //public DbSet<>
    }
}
