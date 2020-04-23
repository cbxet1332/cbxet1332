using System;

namespace PersonSearch.App.ViewModels.Base
{
    public static class DisposableExtensions
    {
        public static T DisposeWith<T>(this T source, IDisposableContainer target) where T: IDisposable
        {
            target.AddDisposable(source);
            return source;
        }
    }
}