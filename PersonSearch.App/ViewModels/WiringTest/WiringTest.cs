using System;
using System.Threading;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class WiringTest : BaseVM
    {
        private readonly Timer _timer;

        public WiringTest()
        {
            _timer = new Timer(state =>
            {
                Changed(nameof(ServerTime));
                PushUpdates();
            }, null, 0, 1000);
        }

        public DateTime ServerTime => DateTime.Now;

        public override void Dispose()
        {
            _timer.Dispose();
        }
    }
}
