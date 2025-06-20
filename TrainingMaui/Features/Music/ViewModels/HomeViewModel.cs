﻿using CommunityToolkit.Mvvm.Input;
using System.Diagnostics.CodeAnalysis;
using Telerik.Maui.Controls.NavigationView;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Views;

namespace TrainingMaui.Features.Music.ViewModels;

public partial class HomeViewModel : BaseViewModel
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

    [RelayCommand]
    private async Task ChatOpenAsync()
    {
        await AppNavigator.NavigateAsync("Chat", true, null);
    }


    public HomeViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        NavigateCommand = new AsyncRelayCommand(NavigateToPageAsync);
    }

    private Task NavigateToPageAsync()
    {
        if (SelectedItem is NavigationViewItem navItem)
        {
            var createViewTask = Task.Run(() =>
            {
                switch (navItem.Text)
                {
                    case "Home":
                        CurrentPage = App.Current?.Handler?.MauiContext?.Services.GetService<HomeView>(); break;
                    case "Browse":
                        CurrentPage = App.Current?.Handler?.MauiContext?.Services.GetService<Dashboard>(); break;
                    case "Radio":
                        AppNavigator.NavigateAsync("//Chat", true, null).Wait(); break;
                    case "Playlists":
                        AppNavigator.NavigateAsync("//ListPage", true, null).Wait(); break;
                    default:
                        CurrentPage = null; break;
                }
            }
            );

            return createViewTask;
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    private void CallToAction()
    {
        CurrentPage = App.Current?.Handler?.MauiContext?.Services.GetService<ChatView>();
    }
}
