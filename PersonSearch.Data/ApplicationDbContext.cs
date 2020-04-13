using Microsoft.EntityFrameworkCore;
using PersonSearch.Domain;

namespace PersonSearch.Data
{
    public class ApplicationDbContext : DbContext, IApplicationEntities, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany<Person>(group => group.Persons)
                .WithOne(person => person.Group)
                .IsRequired();
        }
    }
}
