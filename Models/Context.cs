using Microsoft.EntityFrameworkCore;

namespace DBStuff.Models
{
    public class Context : DbContext
    {
        public DbSet<Record> Records {get; set;}
        public Context(DbContextOptions<DbContext> options) : base(options)
        {
            
        }
    }
}