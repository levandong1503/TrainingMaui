using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public class NavigationGroup : BaseModel
{
    public string GroupName { get; set; } = null!;
    public ObservableCollection<NavigationItem> Items { get; set; } = null!;
}
