using System;
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
    public class PersonList : BaseVM
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IApplicationDbContextFactory _contextFactory;
        private Person[] _people;

        public PersonList(IRepository<Person> personRepository, IApplicationDbContextFactory contextFactory)
        {
            _personRepository = personRepository;
            _contextFactory = contextFactory;

            GetPersonData();
        }

        public IEnumerable<Person> Data => _people;

        public int PersonCount => _people.Length;

        public string PersonCountSuffix => PersonCount == 1 ? "person" : "people";

        public void GetPersonData(string filterOnText = null)
        {
            using (var context = _contextFactory.Create(QueryTrackingBehavior.NoTracking))
            {
                if (string.IsNullOrEmpty(filterOnText))
                {
                    _people = _personRepository
                        .FetchAll(context, person => person.Group)
                        .ToArray();
                }
                else
                {
                    var filteredQuery = _personRepository
                        .Fetch(p => 
                            EF.Functions.Like(p.Forenames, $"%{filterOnText}%") || 
                            EF.Functions.Like(p.Surname, $"%{filterOnText}%") || 
                            EF.Functions.Like(p.Group.Name, $"%{filterOnText}%"),
                            context,
                            person => person.Group);

                    if (filteredQuery.Any())
                    {
                        _people = filteredQuery.ToArray();
                    }
                    else
                    {
                        _people = _personRepository
                            .FetchAll(context, person => person.Group)
                            .ToList()
                            .Where(p => p.Name.Contains(filterOnText, StringComparison.InvariantCultureIgnoreCase))
                            .ToArray();
                    }
                } 
            }
        }

        public void ApplyFilter(string filterOnText)
        {
            GetPersonData(filterOnText);
            Changed(nameof(Data));
            Changed(nameof(PersonCount));
            Changed(nameof(PersonCountSuffix));
            PushUpdates();
        }
    }
}
