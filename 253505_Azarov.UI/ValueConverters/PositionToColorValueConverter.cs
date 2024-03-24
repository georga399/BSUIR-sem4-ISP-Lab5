using System.Globalization;

namespace _253505_Azarov.UI.ValueConverters;
internal class PositionToColorValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((int)value < 6)
            return Colors.LightPink;

        return Colors.WhiteSmoke;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
