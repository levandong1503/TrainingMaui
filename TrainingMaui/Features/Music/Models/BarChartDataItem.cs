using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public partial class BarChartDataItem : BaseModel
{
    [ObservableProperty]
    public string _month;

    [ObservableProperty]
    public double _value;
}
