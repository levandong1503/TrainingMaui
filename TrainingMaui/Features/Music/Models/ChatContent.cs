using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.Containts;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public partial class ChatContent : BaseModel
{
    [ObservableProperty]
    private string _message;

    [ObservableProperty]
    private ChatObject _chatObject;
}
