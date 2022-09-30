using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class UnitTestingDbContext : DbContext
    {
        public UnitTestingDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }

        public UnitTestingDbContext() { }

        public DbSet<Person> People { get; set; }
    }
}
