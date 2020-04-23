using System;
using System.Reactive.Linq;
using JetBrains.Annotations;
using PersonSearch.App.ViewModels.Base;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ServerDateTime : DisposableVM
    {
        public ServerDateTime()
        {
            var timerStream = Observable.Interval(TimeSpan.FromMilliseconds(250)).StartWith(0);

            var serverDateTime = AddInternalProperty<DateTime>("ServerDateAndTime")
                .DisposeWith(this)
                .SubscribeTo(timerStream.Select(_ => DateTime.Now));

            AddProperty<string>("ServerDate")
                .DisposeWith(this)
                .SubscribeTo(serverDateTime.Select(dt => dt.ToString("dd/MM/yyyy")));

            AddProperty<string>("ServerTime")
                .DisposeWith(this)
                .SubscribeTo(serverDateTime.Select(dt => dt.ToString("HH:mm:ss.fff")));

            serverDateTime.Subscribe(_ => PushUpdates())
                .DisposeWith(this);
        }
    }
}
