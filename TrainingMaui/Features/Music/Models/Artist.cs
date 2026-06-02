using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Diagnostics;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public partial class Artist : BaseModel
{
    public event Action<string>? ValueChanged;

    [ObservableProperty]
    public string _name;

    [ObservableProperty]
    public string _email;

    [ObservableProperty]
    public ImageSource _imageSourcePath;

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.PropertyName == nameof(Name))
        {
            Console.WriteLine($"{e.PropertyName} change {Name}");
        }
    }

    partial void OnNameChanged(string value)
    {

    }
}
