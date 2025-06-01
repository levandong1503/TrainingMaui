using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public partial class LineChartDataItem : BaseModel
{
    [ObservableProperty]
    private DateTime _date;

    [ObservableProperty]
    private double _value;
}
