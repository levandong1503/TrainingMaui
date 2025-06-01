using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public partial class ChangeWebSiteItem : BaseModel
{
    [ObservableProperty]
    private string _source = null!;

    [ObservableProperty]
    private string _sessions = null!;

    [ObservableProperty]
    private string _change = null!;
}
