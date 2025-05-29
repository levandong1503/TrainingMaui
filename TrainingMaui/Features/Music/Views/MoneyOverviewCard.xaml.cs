namespace TrainingMaui.Features.Music.Views;

public partial class MoneyOverviewCard : ContentView
{
    public MoneyOverviewCard()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(MoneyOverviewCard));

    public static readonly BindableProperty ContentTextProperty =
        BindableProperty.Create(nameof(ContentText), typeof(string), typeof(MoneyOverviewCard));

    public static readonly BindableProperty FooterProperty =
        BindableProperty.Create(nameof(Footer), typeof(string), typeof(CardPlaylistView));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string ContentText
    {
        get => (string)GetValue(ContentTextProperty);
        set => SetValue(ContentTextProperty, value);
    }

    public string Footer
    {
        get => (string)GetValue(FooterProperty);
        set => SetValue(FooterProperty, value);
    }
}