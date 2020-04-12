using System;
using System.Threading;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ServerTime : BaseVM
    {
        private readonly Timer _timer;

        public ServerTime()
        {
            _timer = new Timer(state =>
            {
                Changed(nameof(ServerDateTime));
                PushUpdates();
            }, null, 0, 1000);
        }

        public DateTime ServerDateTime => DateTime.Now;

        public override void Dispose()
        {
            _timer.Dispose();
        }
    }
}
