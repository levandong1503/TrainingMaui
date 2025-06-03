using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Pages;

public partial class ListPage : BasePage
{
	public ListPage(ListPageViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}