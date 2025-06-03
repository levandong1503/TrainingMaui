using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models
{
    public partial class TaskModel : BaseModel
    {
        [ObservableProperty]
        private string _taskId;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _project;

        [ObservableProperty]
        private string _priority;

        [ObservableProperty]
        private string _date;

        [ObservableProperty]
        private ImageSource _imageOwner;
    }
}
