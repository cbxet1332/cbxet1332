using System;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class PersonsScope : BaseVM
    {
        private int _pageSize = 10;

        public event EventHandler<string> OnCriteriaChange;
        public event EventHandler<int> OnPageChange;
        public event EventHandler<int> OnPageSizeChange;
        public event EventHandler<int> OnPeopleCountChange;

        public override void OnSubVMCreated(BaseVM childViewModel)
        {
            switch (childViewModel)
            {
                case PersonList personListViewModel:
                    InitPersonList(personListViewModel);
                    break;

                case SearchBar searchBarViewModel:
                    InitSearchBar(searchBarViewModel);
                    break;

                case ListPager listPagerViewModel:
                    InitListPager(listPagerViewModel);
                    break;
            }
        }

        public int PersonCount { get; set; }

        private void InitPersonList(PersonList personListViewModel)
        {
            personListViewModel.OnPeopleCountChange += (sender, numberOfPeople) => OnPeopleCountChange?.Invoke(this, numberOfPeople);
            OnCriteriaChange += (sender, criteria) => personListViewModel.ApplyFilter(criteria);
            OnPageChange += (sender, page) => personListViewModel.SetCurrentPage(page);
            OnPageSizeChange += (sender, pageSize) => personListViewModel.SetPageSize(pageSize);
            PersonCount = personListViewModel.TotalPeople;
            personListViewModel.SetPageSize(_pageSize);
        }

        private void InitSearchBar(SearchBar searchBarViewModel)
        {
            searchBarViewModel.OnCriteriaChange += (sender, criteria) => OnCriteriaChange?.Invoke(this, criteria);
        }

        private void InitListPager(ListPager listPagerViewModel)
        {
            OnPeopleCountChange += (sender, numberOfPeople) => listPagerViewModel.SetNumberOfRows(numberOfPeople);
            listPagerViewModel.OnPageChange += (sender, page) => OnPageChange?.Invoke(this, page);
            listPagerViewModel.OnPageSizeChange += (sender, pageSize) => OnPageSizeChange?.Invoke(this, pageSize);
            listPagerViewModel.SetNumberOfRows(PersonCount);
            listPagerViewModel.SetPageSize(_pageSize);
            listPagerViewModel.SetCurrentPage(1);
        }
    }
}