using Microsoft.EntityFrameworkCore;
using site.Data.Models;

namespace site.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<dva> dvoiki { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
    
   
}
