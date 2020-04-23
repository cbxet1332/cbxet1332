using System;
using System.Reactive.Subjects;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ButtonTest : BaseVM
    {
        public ReplaySubject<bool> ButtonClick = new ReplaySubject<bool>(TimeSpan.FromSeconds(5));

        [UsedImplicitly]
        public Action<bool> ButtonClicked => clicked =>
        {
            ButtonClick.OnNext(clicked);
        };
    }
}
