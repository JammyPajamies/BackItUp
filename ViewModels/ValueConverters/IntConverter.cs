﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BackItUp.ViewModels.ValueConverters
{
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int?)
            {
                int? intValue = (int?)value;
                if (intValue.HasValue)
                {
                    return intValue.Value.ToString();
                }
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string @string)
            {
                if (int.TryParse(@string, out int number))
                {
                    return number;
                }
            }

            return 1;
        }
    }
}
