using System;
using System.Collections.Generic;
using System.Linq;
using DotNetify;
using JetBrains.Annotations;
using PersonSearch.App.Models;
using PersonSearch.Domain;
using PersonSearch.Service.Contracts;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class PersonList : BaseVM
    {
        private readonly IPersonService _personService;
        private readonly IGroupService _groupService;
        private IReadOnlyCollection<Person> _people;
        private IReadOnlyCollection<Group> _groups;
        private int _currentPage = 1;
        private int _pageSize = 10;

        public event EventHandler<int> OnPeopleCountChange;

        public PersonList(IPersonService personService, IGroupService groupService)
        {
            _personService = personService;
            _groupService = groupService;

            GetPersonData();
            GetGroupData();

            AddPerson = OnAddPerson;
        }

        public IEnumerable<Person> PersonData => _people
            .Skip(_pageSize * (_currentPage - 1))
            .Take(_pageSize);

        [UsedImplicitly]
        public IEnumerable<Group> GroupData => _groups;

        public int PersonCount => _people.Count;
        public string PersonCountSuffix => PersonCount == 1 ? "person" : "people";
        public bool IsFiltering => string.IsNullOrEmpty(FilterText) == false;

        public Action<AddPersonDetails> AddPerson { get; set; }

        public int TotalPeople => _people.Count;

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
            set
            {
                Set(value);
                Changed(nameof(IsFiltering));
                PushUpdates();
            }
        }

        public void ApplyFilter(string filterOnText)
        {
            FilterText = filterOnText;
            RefreshPersonData();
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
        }

        private void OnAddPerson(AddPersonDetails addPersonDetails)
        {
            if (string.IsNullOrEmpty(addPersonDetails.PersonName) || addPersonDetails.GroupId == 0)
            {
                return;
            }
            _personService.AddNew(addPersonDetails.PersonName, addPersonDetails.GroupId);

            ResetAddDetails();
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
            _groups = _groupService.GetAllGroups();
        }

        private void GetPersonData(string filterOnText = null)
        {
            _people = _personService.GetFilteredListOfPeople(filterOnText);
            OnPeopleCountChange?.Invoke(this, _people.Count);
        }
    }
}
