using System;

namespace PersonSearch.App.ViewModels.Base
{
    public interface IDisposableContainer : IDisposable
    {
        void AddDisposable(IDisposable toBeDisposed);
    }
}