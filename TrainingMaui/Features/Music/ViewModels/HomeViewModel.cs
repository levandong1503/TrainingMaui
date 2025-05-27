using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.ViewModels;

public class HomeViewModel : BaseViewModel
{
    public HomeViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        NavigationItems = new ObservableCollection<NavigationItem>
        {
            new NavigationItem
            {
                Text = "Home",
                UrlIcon = "home.png",
                UrlPage = "5"
            },
            new NavigationItem
            {
                Text = "Browse",
                UrlIcon = "search.png"
            },
             new NavigationItem
            {
                Text = "Radio",
                UrlIcon = "radio.png"
            },
        };
    }

    public  ObservableCollection<NavigationItem> NavigationItems { get; set; }
    private object selectedItem;

    //public IList<NavigationItem> Items => this.navigationItems;
}
