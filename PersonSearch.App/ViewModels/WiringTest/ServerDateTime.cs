using System;
using System.Threading;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ServerDateTime : BaseVM
    {
        private readonly Timer _timer;

        public ServerDateTime()
        {
            _timer = new Timer(state =>
            {
                Changed(nameof(ServerDate));
                Changed(nameof(ServerTime));
                PushUpdates();
            }, null, 0, 250);
        }

        private DateTime _serverDateTime => DateTime.Now;

        public string ServerDate => _serverDateTime.ToString("dd/MM/yyyy");    
        public string ServerTime => _serverDateTime.ToString("HH:mm:ss.fff");    

        public override void Dispose()
        {
            _timer.Dispose();
        }
    }
}
