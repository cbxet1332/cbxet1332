using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PersonSearch.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Person> Persons { get; set; }
    }
}
