using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.ViewModels;

public class ChatViewModel : BaseViewModel
{
    public ObservableCollection<ChatPerson> ChatPeople { get; set; }

    public ChatViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        ChatPeople =
        [
            new()
            {
                Name = "Helena",
                NewestChat = "Will head to the Help Center...",
                Avatar = "helenahills.png"
            },
            new()
            {
                Name = "Helena",
                NewestChat = "Will head to the Help Center...",
                Avatar = "helena.png"
            },
            new()
            {
                Name = "Helena",
                NewestChat = "Will head to the Help Center...",
                Avatar = "helena.png"
            },
            new()
            {
                Name = "Helena",
                NewestChat = "Will head to the Help Center...",
                Avatar = "helena.png"
            },
            new()
            {
                Name = "Helena",
                NewestChat = "Will head to the Help Center...",
                Avatar = "helena.png"
            },
            new()
            {
                Name = "Helena",
                NewestChat = "Will head to the Help Center...",
                Avatar = "helena.png"
            },
        ];
    }


}
