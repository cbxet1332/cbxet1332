using System;
using System.Reactive.Disposables;
using DotNetify;

namespace PersonSearch.App.ViewModels.Base
{
    public class DisposableVM : BaseVM, IDisposableContainer
    {
        private readonly CompositeDisposable _toBeDisposed = new CompositeDisposable();

        public override void Dispose()
        {
            _toBeDisposed.Dispose();
            base.Dispose();
        }

        public void AddDisposable(IDisposable toBeDisposed)
        {
            _toBeDisposed.Add(toBeDisposed);
        }
    }
}