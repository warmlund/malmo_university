﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RealEstatePL
{
    internal class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed; // Default to Collapsed if the value is not a boolean.
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }

            return false; // Return false if the value is not a Visibility type.
        }
    }
}
