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
                Text = "Inbox",
                Icon = "\ue8a2",
                Tag = "5"
            },
            new NavigationItem
            {
                Text = "Draft",
                Icon = "\ue870"
            },
             new NavigationItem
            {
                Text = "Archive",
                Icon = "\ue826"
            },
            new NavigationItem
            {
                Text = "Sent",
                Icon = "\ue82d"
            },
            new NavigationItem
            {
                Text = "Spam",
                Icon = "\ue82e",
                Tag = "99+"
            },
            new NavigationItem
            {
                Text = "Deleted",
                Icon = "\ue827"
            },
        };
    }

    public  ObservableCollection<NavigationItem> NavigationItems { get; set; }
    private object selectedItem;

    //public IList<NavigationItem> Items => this.navigationItems;
}
