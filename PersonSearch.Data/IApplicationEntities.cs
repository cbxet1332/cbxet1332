using Microsoft.EntityFrameworkCore;
using PersonSearch.Domain;

namespace PersonSearch.Data
{
    public interface IApplicationEntities
    {
        DbSet<Person> Persons { get; set; }
        DbSet<Group> Groups { get; set; }
    }
}