using System;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ButtonTest : BaseVM
    {
        public event EventHandler<bool> OnButtonClick;

        public Action<bool> ButtonClicked => clicked =>
        {
            OnButtonClick?.Invoke(this, clicked);
        };
    }
}
