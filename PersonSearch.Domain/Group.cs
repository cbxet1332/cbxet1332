using System.Collections;
using System.Collections.Generic;

namespace PersonSearch.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
