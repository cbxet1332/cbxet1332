using System;
using System.Collections.Generic;
using System.Linq;
using DotNetify;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PersonSearch.App.Models;
using PersonSearch.Data;
using PersonSearch.Domain;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class PersonList : BaseVM
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IApplicationDbContextFactory _contextFactory;
        private Person[] _people;
        private Group[] _groups;

        public PersonList(IApplicationDbContextFactory contextFactory, 
            IRepository<Person> personRepository, 
            IRepository<Group> groupRepository)
        {
            _personRepository = personRepository;
            _groupRepository = groupRepository;
            _contextFactory = contextFactory;

            GetPersonData();
            GetGroupData();

            AddPerson = OnAddPerson;
        }

        public IEnumerable<Person> PersonData => _people;

        public IEnumerable<Group> GroupData => _groups;

        public int PersonCount => _people.Length;

        public string PersonCountSuffix => PersonCount == 1 ? "person" : "people";

        public string AddPersonText
        {
            get => Get<string>(); 
            set => Set(value); 
        }

        public int AddGroupId
        {
            get => Get<int>(); 
            set => Set(value); 
        }

        public string FilterText
        {
            get => Get<string>(); 
            set => Set(value); 
        }

        public Action<AddPersonDetails> AddPerson { get; set; } 

        private void OnAddPerson(AddPersonDetails addPersonDetails)
        {
            if (string.IsNullOrEmpty(addPersonDetails.PersonName) || addPersonDetails.GroupId == 0)
            {
                return;
            }

            string forenames;
            var surname = string.Empty;

            var names = addPersonDetails.PersonName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 1)
            {
                forenames = names[0];
            }
            else
            {
                surname = names.Last();
                forenames = string.Join(' ', names.Take(names.Length - 1));
            }

            using (var context = _contextFactory.Create())
            {
                var existingGroup = _groupRepository.FindById(addPersonDetails.GroupId, context);
                var newPerson = new Person
                {
                    Forenames = forenames,
                    Surname = surname,
                    Group = existingGroup
                };

                _personRepository.AddNew(newPerson, context);
            }

            ResetAddDetails();
            RefreshPersonData();
        }

        public void ApplyFilter(string filterOnText)
        {
            FilterText = filterOnText;
            RefreshPersonData();
        }

        private void RefreshPersonData()
        {
            GetPersonData(FilterText);
            Changed(nameof(PersonData));
            Changed(nameof(PersonCount));
            Changed(nameof(PersonCountSuffix));
            PushUpdates();
        }

        private void ResetAddDetails()
        {
            AddPersonText = string.Empty;
            AddGroupId = 0;
            Changed(nameof(AddPersonText));
            Changed(nameof(AddGroupId));
            PushUpdates();
        }

        private void GetGroupData()
        {
            using (var context = _contextFactory.Create(QueryTrackingBehavior.NoTracking))
            {
                _groups = _groupRepository.FetchAll(context)
                    .ToArray();
            }
        }

        private void GetPersonData(string filterOnText = null)
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
    }
}
