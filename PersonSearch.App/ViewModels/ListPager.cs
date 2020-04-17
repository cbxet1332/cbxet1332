using System;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class ListPager : BaseVM
    {
        public ListPager()
        {
            PageSize = 10;
        }

        private int _maxPages = 1;
        private int _numberRows;

        public event EventHandler<int> OnPageChange;
        public event EventHandler<int> OnPageSizeChange;

        [UsedImplicitly]
        public int CurrentPage
        {
            get => Get<int>(); 
            set
            {
                Set(value);
                OnPageChange?.Invoke(this, value);
                RecalculateButtons();
            }
        }

        [UsedImplicitly]
        public bool IsPrevEnabled
        {
            get => Get<bool>(); 
            set => Set(value);
        }

        [UsedImplicitly]
        public bool IsNextEnabled
        {
            get => Get<bool>(); 
            set => Set(value);
        }

        [UsedImplicitly]
        public int PageSize
        {
            get => Get<int>();
            set
            {
                Set(value);
                OnPageSizeChange?.Invoke(this, value);
                RecalculatePages();
            }
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
            PageSize = pageSize;
        }

        public void SetCurrentPage(int currentPage)
        {
            CurrentPage = currentPage;
        }

        private void RecalculatePages()
        {
            _maxPages = PageSize != 0 && _numberRows > 0 
                ? Convert.ToInt32(Math.Ceiling((_numberRows * 1.0) / PageSize)) 
                : 1;
            if (_maxPages == 0)
            {
                _maxPages = 1;
            }

            if (CurrentPage > _maxPages)
            {
                CurrentPage = _maxPages;
            }
        }

        private void RecalculateButtons()
        {
            IsPrevEnabled = CurrentPage > 1;
            IsNextEnabled = CurrentPage < _maxPages;
        }
    }
}