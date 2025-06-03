using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;
using TrainingMaui.Features.Music.Views;
using TrainingMaui.UI;

namespace TrainingMaui.Features.Music.ViewModels;

public class ListPageViewModel : BaseViewModel
{
    private object _selectedItem;
    public AsyncRelayCommand NavigateCommand { get; set; }

    public ObservableCollection<MenuItemListPage> Menu { get; set; }
    public ObservableCollection<MenuItem> MenuItems { get; set; } = new();

    [AllowNull]
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

    public ListPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        Menu = 
        [
            new MenuItemListPage
            {
                Text = "Active issues",
                Icon = FontTelerikIcons.Item,
                TaskModels = 
                [
                    new TaskModel
                    {
                        TaskId = "FIG-123",
                        Title = "Task 1",
                        Project = "Project1",
                        Priority = "High",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-122",
                        Title = "Task 2",
                        Project = "Acme GTM",
                        Priority = "Low",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-121",
                        Title = "Write blog post for demo day",
                        Project = "Acme GTM",
                        Priority = "Low",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-120",
                        Title = "Publish blog page",
                        Project = "Website launch",
                        Priority = "Hight",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-119",
                        Title = "Add gradients to design system",
                        Project = "Design backlog",
                        Priority = "Medium",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-123",
                        Title = "Task 1",
                        Project = "Project1",
                        Priority = "High",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-122",
                        Title = "Task 2",
                        Project = "Acme GTM",
                        Priority = "Low",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-121",
                        Title = "Write blog post for demo day",
                        Project = "Acme GTM",
                        Priority = "Low",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-120",
                        Title = "Publish blog page",
                        Project = "Website launch",
                        Priority = "Hight",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    },
                    new TaskModel
                    {
                        TaskId = "FIG-119",
                        Title = "Add gradients to design system",
                        Project = "Design backlog",
                        Priority = "Medium",
                        Date = "Dec 5",
                        ImageOwner = "helenahills.png"
                    }
                ]
            },
            new MenuItemListPage
            {
                Text = "Menu item",
                Icon = FontTelerikIcons.Item,
            },
        ];

        NavigateCommand = new AsyncRelayCommand(NavigateToPageAsync);
    }

    private Task NavigateToPageAsync()
    {
        if (SelectedItem is MenuItem menuItem)
        {
            var createViewTask = Task.Run(() =>
            {
                
            }
            );

            return createViewTask;
        }

        return Task.CompletedTask;
    }
}
