using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models
{
    public partial class PlayList : BaseModel
    {
        [ObservableProperty]
        private string _title = null!;

        [ObservableProperty]
        private string _description = null!;
        
        [ObservableProperty]
        private ImageSource _imageSource = null!;
    }
}
