using Microsoft.Maui.Controls.Platform;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Pages;

public partial class MemoryLeakEvent : BasePage
{
    public string Message = "Hello";
	private MemoryLeakEventViewModel _viewModel;
    public MemoryLeakEvent(MemoryLeakEventViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _viewModel = viewModel;


        viewModel.LeakEvent += Button_Clicked;
    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
       
        await DisplayAlert("Alert", "", "OK");
    }

    protected override void OnDisappearing()
    {
        //_viewModel.LeakEvent -= Button_Clicked;
        base.OnDisappearing();
    }
}