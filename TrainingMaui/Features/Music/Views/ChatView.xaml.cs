using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Views;

public partial class ChatView : ContentView
{
	private ChatViewModel ViewModel;
    public ChatView(ChatViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
        ViewModel = vm;
    }
}