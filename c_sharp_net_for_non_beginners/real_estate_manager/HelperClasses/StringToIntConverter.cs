using System.Globalization;
using System.Windows.Data;
using UtilitiesLib;

namespace RealEstatePL
{
    internal class StringToIntConverter : IValueConverter
    {
        private readonly ConverterUtils _converterUtils = new ConverterUtils();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert int back to string for display in TextBox
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_converterUtils.StringToIntConverter(value as string, out int number))
            {
                return number;
            }
            return 0; // or handle it as a fallback value
        }
    }
}
