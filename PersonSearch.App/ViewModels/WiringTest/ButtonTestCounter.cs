using DotNetify;
using JetBrains.Annotations;
using PersonSearch.App.ViewModels.Base;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ButtonTestCounter : DisposableVM
    {
        private readonly ReactiveProperty<int> _buttonClickProperty;

        public ButtonTestCounter()
        {
            _buttonClickProperty = AddProperty<int>("ButtonClickCount")
                .DisposeWith(this);
        }

        public void SetClickCount(int count) => _buttonClickProperty.OnNext(count);
        public int GetClickCount() => (int)_buttonClickProperty.Value;
    }
}