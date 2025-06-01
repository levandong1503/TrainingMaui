using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public partial class ChatPerson : BaseModel
{
    [ObservableProperty]
    private string _name = null!;
    [ObservableProperty]
    private string _newestChat = null!;
    [ObservableProperty]
    private ImageSource _avatar = null!;
}
