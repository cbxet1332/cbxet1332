using System;
using System.Reactive.Subjects;
using DotNetify;
using JetBrains.Annotations;
using PersonSearch.App.ViewModels.Base;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ButtonTestHandler : DisposableVM
    {
        public ReplaySubject<bool> Clicked = new ReplaySubject<bool>(TimeSpan.FromSeconds(5));

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
            vm.ButtonClick.Subscribe(Clicked).DisposeWith(this);
        }

        private void InitButtonTestCounter(ButtonTestCounter vm)
        {
            Clicked.Subscribe(_ => vm.SetClickCount(vm.GetClickCount() + 1));
        }
    }
}