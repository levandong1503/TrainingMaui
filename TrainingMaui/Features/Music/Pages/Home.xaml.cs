using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Pages;

public partial class Home : BasePage
{
	private readonly HomeViewModel ViewModel;
    private readonly IDispatcher dispatcher;

    public Home(HomeViewModel vm,
        IDispatcher dispatcher)
	{
		InitializeComponent();

        BindingContext = vm;
        this.ViewModel = vm;
        this.dispatcher = dispatcher;
    }
}