using System;
using System.Reactive.Subjects;
using DotNetify;
using JetBrains.Annotations;
using PersonSearch.App.ViewModels.Base;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class PersonsScope : DisposableVM
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        public BehaviorSubject<string> SearchCriteria = new BehaviorSubject<string>("");
        public BehaviorSubject<int> CurrentPage = new BehaviorSubject<int>(DefaultPage);
        public BehaviorSubject<int> PageSize = new BehaviorSubject<int>(DefaultPageSize);
        public BehaviorSubject<int> PersonCount = new BehaviorSubject<int>(0);

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

        private void InitPersonList(PersonList personListViewModel)
        {
            SearchCriteria.Subscribe(personListViewModel.ApplyFilter);
            CurrentPage.Subscribe(personListViewModel.SetCurrentPage);
            PageSize.Subscribe(personListViewModel.SetPageSize);

            personListViewModel.PersonCount.Subscribe(PersonCount);
            personListViewModel.SetPageSize(PageSize?.Value ?? DefaultPageSize);
        }

        private void InitSearchBar(SearchBar searchBarViewModel)
        {
            searchBarViewModel.SearchCriteria.Subscribe(SearchCriteria);
        }

        private void InitListPager(ListPager listPagerViewModel)
        {
            PersonCount.Subscribe(listPagerViewModel.SetNumberOfRows);

            listPagerViewModel.CurrentPage.Subscribe(CurrentPage).DisposeWith(this);
            listPagerViewModel.PageSize.Subscribe(PageSize).DisposeWith(this);
            listPagerViewModel.SetPageSize((int)PageSize?.Value);
            listPagerViewModel.SetCurrentPage(1);
        }
    }
}