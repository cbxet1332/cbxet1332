using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PersonSearch.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUtc { get; set; }

        [NotMapped] 
        public DateTime CreatedLocal => CreatedUtc.ToLocalTime();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Person> Persons { get; set; }
    }
}
