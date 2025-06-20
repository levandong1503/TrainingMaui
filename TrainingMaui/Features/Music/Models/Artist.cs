﻿using CommunityToolkit.Mvvm.ComponentModel;
using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Models;

public partial class Artist : BaseModel
{
    [ObservableProperty]
    public string _name;

    [ObservableProperty]
    public string _email;

    [ObservableProperty]
    public ImageSource _imageSourcePath;
}
