using System;
using System.Linq.Expressions;
using PersonSearch.Domain;

namespace PersonSearch.Service.Models
{
    public class PersonFilter
    {
        public string[] MatchWords { private get; set; }

        public Func<string[],Expression<Func<Person,bool>>> GetFilter { private get; set; }

        public Expression<Func<Person, bool>> Filter => 
            GetFilter(MatchWords);
    }
}