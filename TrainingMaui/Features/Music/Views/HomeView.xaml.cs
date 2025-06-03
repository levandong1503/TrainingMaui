using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Views;

public partial class HomeView : ContentView
{
	public HomeView(HomeContentViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
    }
}