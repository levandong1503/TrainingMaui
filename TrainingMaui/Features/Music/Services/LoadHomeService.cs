using System.Collections.ObjectModel;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.Services
{
    public class LoadHomeService : ILoadHomeService
    {
        public ObservableCollection<PlayList> LoadPlayList()
        {
            Thread.Sleep(5000); // Simulate loading delay
            var playLists = new ObservableCollection<PlayList>
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

            return playLists;
        }

        public async Task<ObservableCollection<PlayList>> LoadPlayListAsync()
        {
            await Task.Delay(5000); // Simulate loading delay
            var playLists = new ObservableCollection<PlayList>
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

            return playLists;
        }
    }
}
