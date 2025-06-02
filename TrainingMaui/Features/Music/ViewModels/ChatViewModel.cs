using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.Containts;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.ViewModels;

public class ChatViewModel : BaseViewModel
{
    public ObservableCollection<ChatPerson> ChatPeople { get; set; }
    public ObservableCollection<ChatContent> ChatContents { get; set; }

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

        ChatContents =
        [
            new()
            {
                Message = "No honestly I’m thinking of a career pivot",
                ChatObject = ChatObject.MySelf,
            },
            new()
            {
                Message = "Nov 30, 2023, 9:41 AM",
                ChatObject = ChatObject.Time,
            },
            new()
            {
                Message = "Oh?",
                ChatObject = ChatObject.You,
            },
            new()
            {
                Message = "Cool",
                ChatObject = ChatObject.You,
            },
            new()
            {
                Message = "How does it work?",
                ChatObject = ChatObject.You,
            },
            new()
            {
                Message = "Simple",
                ChatObject = ChatObject.MySelf,
            },
            new()
            {
                Message = "You just edit any text to type in the conversation you want to show, and delete any bubbles you don’t want to use",
                ChatObject = ChatObject.MySelf,
            },
            new()
            {
                Message = "Boom",
                ChatObject = ChatObject.MySelf,
            },
            new()
            {
                Message = "Hmmm",
                ChatObject = ChatObject.You,
            },
            new()
            {
                Message = "I think I get it",
                ChatObject = ChatObject.You,
            },
            new()
            {
                Message = "Will head to the Help Center if I have more questions tho",
                ChatObject = ChatObject.You,
            },
        ];
    }


}
