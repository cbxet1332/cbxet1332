﻿using System;
using System.Collections.Generic;
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

        public PersonList(IPersonService personService, IGroupService groupService)
        {
            _personService = personService;
            _groupService = groupService;

            GetPersonData();
            GetGroupData();

            AddPerson = OnAddPerson;
        }

        public IEnumerable<Person> PersonData => _people;

        [UsedImplicitly]
        public IEnumerable<Group> GroupData => _groups;

        public int PersonCount => _people.Count;
        public string PersonCountSuffix => PersonCount == 1 ? "person" : "people";
        public bool IsFiltering => string.IsNullOrEmpty(FilterText) == false;

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
        }
    }
}
