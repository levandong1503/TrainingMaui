using System.Collections.ObjectModel;
using TrainingMaui.Features.Music.Models;

namespace TrainingMaui.Features.Music.Services;

public interface ILoadHomeService
{
    ObservableCollection<PlayList> LoadPlayList();
    Task<ObservableCollection<PlayList>> LoadPlayListAsync();
}
