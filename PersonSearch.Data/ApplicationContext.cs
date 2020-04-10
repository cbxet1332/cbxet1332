using Microsoft.EntityFrameworkCore;
using PersonSearch.Domain;

namespace PersonSearch.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
