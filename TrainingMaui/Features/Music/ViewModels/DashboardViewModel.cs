using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    public ObservableCollection<LineChartDataItem> LineChartDatas { get; set; }
    public ObservableCollection<Artist> Artists { get; set; }

    public DashboardViewModel(IAppNavigator appNavigator) 
        : base(appNavigator)
    {
        LineChartDatas =
        [
            new()
            {
                Date = new DateTime(2025, 11, 23),
                Value = 0
            },
            new()
            {
                Date = new DateTime(2025,11, 24),
                Value = 11000
            },
            new()
            {
                Date = new DateTime(2025, 11, 25),
                Value = 28000
            },
            new()
            {
                Date = new DateTime(2025, 11, 26),
                Value = 25000
            },
            new()
            {
                Date = new DateTime(2025, 11, 27),
                Value = 34000
            },
            new()
            {
                Date = new DateTime(2025, 11, 28),
                Value = 39000
            },
            new()
            {
                Date = new DateTime(2025, 11, 29),
                Value = 47000
            }
        ];

        Artists =
        [
            new()
            {
                Name = "Helena",
                Email = "email@figmasfakedomain.net",
                ImageSourcePath = "helenahills.png"
            }
        ];
    }
}
