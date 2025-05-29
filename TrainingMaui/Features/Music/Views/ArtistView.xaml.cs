namespace TrainingMaui.Features.Music.Views;

public partial class ArtistView : ContentView
{
	public ArtistView()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ImageSourceProperty =
       BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(ContentView));

    public static readonly BindableProperty ArtistNameProperty =
        BindableProperty.Create(nameof(ArtistName), typeof(string), typeof(ContentView));

    public static readonly BindableProperty CategoryProperty =
        BindableProperty.Create(nameof(Category), typeof(string), typeof(ContentView));

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public string ArtistName
    {
        get => (string)GetValue(ArtistNameProperty);
        set => SetValue(ArtistNameProperty, value);
    }

    public string Category
    {
        get => (string)GetValue(CategoryProperty);
        set => SetValue(CategoryProperty, value);
    }
}