using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonSearch.Data;
using PersonSearch.Domain;
using PersonSearch.Service.Contracts;

namespace PersonSearch.Service.Services
{
    public class PersonService: IPersonService
    {
        private readonly IApplicationDbContextFactory _contextFactory;
        private readonly IRepository<Person> _personRepo;
        private readonly IRepository<Group> _groupRepo;
        private readonly IPersonNameBuilder _personNameBuilder;
        private readonly IPersonFilterBuilder _personFilterBuilder;

        public PersonService(
            IApplicationDbContextFactory contextFactory, 
            IRepository<Person> personRepo,
            IRepository<Group> groupRepo,
            IPersonNameBuilder personNameBuilder,
            IPersonFilterBuilder personFilterBuilder)
        {
            _contextFactory = contextFactory;
            _personRepo = personRepo;
            _groupRepo = groupRepo;
            _personNameBuilder = personNameBuilder;
            _personFilterBuilder = personFilterBuilder;
        }

        public IReadOnlyCollection<Person> GetFilteredListOfPeople(string filterText)
        {
            using (var context = _contextFactory.Create(QueryTrackingBehavior.NoTracking))
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    return _personRepo
                        .FetchAll(context, person => person.Group)
                        .ToArray();
                }

                var lowerFilterText = filterText.ToLowerInvariant();
                var queryFilter = _personFilterBuilder.Build(lowerFilterText);
                var filteredQuery = _personRepo
                        .Fetch(queryFilter.Filter,
                            context,
                            person => person.Group);

                if (filteredQuery.Any())
                {
                    return filteredQuery.ToArray();
                }

                return _personRepo
                    .FetchAll(context, person => person.Group)
                    .AsEnumerable()
                    .Where(p => p.Name.ToLowerInvariant().Contains(lowerFilterText) ||
                                p.Group.Name.ToLowerInvariant().Contains(lowerFilterText))
                    .ToArray();
            }
        }

        public bool AddNew(string name, int groupId)
        {
            if (string.IsNullOrEmpty(name) || groupId == 0)
            {
                return false;
            }

            var personName = _personNameBuilder.Build(name);

            using (var context = _contextFactory.Create())
            {
                var existingGroup = _groupRepo.FindById(groupId, context);
                var newPerson = new Person
                {
                    Forenames = personName.Forenames,
                    Surname = personName.Surname,
                    Group = existingGroup
                };

                return _personRepo.AddNew(newPerson, context);
            }
        }

        public int GetPersonCount()
        {
            using (var context = _contextFactory.Create())
            {
                return _personRepo.Count(context);
            }
        }
    }
}
