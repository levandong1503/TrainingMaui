using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;

namespace TrainingMaui.Features.Music.ViewModels
{
    public partial class MemoryLeakEventViewModel : BaseViewModel
    {
        public event EventHandler? LeakEvent;
        public MemoryLeakEventViewModel(IAppNavigator appNavigator) : base(appNavigator)
        {

        }


    }
}
