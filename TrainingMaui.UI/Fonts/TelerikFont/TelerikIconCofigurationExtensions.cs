namespace TrainingMaui.UI.Fonts.TelerikFont;

public static class TelerikIconCofigurationExtensions
{
    public static IFontCollection AddTelerikFont(this IFontCollection fonts)
    {
        var thisAssembly = typeof(TelerikIconCofigurationExtensions).Assembly;
        fonts.AddEmbeddedResourceFont(thisAssembly, "telerikfontexamples.ttf", TelerikFontAliases.TelerikFontExamples);

        return fonts;
    }
}
