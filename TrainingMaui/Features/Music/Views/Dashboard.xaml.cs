using TrainingMaui.Features.Music.Models;
using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Views;

public partial class Dashboard : ContentView
{
	public DashboardViewModel ViewModel { get; set; }
	public Dashboard(DashboardViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
		BindingContext = vm;
	}
}