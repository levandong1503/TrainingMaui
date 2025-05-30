using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public class BarChartDataItem : BaseModel
{
    public string Month { get; set; } = null!;
    public double Value { get; set; }
}
