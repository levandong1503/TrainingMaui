﻿using System.Globalization;

namespace TrainingMaui.UI.Converters;

public class FontIconConverter : IValueConverter
{
    public string FontFamily { get; set; }
    public double FontSize { get; set; }
    public Color TextColor { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string textGlyph)
        {
            return new FontImageSource
            {
                Glyph = textGlyph,
                FontFamily = this.FontFamily,
                Size = this.FontSize,
                Color = this.TextColor
            };
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is FontImageSource imageSource)
        {
            return imageSource.Glyph;
        }

        return null;
    }
}
