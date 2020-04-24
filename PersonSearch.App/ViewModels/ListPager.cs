using System;
using System.Reactive.Subjects;
using DotNetify;
using JetBrains.Annotations;
using PersonSearch.App.ViewModels.Base;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class ListPager : DisposableVM
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        private readonly ReactiveProperty<int> _currentPageProperty;
        private readonly ReactiveProperty<int> _pageSizeProperty;

        public BehaviorSubject<int> CurrentPage = new BehaviorSubject<int>(DefaultPage);
        public BehaviorSubject<int> PageSize = new BehaviorSubject<int>(DefaultPageSize);

        public ListPager()
        {
            _currentPageProperty = AddProperty<int>("CurrentPage", DefaultPage);
            _currentPageProperty.Subscribe(CurrentPage).DisposeWith(this);

            _pageSizeProperty = AddProperty<int>("PageSize", DefaultPageSize);
            _pageSizeProperty.Subscribe(PageSize).DisposeWith(this);
            _pageSizeProperty.Subscribe(_ => RecalculatePages()).DisposeWith(this);
        }

        private int _maxPages = 1;
        private int _numberRows;

        [UsedImplicitly]
        public int TotalPages
        {
            get => Get<int>(); 
            set => Set(value);
        }

        public int NumberRows
        {
            get => _numberRows;
            set
            {
                _numberRows = value;
                RecalculatePages();
            }
        }

        public void SetNumberOfRows(int numberOfRows)
        {
            NumberRows = numberOfRows;
        }

        public void SetPageSize(int pageSize)
        {
            _pageSizeProperty.OnNext(pageSize);
        }

        public void SetCurrentPage(int currentPage)
        {
            _currentPageProperty.OnNext(currentPage);
        }

        private void RecalculatePages()
        {
            var pageSize = (int)(_pageSizeProperty?.Value ?? DefaultPageSize);

            _maxPages = pageSize != 0 && _numberRows > 0 
                ? Convert.ToInt32(Math.Ceiling((_numberRows * 1.0) / pageSize)) 
                : DefaultPage;

            if (_maxPages == 0)
            {
                _maxPages = DefaultPage;
            }

            TotalPages = _maxPages;

            if (_currentPageProperty?.Value == null)
            {
                return;
            }

            if ((int)_currentPageProperty.Value > _maxPages)
            {
                _currentPageProperty.OnNext(_maxPages);
            }
        }
    }
}