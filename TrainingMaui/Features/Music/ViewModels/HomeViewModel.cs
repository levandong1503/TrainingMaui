using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Telerik.Maui.Controls.NavigationView;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;
using TrainingMaui.Features.Music.Views;
using Windows.UI.ApplicationSettings;

namespace TrainingMaui.Features.Music.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private View _currentPage;
    private object _selectedItem;
    
    [AllowNull]
    public View CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            NotifyPropertyChanged();
        }
    }

    public object SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            NotifyPropertyChanged();
            NavigateToPageAsync();
        }
    }

    public AsyncRelayCommand NavigateCommand { get; set; }


    public HomeViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        NavigateCommand = new AsyncRelayCommand(NavigateToPageAsync);
    }

    public ObservableCollection<NavigationItem> NavigationItems { get; set; }
    public ObservableCollection<NavigationGroup> NavigationGroups { get; set; }

    private Task NavigateToPageAsync()
    {
        if (SelectedItem is NavigationViewItem navItem)
        {
            var createViewTask = Task.Run(() =>
            {
                switch (navItem.Text)
                {
                    case "Home":
                        CurrentPage = new HomeView(); break;
                    case "Browse":
                        CurrentPage = App.Current?.Handler?.MauiContext?.Services.GetService<Dashboard>(); break;
                    case "AboutPage":
                    //CurrentPage = new AboutPage(); break;
                    default:
                        CurrentPage = null; break;
                }
            }
            );

            return createViewTask;
        }

        return Task.CompletedTask;
    }
}
