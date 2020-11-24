using Microsoft.EntityFrameworkCore;

namespace DBStuff.Models
{
    public class RecordContext : DbContext
    {
        public DbSet<Record> Records {get; set;}
        public RecordContext(DbContextOptions<RecordContext> options) : base(options)
        {
            
        }
    }
}