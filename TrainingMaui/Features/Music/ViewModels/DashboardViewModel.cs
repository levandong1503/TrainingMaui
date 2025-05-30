using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    public ObservableCollection<LineChartDataItem> LineChartData { get; set; }
    public ObservableCollection<Artist> Artists { get; set; }
    public ObservableCollection<ChangeWebSiteItem> ChangeWebSites { get; set; }
    public ObservableCollection<BarChartDataItem> BarChartData { get; set; }

    public DashboardViewModel(IAppNavigator appNavigator) 
        : base(appNavigator)
    {
        LineChartData =
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
            },
            new()
            {
                Name = "Helena",
                Email = "email@figmasfakedomain.net",
                ImageSourcePath = "helenahills.png"
            },
            new()
            {
                Name = "Helena",
                Email = "email@figmasfakedomain.net",
                ImageSourcePath = "helenahills.png"
            },
            new()
            {
                Name = "Helena",
                Email = "email@figmasfakedomain.net",
                ImageSourcePath = "helenahills.png"
            },new()
            {
                Name = "Helena",
                Email = "email@figmasfakedomain.net",
                ImageSourcePath = "helenahills.png"
            }
        ];

        ChangeWebSites = [
            new ChangeWebSiteItem
            {
                Source = "Website.net",
                Sessions = "4321",
                Change = "+84%"
            },
            new ChangeWebSiteItem
            {
                Source = "Website.net",
                Sessions = "4033",
                Change = "-8%"
            },
            new ChangeWebSiteItem
            {
                Source = "Website.net",
                Sessions = "3128",
                Change = "+2%"
            }
        ];

        BarChartData =
        [
            new BarChartDataItem
            {
                Month = "Jan",
                Value = 48000,
            },
            new BarChartDataItem
            {
                Month = "Feb",
                Value = 52000,
            },
            new BarChartDataItem
            {
                Month = "Mar",
                Value = 58000,
            },
            new BarChartDataItem
            {
                Month = "Apr",
                Value = 60000,
            },
            new BarChartDataItem
            {
                Month = "May",
                Value = 62000,
            },
            new BarChartDataItem
            {
                Month = "Jun",
                Value = 64000,
            },
            new BarChartDataItem
            {
                Month = "Jul",
                Value = 68000,
            },
            new BarChartDataItem
            {
                Month = "Aug",
                Value = 70000,
            },
            new BarChartDataItem
            {
                Month = "Sep",
                Value = 72000,
            },
            new BarChartDataItem
            {
                Month = "Oct",
                Value = 74000,
            },
            new BarChartDataItem
            {
                Month = "Nov",
                Value = 76000,
            },
            new BarChartDataItem
            {
                Month = "Dec",
                Value = 80000,
            }
        ];
    }
}
