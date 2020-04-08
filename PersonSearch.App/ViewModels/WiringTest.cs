using System;
using System.Threading;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class WiringTest : BaseVM
    {
        private readonly Timer _timer;
        public DateTime ServerTime => DateTime.Now;

        public WiringTest()
        {
            _timer = new Timer(state =>
            {
                Changed(nameof(ServerTime));
                PushUpdates();
            }, null, 0, 1000);
        }

        public override void Dispose() => _timer.Dispose();
    }
}