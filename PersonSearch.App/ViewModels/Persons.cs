using System.Collections.Generic;
using System.Linq;
using DotNetify;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PersonSearch.Data;
using PersonSearch.Domain;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class Persons : BaseVM
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IApplicationDbContextFactory _contextFactory;
        private Person[] _people;

        public Persons(IRepository<Person> personRepository, IApplicationDbContextFactory contextFactory)
        {
            _personRepository = personRepository;
            _contextFactory = contextFactory;

            GetPersonData();
        }

        public string SearchCriteria { get; set; }

        public IEnumerable<Person> Data => _people;

        public int PersonCount => _people.Length;

        public void GetPersonData()
        {
            using (var context = _contextFactory.Create(QueryTrackingBehavior.NoTracking))
            {
                if (string.IsNullOrEmpty(SearchCriteria))
                {
                    _people = _personRepository
                        .FetchAll(context, person => person.Group)
                        .ToArray();
                }
            }
        }
    }
}
