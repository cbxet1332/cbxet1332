using System.Reactive.Subjects;
using JetBrains.Annotations;
using PersonSearch.App.ViewModels.Base;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class SearchBar : DisposableVM
    {
        public BehaviorSubject<string> SearchCriteria = new BehaviorSubject<string>("");

        public SearchBar()
        {
            AddProperty("SearchText", "")
                .Subscribe(SearchCriteria)
                .DisposeWith(this);
        }
    }
}