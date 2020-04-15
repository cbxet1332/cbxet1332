using System;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class SearchBar : BaseVM
    {
        public event EventHandler<string> OnCriteriaChange;

        [UsedImplicitly]
        public string SearchText
        {
            get => Get<string>() ?? ""; 
            set
            {
                Set(value);
                OnCriteriaChange?.Invoke(this, value);
            }
        }
    }
}