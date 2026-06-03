using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;
using TrainingMaui.Features.Music.Services;

namespace TrainingMaui.Features.Music.ViewModels;

public partial class HomeContentViewModel : BaseViewModel
{
    [ObservableProperty] ObservableCollection<PlayList> playLists = [];
    private readonly ILoadHomeService _loadHomeService;
    public HomeContentViewModel(IAppNavigator appNavigator, ILoadHomeService loadHomeService) 
        : base(appNavigator)
    {
        _loadHomeService = loadHomeService;

        _loadHomeService.LoadPlayListAsync()
            .ContinueWith(async x =>
        {
            PlayLists.Clear();
            foreach (var item in await x)
            {
                PlayLists.Add(item);
            }
        })
            .ConfigureAwait(false);
    }
}
