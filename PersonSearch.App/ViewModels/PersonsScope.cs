using System;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class PersonsScope : BaseVM
    {
        public event EventHandler<string> OnCriteriaChange;

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
            }
        }

        private void InitPersonList(PersonList personListViewModel)
        {
            OnCriteriaChange += (sender, criteria) => personListViewModel.ApplyFilter(criteria);
        }

        private void InitSearchBar(SearchBar searchBarViewModel)
        {
            searchBarViewModel.OnCriteriaChange += (sender, criteria) => OnCriteriaChange?.Invoke(this, criteria);
        }
    }
}