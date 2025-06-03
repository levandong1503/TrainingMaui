using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.ViewModels;

public class HomeContentViewModel : BaseViewModel
{
    public ObservableCollection<PlayList> PlayLists { get; set; }
    public HomeContentViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        PlayLists = new ObservableCollection<PlayList>
        {
            new PlayList
            {
                Title = "Playlist 1",
                Description = "Description of playlist",
                ImageSource = "playlistcoverimage.png"
            },
            new PlayList
            {
                Title = "Top Hits",
                Description = "The most popular songs right now.",
                ImageSource = "playlistcoverimage.png"
            },
            new PlayList
            {
                Title = "Chill Vibes",
                Description = "Relaxing music for your downtime.",
                ImageSource = "playlistcoverimage.png"
            },
            new PlayList
            {
                Title = "Workout Mix",
                Description = "High-energy tracks to keep you motivated.",
                ImageSource = "playlistcoverimage.png"
            },
            new PlayList
            {
                Title = "Playlist 2",
                Description = "Description of playlist",
                ImageSource = "playlistcoverimage.png"
            }
        };
    }
}
