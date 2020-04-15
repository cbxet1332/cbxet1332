using System;
using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ButtonTestHandler : BaseVM
    {
        public event EventHandler<bool> Clicked;

        public override void OnSubVMCreated(BaseVM childViewModel)
        {
            switch (childViewModel)
            {
                case ButtonTest buttonTestViewModel:
                    InitButtonTest(buttonTestViewModel);
                    break;
                case ButtonTestCounter buttonCounterViewModel:
                    InitButtonTestCounter(buttonCounterViewModel);
                    break;
            }
        }

        private void InitButtonTest(ButtonTest vm)
        {
            vm.OnButtonClick += (sender, clicked) => Clicked?.Invoke(this, clicked);
        }

        private void InitButtonTestCounter(ButtonTestCounter vm)
        {
            Clicked += (sender, clicked) => vm.SetClickCount(vm.ButtonClickCount + 1);
        }
    }
}