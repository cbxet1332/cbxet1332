using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class ButtonTestCounter : BaseVM
    {
        public int ButtonClickCount
        {
            get => Get<int>(); 
            set => Set(value); 
        }

        public void SetClickCount(int count) => ButtonClickCount = count;
    }
}