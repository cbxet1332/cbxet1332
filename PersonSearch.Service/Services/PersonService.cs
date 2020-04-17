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

        public PersonService(
            IApplicationDbContextFactory contextFactory, 
            IRepository<Person> personRepo,
            IRepository<Group> groupRepo,
            IPersonNameBuilder personNameBuilder)
        {
            _contextFactory = contextFactory;
            _personRepo = personRepo;
            _groupRepo = groupRepo;
            _personNameBuilder = personNameBuilder;
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
                var filteredQuery = _personRepo
                    .Fetch(p => 
                            EF.Functions.Like(p.Forenames, $"%{lowerFilterText}%") || 
                            EF.Functions.Like(p.Surname, $"%{lowerFilterText}%") || 
                            EF.Functions.Like(p.Group.Name, $"%{lowerFilterText}%"),
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
