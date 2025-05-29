namespace TrainingMaui.Features.Music.Views;

public partial class CardPlaylistView : ContentView
{
	public CardPlaylistView()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(CardPlaylistView));

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(CardPlaylistView));

    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(nameof(Description), typeof(string), typeof(CardPlaylistView));

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }
}