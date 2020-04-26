using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using DotNetify;
using JetBrains.Annotations;
using PersonSearch.App.Models;
using PersonSearch.App.ViewModels.Base;
using PersonSearch.Domain;
using PersonSearch.Service.Contracts;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class PersonList : DisposableVM
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        private readonly IPersonService _personService;
        private readonly IGroupService _groupService;
        private IReadOnlyCollection<Group> _groups;
        private int _currentPage = DefaultPage;
        private int _pageSize = DefaultPageSize;

        private readonly ReactiveProperty<string> _filterTextProperty;
        private readonly ReactiveProperty<IEnumerable<Person>> _peopleProperty;

        public BehaviorSubject<int> PersonCount = new BehaviorSubject<int>(0);

        public PersonList(IPersonService personService, IGroupService groupService)
        {
            _personService = personService;
            _groupService = groupService;

            _peopleProperty = AddInternalProperty<IEnumerable<Person>>("People", new Person[] { });
            _peopleProperty
                .Select(persons => persons.Count())
                .Subscribe(PersonCount)
                .DisposeWith(this);
            _peopleProperty
                .Subscribe(_ =>
                {
                    Changed(nameof(PersonData));
                    PushUpdates();
                })
                .DisposeWith(this);
            _peopleProperty
                .DisposeWith(this);

            var personCountProperty = AddProperty("PersonCount", 0)
                .SubscribeTo(PersonCount)
                .DisposeWith(this);

            AddProperty("PersonCountSuffix", "person")
                .SubscribeTo(personCountProperty.Select(c => c == 1 ? "person" : "people"))
                .DisposeWith(this);

            _filterTextProperty = AddInternalProperty("FilterText", "");
            _filterTextProperty.Subscribe(GetPersonData).DisposeWith(this);
            _filterTextProperty.DisposeWith(this);
            
            AddProperty("IsFiltering", false)
                .SubscribeTo(_filterTextProperty.Select(ft => string.IsNullOrEmpty(ft) == false))
                .DisposeWith(this);

            GetPersonData();
            GetGroupData();

            AddPerson = OnAddPerson;
        }

        public IEnumerable<Person> PersonData => ((IEnumerable<Person>)_peopleProperty?.Value ?? new Person[] { })
            .Skip(_pageSize * (_currentPage - 1))
            .Take(_pageSize);

        [UsedImplicitly]
        public IEnumerable<Group> GroupData => _groups;

        public Action<AddPersonDetails> AddPerson { get; set; }

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

        public void ApplyFilter(string filterOnText)
        {
            _filterTextProperty.OnNext(filterOnText);
        }

        public void SetCurrentPage(int currentPage)
        {
            _currentPage = currentPage;
            Changed(nameof(PersonData));
            PushUpdates();
        }

        public void SetPageSize(int pageSize)
        {
            _pageSize = pageSize;
            Changed(nameof(PersonData));
            PushUpdates();
        }

        private void OnAddPerson(AddPersonDetails addPersonDetails)
        {
            if (string.IsNullOrEmpty(addPersonDetails.PersonName) || addPersonDetails.GroupId == 0)
            {
                return;
            }
            _personService.AddNew(addPersonDetails.PersonName, addPersonDetails.GroupId);

            ResetAddDetails();
            GetPersonData((string)_filterTextProperty?.Value ?? "");
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
            _groups = _groupService.GetAllGroups();
        }

        private void GetPersonData(string filterOnText = null)
        {
            _peopleProperty.OnNext(_personService.GetFilteredListOfPeople(filterOnText));
        }
    }
}
