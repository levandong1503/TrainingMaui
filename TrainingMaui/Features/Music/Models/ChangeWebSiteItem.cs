using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public class ChangeWebSiteItem : BaseModel
{
    public string Source { get; set; } = null!;
    public string Sessions { get; set; } = null!;
    public string Change { get; set; } = null!;
}
