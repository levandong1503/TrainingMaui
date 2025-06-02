using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Pages;

public partial class Chat : BasePage
{
	public Chat(ChatViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}