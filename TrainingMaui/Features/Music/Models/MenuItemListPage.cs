using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models
{
    public partial class MenuItemListPage : BaseModel
    {
        [ObservableProperty]
        private string _text;

        [ObservableProperty]
        private string _icon;

        [ObservableProperty]
        private ObservableCollection<TaskModel> _taskModels;
    }
}
